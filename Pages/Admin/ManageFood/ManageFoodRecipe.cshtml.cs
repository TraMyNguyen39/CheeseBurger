using CheeseBurger.DTO;
using CheeseBurger.Middleware;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace CheeseBurger.Pages.Admin
{
    [Authorize("Nhân viên đầu bếp")]
	public class ManageFoodRecipeModel : PageModel
    {
		private readonly IFoodService foodService;
        private IWebHostEnvironment hostingEnvironment;

        [BindProperty(SupportsGet = true)]
		public List<AdminFoodDTO> foods { get; set; }

        [BindProperty(SupportsGet = true, Name = "p")]
		public int currentPage { get; set; }

		public string roleBy { get; set; }
		public string sortBy { get; set; }
		public string searchText { get; set; }
		public List<String> categoryNames { get; set; }
        public string FileName { get; set; }
        public ManageFoodRecipeModel(IFoodService foodService, IWebHostEnvironment hostingEnvironment)
		{
			this.foodService = foodService;
			this.hostingEnvironment = hostingEnvironment;
		}
		public void OnGet(int FoodID)
        {
			foods = foodService.GetFoodAdmin();

            int totalRow = foodService.getRowFood();
			categoryNames = foodService.GetNameCategories();

			this.roleBy = Request.Query["roleBy"];
			this.sortBy = Request.Query["sortBy"];
			this.searchText = Request.Query["search"];
			if (this.searchText != null) this.searchText = this.searchText.Trim();
			if (!(sortBy.IsNullOrEmpty() || sortBy == "all"))
			{
				string[] values = sortBy.Split('-');
				string arrange = values[0];
				bool isDescending = (values[1] == "desc");
				foods = foodService.GetListFoods(roleBy, arrange, isDescending, searchText);
			}
			else
			{
				foods = foodService.GetListFoods(roleBy, null, true, searchText);
			}
		}
    }
}
