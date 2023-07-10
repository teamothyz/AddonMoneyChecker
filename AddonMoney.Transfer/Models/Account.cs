namespace AddonMoney.Transfer.Models
{
    public class Account
    {
        public static readonly List<Account> Accounts = new();

        public int AccountId { get; set; }

        public string PayeerId { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string TeleSession { get; set; } = null!;

        public int ApiId { get; set; }

        public string ApiHash { get; set; } = null!;

        public MyProxy? Proxy { get; set; } = null!;

        public Account(int accountId, string payeerId, string phone, int apiId, string apiHash, MyProxy? proxy = null)
        {
            AccountId = accountId;
            PayeerId = payeerId;
            Phone = phone.StartsWith('0') ? "+84" + phone[1..] : phone;
            TeleSession = $"{phone}.session";
            ApiId = apiId;
            ApiHash = apiHash;
            Proxy = proxy;
        }
    }
}
