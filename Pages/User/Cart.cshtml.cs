using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurgerWeb.Pages
{
    public class CartModel : PageModel
    {
        private readonly ILogger<CartModel> _logger;

        public CartModel(ILogger<CartModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}