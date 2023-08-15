using AddonMoney.Data.API;
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
            string? vpsname = null,
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

            if (!string.IsNullOrEmpty(vpsname))
            {
                query = query.Where(bal => bal.VPS.ToLower().Contains(vpsname.ToLower()));
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

        public async Task<int> UpdateBalance(UpdateBalanceRequest balRq)
        {
            using var transaction = await _dbcontext.Database.BeginTransactionAsync();
            try
            {
                DateTime utcNow = DateTime.Now;
                TimeZoneInfo gmt7TimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                DateTime gmt7Time = TimeZoneInfo.ConvertTimeFromUtc(utcNow, gmt7TimeZone);

                int count;
                var currentBalanceInfo = await GetBalanceInfo(balRq.Id);
                if (currentBalanceInfo == null)
                {
                    currentBalanceInfo = new BalanceInfo
                    {
                        Id = balRq.Id,
                        Name = balRq.Name,
                        Balance = balRq.Balance,
                        TodayEarn = balRq.TodayEarn,
                        LastBalance = 0,
                        LastTodayEarn = 0,
                        Profile = balRq.Profile,
                        LastUpdate = gmt7Time,
                        VPS = balRq.VPS,
                        Email = balRq.Email,
                        EarningLevel = balRq.EarningLevel
                    };
                    await _dbcontext.AddAsync(currentBalanceInfo);
                    await _dbcontext.SaveChangesAsync();
                    count = 1;
                }
                else
                {
                    count = await _dbcontext.BalanceInfos.Where(bal => bal.Id == balRq.Id)
                    .ExecuteUpdateAsync(bals => bals
                    .SetProperty(bal => bal.Balance, bal => balRq.Balance)
                    .SetProperty(bal => bal.TodayEarn, bal => balRq.TodayEarn)
                    .SetProperty(bal => bal.Profile, bal => balRq.Profile)
                    .SetProperty(bal => bal.Name, bal => balRq.Name)
                    .SetProperty(bal => bal.LastBalance, bal => currentBalanceInfo.Balance)
                    .SetProperty(bal => bal.LastTodayEarn, bal => currentBalanceInfo.TodayEarn)
                    .SetProperty(bal => bal.VPS, bal => balRq.VPS)
                    .SetProperty(bal => bal.EarningLevel, bal => balRq.EarningLevel)
                    .SetProperty(bal => bal.Email, bal => balRq.Email)
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

        public async Task UpdateProxyStatus(UpdateProxyStatusRequest rq)
        {
            _ = await _dbcontext.BalanceInfos.Where(bal => bal.Email == rq.Email)
                .ExecuteUpdateAsync(bals => bals.SetProperty(bal => bal.ProxyDie, rq.ProxyDie));
        }

        public async Task<int> TotalToday()
        {
            DateTime utcNow = DateTime.Now;
            TimeZoneInfo gmt7TimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime gmt7Time = TimeZoneInfo.ConvertTimeFromUtc(utcNow, gmt7TimeZone);

            return await _dbcontext.BalanceInfos
                .Where(b => b.LastUpdate.Date == gmt7Time.Date)
                .SumAsync(b => b.TodayEarn);
        }

        public async Task<int> TotalBalance()
        {
            return await _dbcontext.BalanceInfos.SumAsync(b => b.Balance);
        }
    }
}
