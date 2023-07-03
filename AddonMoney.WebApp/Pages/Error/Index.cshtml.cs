using AddonMoney.Data.Models;
using AddonMoney.Data.Repositories;
using AddonMoney.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace AddonMoney.WebApp.Pages.Error
{
    public class IndexModel : PageModel
    {
        private readonly ErrorInfoRepository _errorInfoRepository;
        private readonly string _logPrefix = "[Error-IndexModel]";

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        [BindProperty(SupportsGet = true)]
        public string HostFilter { get; set; } = null!;

        public PaginatedList<ErrorInfo> ErrorInfos = new();

        public string Error { get; set; } = null!;

        public IndexModel(ErrorInfoRepository errorInfoRepository)
        {
            _errorInfoRepository = errorInfoRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                ErrorInfos = await _errorInfoRepository.GetErrors(HostFilter, PageIndex, PageSize);
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Got exception when getting errors list.", ex);
                Error = ex.Message;
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                await _errorInfoRepository.DeleteAll();
            }
            catch (Exception ex)
            {
                Log.Error($"{_logPrefix} Got exception when deleting errors list.", ex);
                Error = ex.Message;
            }
            return Page();
        }
    }
}
