using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class MenuModel : PageModel
    {
        private readonly IFoodService foodService;
        private readonly ICategoryService categoryService;

        [BindProperty (SupportsGet = true)]
		public List<Category> categories { get; set; }
		[BindProperty(SupportsGet = true)]
		public List<FoodDTO> foods { get; set; }

        [BindProperty]
        public int category { get; set; }

        public MenuModel (IFoodService foodService, ICategoryService categoryService)
        {
            this.foodService = foodService;
            this.categoryService = categoryService;
        }

        public void OnGet()
        {
            categories = categoryService.GetAllCategoryName();
            foods = foodService.GetFoodsMenu(category, 0, 0);
        }

        public ActionResult OnPostCategory(Category category_filter)
        {
            if (category_filter == null)
                category = 0;
            else
                category = category_filter.CategoryID;
            return Page();
        }
    }
}