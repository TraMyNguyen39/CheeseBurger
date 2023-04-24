using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class DetailFoodModel : PageModel
    {
        private readonly ILogger<DetailFoodModel> _logger;

        public DetailFoodModel(ILogger<DetailFoodModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}