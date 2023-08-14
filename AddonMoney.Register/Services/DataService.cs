using AddonMoney.Register.Models;
using Serilog;

namespace AddonMoney.Register.Services
{
    public class DataService
    {
        private static readonly string _logPrefix = "[DataService]";
        private static readonly object _outputLocker = new();
        private static readonly object _lockSuccess = new();
        private static readonly object _lockErr = new();

        private static string GetOutputFolder()
        {
            lock (_outputLocker)
            {
                var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "outdata");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                return folder;
            }
        }

        public static bool ReadAccounts(string path)
        {
            try
            {
                var accounts = new List<Account>();
                using var reader = new StreamReader(path);
                var line = reader.ReadLine();
                while (line != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        line = reader.ReadLine();
                        continue;
                    }
                    var account = new Account(line);
                    accounts.Add(account);
                    line = reader.ReadLine();
                }
                Account.Accounts.Clear();
                foreach (var account in accounts)
                {
                    Account.Accounts.Enqueue(account);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Got exception while reading accounts file. Error: {ex}");
                return false;
            }
        }

        public static void WriteSuccess(Account account, DateTime startTime)
        {
            lock (_lockSuccess)
            {
                RegisterService.RegistedAccount++;
                try
                {
                    var folder = GetOutputFolder();
                    var filePath = Path.Combine(folder, $"success{startTime:ddMMyyyyHHmmss}.txt");
                    using var writer = new StreamWriter(filePath, true);
                    writer.WriteLine(account.ToStringSuccess());
                    writer.Flush();
                    writer.Close();
                }
                catch (Exception ex)
                {
                    Log.Error($"{_logPrefix} Got exception while writing success account. Error: {ex}");
                }
            }
        }

        public static void WriteError(Account account, DateTime startTime)
        {
            lock (_lockErr)
            {
                try
                {
                    var folder = GetOutputFolder();
                    var filePath = Path.Combine(folder, $"error{startTime:ddMMyyyyHHmmss}.txt");
                    using var writer = new StreamWriter(filePath, true);
                    writer.WriteLine(account.ToStringError());
                    writer.Flush();
                    writer.Close();
                }
                catch (Exception ex)
                {
                    Log.Error($"{_logPrefix} Got exception while writing error account. Error: {ex}");
                }
            }
        }
    }
}
