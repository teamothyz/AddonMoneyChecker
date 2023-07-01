using AddonMoney.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AddonMoney.Data.Repositories
{
    public class BalanceInfoRepository
    {
        private readonly AddonMoneyContext _dbcontext;

        public BalanceInfoRepository(AddonMoneyContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<PaginatedList<BalanceInfo>> GetBalanceInfos(int? id = null,
            string? name = null,
            int pageIndex = 1,
            int pageSize = 10)
        {
            var query = _dbcontext.BalanceInfos.AsQueryable();
            if (id != null)
            {
                query = query.Where(bal => bal.Id == id);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(bal => bal.Name.ToLower().Contains(name.ToLower()));
            }
            var total = await query.CountAsync();
            var items = await query.OrderByDescending(bal => bal.LastUpdate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PaginatedList<BalanceInfo>(items, total, pageSize);
        }

        public async Task<BalanceInfo?> GetBalanceInfo(int id)
        {
            return await _dbcontext.BalanceInfos.AsNoTracking()
                .SingleOrDefaultAsync(bal => bal.Id == id);
        }

        public async Task<int> UpdateBalance(int id, string name, int balance, int todayEarn, string profile)
        {
            using var transaction = await _dbcontext.Database.BeginTransactionAsync();
            try
            {
                DateTime utcNow = DateTime.UtcNow;
                TimeZoneInfo gmt7TimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                DateTime gmt7Time = TimeZoneInfo.ConvertTimeFromUtc(utcNow, gmt7TimeZone);
                
                int count;
                var currentBalanceInfo = await GetBalanceInfo(id);
                if (currentBalanceInfo == null)
                {
                    currentBalanceInfo = new BalanceInfo
                    {
                        Id = id,
                        Name = name,
                        Balance = balance,
                        TodayEarn = todayEarn,
                        LastBalance = balance,
                        LastTodayEarn = todayEarn,
                        Profile = profile,
                        LastUpdate = gmt7Time
                    };
                    await _dbcontext.AddAsync(currentBalanceInfo);
                    await _dbcontext.SaveChangesAsync();
                    count = 1;
                }
                else
                {
                    count = await _dbcontext.BalanceInfos.Where(bal => bal.Id == id)
                    .ExecuteUpdateAsync(bals => bals
                    .SetProperty(bal => bal.Balance, bal => balance)
                    .SetProperty(bal => bal.TodayEarn, bal => todayEarn)
                    .SetProperty(bal => bal.Profile, bal => profile)
                    .SetProperty(bal => bal.Name, bal => name)
                    .SetProperty(bal => bal.LastBalance, bal => currentBalanceInfo.Balance)
                    .SetProperty(bal => bal.LastTodayEarn, bal => currentBalanceInfo.TodayEarn)
                    .SetProperty(bal => bal.LastUpdate, bal => gmt7Time));
                }
                await transaction.CommitAsync();
                return count;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
