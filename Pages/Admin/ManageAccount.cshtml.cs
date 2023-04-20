using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurgerWeb.Pages
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
