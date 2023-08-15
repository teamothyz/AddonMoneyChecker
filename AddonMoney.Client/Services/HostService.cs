using System.Net.Sockets;
using System.Net;
using AddonMoney.Client.Models;

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

        public static void WriteConfig(int timeout, int timeSleep, int start, int end)
        {
            try
            {
                using var writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.data"), false);
                writer.WriteLine($"{timeout}|{timeSleep}|{start}|{end}");
                writer.Flush();
                writer.Close();
            }
            catch { }
        }

        public static Tuple<int, int, int, int> GetConfig()
        {
            try
            {
                using var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.data"));
                var data = reader.ReadToEnd();
                var timeout = data.Split('|')[0].Trim();
                var timeSleep = data.Split('|')[1].Trim();
                var start = data.Split('|')[2].Trim();
                var end = data.Split('|')[3].Trim();
                return Tuple.Create(int.Parse(timeout), int.Parse(timeSleep), int.Parse(start), int.Parse(end));
            }
            catch 
            {
                return Tuple.Create(30, 30, 4, 16);
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

        public static bool ReadProfileInfo(string path)
        {
            try
            {
                ProfileInfo.Profiles.Clear();
                using var reader = new StreamReader(path);
                var line = reader.ReadLine();

                var profileInfos = new List<ProfileInfo>();
                while (line != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        line = reader.ReadLine();
                        continue;
                    }
                    profileInfos.Add(new ProfileInfo(line));
                    line = reader.ReadLine();
                }
                reader.Close();
                ProfileInfo.Profiles.AddRange(profileInfos);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void SaveProfileInfo()
        {
            try
            {
                using var writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profile.data"), false);
                foreach (var profileInfo in ProfileInfo.Profiles)
                {
                    writer.WriteLine(profileInfo.Raw);
                }
                writer.Flush();
                writer.Close();
            }
            catch { }
        }
    }
}
