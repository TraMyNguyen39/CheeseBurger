using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurgerWeb
{
    public class SyncRevenueModel : PageModel
    {
        private readonly ILogger<SyncRevenueModel> _logger;

        public SyncRevenueModel(ILogger<SyncRevenueModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
