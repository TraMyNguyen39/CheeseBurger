using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurgerWeb.Pages
{
    public class LoginRegisterModel : PageModel
    {
        private readonly ILogger<LoginRegisterModel> _logger;

        public LoginRegisterModel(ILogger<LoginRegisterModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}