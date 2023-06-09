using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class EmptyCartModel : PageModel
    {
        private readonly ILogger<EmptyCartModel> _logger;

        public EmptyCartModel(ILogger<EmptyCartModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}