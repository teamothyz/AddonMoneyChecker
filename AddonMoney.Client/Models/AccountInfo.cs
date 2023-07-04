namespace AddonMoney.Client.Models
{
    public class AccountInfo
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Balance { get; set; }

        public int TodayEarn { get; set; }

        public bool Success { get; set; } = false;

        public string ErrorMsg { get; set; } = null!;

        public string Profile { get; set; } = null!;
    }
}
