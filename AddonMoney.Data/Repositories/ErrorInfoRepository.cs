using AddonMoney.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AddonMoney.Data.Repositories
{
    public class ErrorInfoRepository
    {
        private readonly AddonMoneyContext _dbcontext;

        public ErrorInfoRepository(AddonMoneyContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<PaginatedList<ErrorInfo>> GetErrors(string? host = null,
            int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbcontext.ErrorInfos.AsQueryable();
            if (!string.IsNullOrEmpty(host))
            {
                query = query.Where(err => err.Host.ToLower().Contains(host.ToLower()));
            }
            var items = await query
                .OrderBy(err => err.Host)
                .ThenByDescending(err => err.Time)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var total = await query.CountAsync();
            return new PaginatedList<ErrorInfo>(items, total, pageSize);
        }

        public async Task AddError(string host, string message)
        {
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo gmt7TimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime gmt7Time = TimeZoneInfo.ConvertTimeFromUtc(utcNow, gmt7TimeZone);
            var error = new ErrorInfo
            {
                Host = host,
                Message = message,
                Time = gmt7Time,
                Id = Guid.NewGuid()
            };
            await _dbcontext.ErrorInfos.AddAsync(error);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
