using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AddonMoney.Data.Models
{
    public class AddonMoneyContext : DbContext
    {
        public AddonMoneyContext() { }

        public AddonMoneyContext(DbContextOptions<AddonMoneyContext> options)
            : base(options) { }

        public DbSet<BalanceInfo> BalanceInfos { get; set; }

        public DbSet<ErrorInfo> ErrorInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                    .Build().GetConnectionString("AddonMoneyDB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
