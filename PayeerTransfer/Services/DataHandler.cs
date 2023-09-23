using PayeerTransfer.Models;
using Serilog;

namespace PayeerTransfer.Services
{
    public class DataHandler
    {
        private static readonly object _accountsLocker = new();
        private static readonly object _saveLocker = new();

        public static List<Account> ReadAccounts(string path)
        {
            lock (_accountsLocker)
            {
                try
                {
                    var accounts = new List<Account>();
                    Account.AccountIndex = 1;
                    using var reader = new StreamReader(path);
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            line = reader.ReadLine();
                            continue;
                        }
                        var details = line.Split("|");
                        var account = new Account
                        {
                            Username = details[0],
                            Password = details[1]
                        };
                        if (details.Length >= 3) account.MasterKey = details[2];
                        accounts.Add(account);
                        line = reader.ReadLine();
                    }
                    return accounts;
                }
                catch (Exception ex)
                {
                    Log.Error($"Read accounts error: {ex}");
                    return null!;
                }
            }
        }

        public static void SaveAccount(Account account, DateTime session, string fileName)
        {
            try
            {
                lock (_saveLocker)
                {
                    var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                    var subFolder = account.Status switch
                    {
                        Status.LoginWrongInfo => Path.Combine(folder, "wronginfo"),
                        Status.TransferSuccess or Status.TransferNotEnough => Path.Combine(folder, "success"),
                        _ => Path.Combine(folder, "exception")
                    };
                    if (!Directory.Exists(subFolder)) Directory.CreateDirectory(subFolder);

                    using var writer = new StreamWriter(Path.Combine(subFolder, $"{fileName}.{session:yyyy.MM.dd.HH.mm.ss}.txt"), true);
                    writer.WriteLine($"{account.Username}|{account.Password}|{account.Status}|{account.Progress}");
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Save error: {ex}");
            }
        }
    }
}
