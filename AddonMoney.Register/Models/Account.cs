namespace AddonMoney.Register.Models
{
    public class Account
    {
        public static readonly Queue<Account> Accounts = new();

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string RecoveryMail { get; set; } = null!;

        public MyProxy Proxy { get; set; } = null!;

        public string Cookie { get; set; } = null!;

        public string Error { get; set; } = null!;

        public Account(string data) 
        {
            var details = data.Split('|');
            Email = details[0].Trim();
            Password = details[1];
            RecoveryMail = details[2];
            Proxy = new MyProxy(details[3].Trim());
        }

        public string ToStringSuccess()
        {
            return $"{Email}|{Password}|{RecoveryMail}|{Proxy.ToStringWithoutPrefix()}|{Cookie}";
        }

        public string ToStringError()
        {
            return $"{Email}|{Password}|{RecoveryMail}|{Proxy.ToStringWithoutPrefix()}|Error: {Error}";
        }
    }
}
