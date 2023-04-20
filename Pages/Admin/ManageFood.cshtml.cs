using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class ManageFoodModel : PageModel
    {
        private readonly ILogger<ManageFoodModel> _logger;

        public ManageFoodModel(ILogger<ManageFoodModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
