using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages.Admin
{
    public class ImportOrderDetailModel : PageModel
    {
        private readonly ILogger<ImportOrderDetailModel> _logger;

        public ImportOrderDetailModel(ILogger<ImportOrderDetailModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
