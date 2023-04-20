using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class ManageAccountModel : PageModel
    {
        private readonly ILogger<ManageAccountModel> _logger;

        public ManageAccountModel(ILogger<ManageAccountModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
