namespace AddonMoney.Transfer.Models
{
    public class MyProxy
    {
        public static ProxyType Type { get; set; }

        public string Host { get; set; } = null!;

        public int Port { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public override string ToString()
        {
            var type = Type switch
            {
                ProxyType.Http => "http://",
                ProxyType.Socks5 => "socks5://",
                _ => "http://"
            };
            if (Type == ProxyType.None) return null!;
            return $"{type}{Host}:{Port}:{Username}:{Password}";
        }
    }

    public enum ProxyType
    {
        None = 0,
        Http = 1,
        Socks5 = 2
    }
}
