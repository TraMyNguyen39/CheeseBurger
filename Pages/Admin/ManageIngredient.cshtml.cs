using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurgerWeb.Pages.Admin
{
    public class ManageIngredientModel : PageModel
    {
        private readonly ILogger<ManageIngredientModel> _logger;

        public ManageIngredientModel(ILogger<ManageIngredientModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
