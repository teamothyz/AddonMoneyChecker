namespace AddonMoney.Register.Models
{
    public class MyProxy
    {
        public static ProxyType Type { get; set; }

        public string Host { get; set; } = null!;

        public int Port { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public MyProxy(string data)
        {
            var details = data.Split(":");
            Host = details[0].Trim();
            Port = int.Parse(details[1].Trim());
            if (details.Length == 4)
            {
                Username = details[2];
                Password = details[3];
            }
        }

        public override string ToString()
        {
            var type = Type switch
            {
                ProxyType.Http => "http://",
                ProxyType.Socks5 => "socks5://",
                _ => "http://"
            };
            if (Type == ProxyType.None) return null!;
            return $"{type}:{Host}:{Port}:{Username}:{Password}";
        }

        public string ToStringWithoutPrefix()
        {
            return $"{Host}:{Port}:{Username}:{Password}";
        }
    }

    public enum ProxyType
    {
        None = 0,
        Http = 1,
        Socks5 = 2
    }
}
