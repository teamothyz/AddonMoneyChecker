using System.Net.Sockets;
using System.Net;

namespace AddonMoney.Client.Services
{
    public class HostService
    {
        private static string _hostName = null!;

        public static string GetHostName()
        {
            if (string.IsNullOrEmpty(_hostName))
            {
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
            }
            return _hostName;
        }
    }
}
