using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class SuccesfulValide1Model : PageModel
    {
        private readonly ILogger<SuccesfulValide1Model> _logger;

        public SuccesfulValide1Model(ILogger<SuccesfulValide1Model> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}