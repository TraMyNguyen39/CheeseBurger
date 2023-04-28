using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class CartModel : PageModel
    {
        private readonly ICartService cartService;
        public List<CartDTO> carts { get; set; }

		[BindProperty]
		public int foodId { get; set; }
		[BindProperty]
		public int quantity { get; set; }
		public string Message { get; set; }
        public CartModel (ICartService cartService)
        {
            this.cartService = cartService;
        }
        public void OnGet()
        {
			var customerID = HttpContext.Session.GetInt32("customerID");
            if (customerID != null)
            {
				carts = cartService.GetAllCarts((int)customerID);
			}
            else
			{
				RedirectToPage("/User/EmptyCart");
			}
		}
		public IActionResult OnPost([FromForm]int foodId, [FromForm]int quantity)
		{
			var customerID = HttpContext.Session.GetInt32("customerID");
			cartService.UpdateCart((int)customerID, foodId, quantity);
			return RedirectToPage("/User/Cart");
		}
		public IActionResult Removecart([FromForm] int foodId)
		{
			var customerID = HttpContext.Session.GetInt32("customerID");
			cartService.DeleteCart((int)customerID, foodId);
			return RedirectToPage("/User/Cart");
		}
	}
}