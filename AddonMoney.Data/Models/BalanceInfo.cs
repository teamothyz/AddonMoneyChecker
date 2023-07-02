using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddonMoney.Data.Models
{
    [Table("BlanceInfo")]
    public class BalanceInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Balance { get; set; }

        public int LastBalance { get; set; }

        public int TodayEarn { get; set; }

        public int LastTodayEarn { get; set; }

        public string Profile { get; set; } = null!;

        public string VPS { get; set; } = null!;

        public DateTime LastUpdate { get; set; }
    }
}
