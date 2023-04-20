using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages.Admin
{
    public class ManageCategoriesModel : PageModel
    {
        private readonly ILogger<ManageCategoriesModel> _logger;

        public ManageCategoriesModel(ILogger<ManageCategoriesModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
