using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurgerWeb.Pages
{
    public class PaymenteModel : PageModel
    {
        private readonly ILogger<PaymenteModel> _logger;

        public PaymenteModel(ILogger<PaymenteModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}