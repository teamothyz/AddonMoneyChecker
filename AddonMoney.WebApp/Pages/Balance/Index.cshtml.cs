using AddonMoney.Data;
using AddonMoney.Data.Models;
using AddonMoney.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace AddonMoney.WebApp.Pages.Balance
{
    public class IndexModel : PageModel
    {
        private readonly BalanceInfoRepository _balanceInfoRepository;
        private readonly string _logPrefix = "[Balance-IndexModel]";

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        [BindProperty(SupportsGet = true)]
        public string NameFilter { get; set; } = null!;

        [BindProperty(SupportsGet = true)]
        public string IdFilter { get; set; } = null!;

        [BindProperty(SupportsGet = true)]
        public string VPSFilter { get; set; } = null!;

        public PaginatedList<BalanceInfo> BalanceInfos = new();

        public string Error { get; set; } = null!;

        public int TotalEarn { get; set; }

        public int TotalBalance { get; set; }

        public IndexModel(BalanceInfoRepository balanceInfoRepository)
        {
            _balanceInfoRepository = balanceInfoRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                int? id = null;
                var validId = int.TryParse(IdFilter, out int idTemp);
                if (validId) id = idTemp;
                else IdFilter = null!;

                BalanceInfos = await _balanceInfoRepository.GetBalanceInfos(id, NameFilter, VPSFilter, PageIndex, PageSize);
                TotalEarn = await _balanceInfoRepository.TotalToday();
                TotalBalance = await _balanceInfoRepository.TotalBalance();
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Got exception when getting balance list.", ex);
                Error = ex.Message;
            }
            return Page();
        }
    }
}
