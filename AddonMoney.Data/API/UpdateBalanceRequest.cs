namespace AddonMoney.Data.API
{
    public class UpdateBalanceRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Balance { get; set; }
        
        public int TodayEarn { get; set; }
        
        public string Profile { get; set; } = null!;
    }
}
