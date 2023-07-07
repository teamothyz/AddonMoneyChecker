﻿using AddonMoney.Transfer.Models;
using Serilog;

namespace AddonMoney.Transfer.Services
{
    public class DataService
    {
        private static readonly string _logPrefix = "[DataService]";
        private static readonly object _lockData = new();
        private static readonly object _lockResult = new();

        public static void ReadAccounts(string path)
        {
            lock (_lockData)
            {
                try
                {
                    Account.Accounts.Clear();
                    var accounts = new List<Account>();
                    using var streamReader = new StreamReader(path);
                    var line = streamReader.ReadLine();
                    while (line != null)
                    {
                        var details = line.Split('|');
                        var accountId = Convert.ToInt32(details[0].Trim());
                        var payeerId = details[1].Trim();
                        var phone = details[2].Trim();
                        var appId = Convert.ToInt32(details[3].Trim());
                        var appHash = details[4].Trim();
                        var account = new Account(accountId, payeerId, phone, appId, appHash);
                        accounts.Add(account);
                    }
                    Account.Accounts.AddRange(accounts);
                }
                catch (Exception ex)
                {
                    Log.Error($"{_logPrefix} Got exception while reading accounts file. {ex}");
                }
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

        public static void WriteResult(string name, DriverProfile profile, bool success, string? reason = null)
        {
            lock (_lockResult)
            {
                try
                {
                    var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "results");
                    if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
                    var file = Path.Combine(folder, $"{name}.txt");
                    var result = success ? "OK" : "FAILED";
                    var line = $"{profile.Profile}|{result}";
                    if (reason != null) line += "|reason: " + reason;
                    using var writer = new StreamWriter(file, true);
                    writer.WriteLine(line);
                    writer.Flush();
                    writer.Close();
                }
                catch { }
            }
        }
    }
}