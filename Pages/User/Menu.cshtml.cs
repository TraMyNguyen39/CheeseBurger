using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System;

namespace CheeseBurger.Pages
{
    public class MenuModel : PageModel
    {
        private readonly IFoodService foodService;
        private readonly ICategoryService categoryService;
		private readonly ICartService cartService;
		public List<Category> categories { get; set; }
		public List<FoodDTO> foods { get; set; }

        public string categoryID { get; set; }
		public string priceRange { get; set; }
		public string sortBy { get; set; }
		public string searchText { get; set; }

        [BindProperty]
        public int cartProductID { get; set; }
		public string Message { get; set; }
		[BindProperty (SupportsGet = true)]
		public bool successfulStatus { get; set; }
		public MenuModel (IFoodService foodService, ICategoryService categoryService, ICartService cartService)
        {
            this.foodService = foodService;
            this.categoryService = categoryService;
			this.cartService = cartService;
        }

        public void OnGet()
        {
			this.categories = categoryService.GetAllCategory();
			this.searchText = Request.Query["search"];
			this.categoryID = Request.Query["category"];
			this.priceRange = Request.Query["price"];
            this.sortBy = Request.Query["sortBy"];

			if (this.searchText != null) 
				this.searchText = this.searchText.Trim();
			
			var category = !(Int32.TryParse(this.categoryID, out int categoryID)) ? 0 : categoryID;
			var price = !(Int32.TryParse(this.priceRange, out int priceRange)) ? 0 : priceRange;
			
			if (!(sortBy.IsNullOrEmpty() || sortBy == "all"))
            {
				string[] values = sortBy.Split('-');
				string arrange = values[0];
				bool isDescending = (values[1] == "desc");
				foods = foodService.GetFoodsMenu(category, priceRange, arrange, isDescending, searchText);
			}
			else
            {
				foods = foodService.GetFoodsMenu(category, price, null, true, searchText);
			}

            if (foods.Count == 0)
            {
                Message = "Không có sản phẩm nào đáp ứng điều kiện!";
            }
            else { Message = null; }
        }
		public IActionResult OnPost()
		{
			var customerID = HttpContext.Session.GetInt32("customerID");
			if (customerID != null)
			{
				//Add sản phẩm vào cart
				cartService.AddCart((int)customerID, cartProductID, 1);
				return RedirectToPage("/User/Menu", new { successfulStatus = true });
			}
			else
			{
				return RedirectToPage("/Login/Loginregister", new { Message = "* Bạn phải đăng nhập/ đăng ký trước khi tương tác với giỏ hàng" });
			}
		}
	}
}