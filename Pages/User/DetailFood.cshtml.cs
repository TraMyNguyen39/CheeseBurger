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
        [BindProperty (SupportsGet = true)]
        public bool successStatus { get; set; }

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
                    RedirectToPage("/user/menu");
                    return;
                }
                category = categoryService.GetCategorybyId((int)food.CategoryID);
                // Them ham neu xoa roi thi khong duoc mua
                reviews = reviewService.GetReviewbyFood(foodId) ?? new List<ReviewDTO>();
            }
            else
            {
                RedirectToPage("/user/menu");
            }
        }

		public IActionResult OnPost()
		{
            var customerId = HttpContext.Session.GetInt32("customerID");
			if (customerId != null && foodId != 0)
            {
                cartService.AddCart((int)customerId, foodId, qty);
				return RedirectToPage("/user/detailfood", new {id = foodId, successStatus = true});
            }
			else if (customerId == null)
			{
				return RedirectToPage("/Login/Loginregister", new { Message = "* Bạn phải đăng nhập/ đăng ký trước khi tương tác với giỏ hàng" });
			}
            else
            { 
                return RedirectToPage("/user/menu"); 
            }
		}
	}
}