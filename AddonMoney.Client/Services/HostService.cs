using System.Net.Sockets;
using System.Net;

namespace AddonMoney.Client.Services
{
    public class HostService
    {
        private static string _hostName = null!;
        private static readonly object _lock = new();

        public static void SetHost(string hostName)
        {
            lock (_lock)
            {
                _hostName = hostName;
                WriteHostName();
            }
        }

        public static string GetHostName()
        {
            lock (_lock)
            {
                if (string.IsNullOrEmpty(_hostName))
                {
                    _hostName = ReadHostName();
                    if (!string.IsNullOrEmpty(_hostName)) return _hostName;

                    string hostName = Dns.GetHostName();
                    string ipAddressString = string.Empty;
                    IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
                    IPAddress[] ipAddresses = hostEntry.AddressList;
                    foreach (IPAddress ipAddress in ipAddresses)
                    {
                        if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipAddressString = ipAddress.ToString();
                            break;
                        }
                    }
                    _hostName = $"[{hostName}]{ipAddressString}";
                    WriteHostName();
                }
                return _hostName;
            }
        }

        public static string[] ReadUserDataDirs()
        {
            try
            {
                using var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userdatadir.data"));
                var lines = new List<string>();
                var line = reader.ReadLine();
                while (line != null)
                {
                    lines.Add(line);
                    line = reader.ReadLine();
                }
                return lines.ToArray();
            }
            catch
            {
                return Array.Empty<string>();
            }
        }

        public static void WriteUserDataDirs(string[] data)
        {
            try
            {
                using var writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userdatadir.data"), false);
                foreach (var line in data)
                {
                    writer.WriteLine(line);
                }
                writer.Flush();
                writer.Close();
            }
            catch { }
        }

        private static string ReadHostName()
        {
            try
            {
                using var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hostname.data"));
                return reader.ReadToEnd().Trim();
            }
            catch
            {
                return null!;
            }
        }

        private static void WriteHostName()
        {
            try
            {
                using var writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hostname.data"), false);
                writer.WriteLine(_hostName);
                writer.Flush();
                writer.Close();
            }
            catch { }
        }

        public static string GetRefLink()
        {
            try
            {
                using var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ref.data"));
                return reader.ReadToEnd().Trim();
            }
            catch 
            {
                return string.Empty;
            }
        }

        public static void SaveRefLink(string refLink)
        {
            try
            {
                using var writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ref.data"), false);
                writer.WriteLine(refLink);
                writer.Flush();
                writer.Close();
            }
            catch { }
        }
    }
}
