using System.ComponentModel;
using System.Diagnostics;

namespace TelegramSessionChecking
{
    public class SessionFile : INotifyPropertyChanged
    {
        public string FilePath { get; set; } = null!;

        public string Name { get => Path.GetFileNameWithoutExtension(FilePath); }

        private string _status = "NOT CHECK";
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        }

        private string _proxy = string.Empty;
        public string Proxy
        {
            get => _proxy;
            set
            {
                _proxy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Proxy)));
            }
        }

        public bool? Live { get; set; } = null;

        public event PropertyChangedEventHandler? PropertyChanged;

        public async Task Check(string appId, string appHash, DateTime time, CancellationToken token)
        {
            try
            {
                Status = "CHECKING...";
                if (!File.Exists(FilePath))
                {
                    Status = $"FILE {Name} NOT FOUND";
                    return;
                }

                var exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "helper", "CheckSession.exe");
                if (string.IsNullOrWhiteSpace(Proxy))
                {
                    Status = "MISSING PROXY";
                    return;
                }
                var input = @$"""{FilePath}"" {appId} {appHash} ""http://{Proxy}""";
                using var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = exePath,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        Arguments = input
                    }
                };
                process.Start();
                _ = process.WaitForExit(60 * 1000);

                var output = await process.StandardOutput.ReadToEndAsync();
                var error = await process.StandardError.ReadToEndAsync();
                var result = output + " " + error;
                if (result.Contains("the session already had an authorized user", StringComparison.OrdinalIgnoreCase))
                {
                    Status = "LIVE";
                    Live = true;
                    WriteSuccessToFile(this, time);
                    return;
                }
                if (result.Contains("The api_id/api_hash combination is invalid", StringComparison.OrdinalIgnoreCase))
                {
                    Status = "DIE";
                    Live = false;
                    WriteFailedToFile(this, time);
                    return;
                }
                Status = "UNKNOWN";
                Live = null;
            }
            catch (Exception ex)
            {
                Status = $"EXCEPTION: {ex.Message}";
                Live = null;
            }
        }

        private static readonly object _successLocker = new();
        private static void WriteSuccessToFile(SessionFile session, DateTime time)
        {
            lock (_successLocker)
            {
                try
                {
                    var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                    var filePath = Path.Combine(folder, $"live{time:yyyyMMddHHmmss}.txt");
                    using var writer = new StreamWriter(filePath, true);
                    writer.WriteLine($"{session.Proxy}|{session.Name}");
                    writer.Flush();
                    writer.Close();
                }
                catch { }
            }
        }

        private static readonly object _failedLocker = new();
        private static void WriteFailedToFile(SessionFile session, DateTime time)
        {
            lock (_failedLocker)
            {
                try
                {
                    var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                    var filePath = Path.Combine(folder, $"die{time:yyyyMMddHHmmss}.txt");
                    using var writer = new StreamWriter(filePath, true);
                    writer.WriteLine($"{session.Proxy}|{session.Name}");
                    writer.Flush();
                    writer.Close();
                }
                catch { }
            }
        }
    }
}
