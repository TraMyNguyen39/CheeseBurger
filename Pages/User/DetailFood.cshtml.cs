using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurgerWeb.Pages
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