namespace AddonMoney.Transfer.Models
{
    public class MyProxy
    {
        public static readonly List<MyProxy> Proxies = new();

        public static ProxyType Type { get; set; }

        private static int _proxyIndex = -1;

        public static MyProxy? GetProxy()
        {
            lock (Proxies)
            {
                if (Type == ProxyType.None || Proxies.Count == 0) return null;

                _proxyIndex++;
                if (_proxyIndex >= Proxies.Count || _proxyIndex < 0) _proxyIndex = 0;
                return Proxies[_proxyIndex];
            }
        }

        public string Host { get; set; } = null!;

        public int Port { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
    }

    public enum ProxyType
    {
        None = 0,
        Http = 1,
        Socks5 = 2
    }
}
