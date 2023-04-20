using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages.Admin
{
    public class ChangePasswordAdminModel : PageModel
    {
        private readonly ILogger<ChangePasswordAdminModel> _logger;

        public ChangePasswordAdminModel(ILogger<ChangePasswordAdminModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
