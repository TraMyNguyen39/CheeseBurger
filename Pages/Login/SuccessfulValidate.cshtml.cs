using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class SuccesfulValideModel : PageModel
    {
        private readonly ILogger<SuccesfulValideModel> _logger;

        public SuccesfulValideModel(ILogger<SuccesfulValideModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}