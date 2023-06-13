using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class DetailFoodModel : PageModel
    {
        private readonly IFoodService foodService;
        private readonly ICategoryService categoryService;
        private readonly ICartService cartService;
        private readonly IReviewService reviewService;
        public Food food { get; set; }
        public Category category { get; set; }
        public List<ReviewDTO> reviews { get; set; }
        [BindProperty]
        public int qty { get; set; }
		[BindProperty (SupportsGet = true)]
		public int foodId { get; set; }
        [TempData]		
		public string ProductInfo { get; set; }
		public int maxQty { get; set; }
        public int cartQty { get; set; }
        public DetailFoodModel (ICategoryService categoryService, IFoodService foodService, ICartService cartService, IReviewService reviewService)
        {
            this.categoryService = categoryService;
            this.foodService = foodService;
            this.cartService = cartService;
            this.reviewService = reviewService;
        }
        public void OnGet()
        {
            foodId = Int32.TryParse(Request.Query["id"], out int id) ? id : 0;
            if (foodId != 0)
            {
                food = foodService.GetFoodbyId(foodId);
                if (food == null)
                {
                    RedirectToPage("/User/Food/Menu");
                    return;
                }
				maxQty = foodService.GetMaxQuantityofFood(foodId);
				category = categoryService.GetCategorybyId((int)food.CategoryID);
                // Them ham neu xoa roi thi khong duoc mua
                reviews = reviewService.GetReviewbyFood(foodId) ?? new List<ReviewDTO>();
            }
            else
            {
                RedirectToPage("/User/Food/Menu");
            }
        }

		public IActionResult OnPost()
		{
            var customerId = HttpContext.Session.GetInt32("customerID");
			if (customerId != null && foodId != 0)
            {
				var cartQty = cartService.GetQuantityofFood((int)customerId, foodId);
				var maxFoodQty = foodService.GetMaxQuantityofFood(foodId);
				if (cartQty + qty <= maxFoodQty)
				{
					//Add sản phẩm vào cart
					cartService.AddCart((int)customerId, foodId, qty);
					ProductInfo = "Đã thêm món ăn vào giỏ hàng";
				}
				else
				{
					cartService.AddCart((int)customerId, foodId, maxFoodQty - cartQty);
					ProductInfo = "Món ăn chỉ còn " + maxFoodQty + " sản phẩm. Đã thêm " + (maxFoodQty - cartQty) + " sản phẩm vào giỏ hàng";
				}
				return RedirectToPage("/User/Food/DetailFood", new {id = foodId});
            }
			else if (customerId == null)
			{
				return RedirectToPage("/Login/LoginRegister", new { Message = "* Bạn phải đăng nhập/ đăng ký trước khi tương tác với giỏ hàng" });
			}
            else
            { 
                return RedirectToPage("/User/Food/Menu"); 
            }
		}
	}
}