using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurgerWeb.Pages
{
    public class SuccessfulValidateModel : PageModel
    {
        private readonly ILogger<SuccessfulValidateModel> _logger;

        public SuccessfulValidateModel(ILogger<SuccessfulValidateModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}