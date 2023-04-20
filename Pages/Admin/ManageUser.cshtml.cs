using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurgerWeb.Pages
{
    public class ManageUserModel : PageModel
    {
        private readonly ILogger<ManageUserModel> _logger;

        public ManageUserModel(ILogger<ManageUserModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
