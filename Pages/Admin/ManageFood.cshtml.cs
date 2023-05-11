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
    [Authorize("Quản trị viên","Nhân viên đầu bếp")]
    public class ManageFoodModel : PageModel
    {
		private readonly IFoodService foodService;
        private IWebHostEnvironment hostingEnvironment;

        [BindProperty(SupportsGet = true)]
		public List<AdminFoodDTO> foods { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<AdminFoodDTO> foodinclude { get; set; }

        [BindProperty(SupportsGet = true, Name = "p")]
		public int currentPage { get; set; }

		public string roleBy { get; set; }
		public string sortBy { get; set; }
		public string searchText { get; set; }
		public List<String> categoryNames { get; set; }
        public string FileName { get; set; }
        public ManageFoodModel(IFoodService foodService, IWebHostEnvironment hostingEnvironment)
		{
			this.foodService = foodService;
			this.hostingEnvironment = hostingEnvironment;
		}
		public void OnGet(int FoodID)
        {
			foods = foodService.GetFoodAdmin();
            foodinclude = foodService.GetAllFoodAdmin();

            int totalRow = foodService.getRowFood();
			categoryNames = foodService.GetNameCategories();

			this.roleBy = Request.Query["roleBy"];
			this.sortBy = Request.Query["sortBy"];
			this.searchText = Request.Query["search"];
			if (this.searchText != null) this.searchText = this.searchText.Trim();
			if (!(sortBy.IsNullOrEmpty()) || sortBy == "all")
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
        public async Task<IActionResult> OnPostCreateAsync(string Name, string combobox_Item, float Price, string Describe, IFormFile fileupload)
        {
            if (string.IsNullOrEmpty(combobox_Item))
            {
                ModelState.AddModelError("combobox_Item", "Please select a category.");
            }

            if (fileupload != null && fileupload.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileupload.FileName);
                var filePath = Path.Combine(hostingEnvironment.WebRootPath, "img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fileupload.CopyToAsync(stream);
                }

                foodService.AddData(Name, foodService.ConvertCategoryNametoCategoryId(combobox_Item), Price, Describe, fileName);
                TempData["ErrorMessage"] = $"Category with name already exists in the Categories table. Please enter a different category name.";
            }
            else
            {
                foodService.AddData(Name, foodService.ConvertCategoryNametoCategoryId(combobox_Item), Price, Describe, null);
            }

            return RedirectToPage("ManageFood");
        }
        public IActionResult OnGetFind(int id)
        {
            var ingre = foodService.FindFood(id);
            return new JsonResult(ingre);
        }
        public IActionResult OnPostDelete(int FoodId)
        {
            foodService.DeleteData(FoodId);
            return RedirectToPage("ManageFood");
        }
        public IActionResult OnPostRecycle(int FoodId)
        {
            foodService.RecycleData(FoodId);
            return RedirectToPage("ManageFood");
        }
        public async Task<IActionResult> OnPostUpdateAsync(int FoodID, string Name, string combobox_Item, float Price, string Describe, IFormFile fileupload)
        {
            if (fileupload != null && fileupload.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileupload.FileName);
                var filePath = Path.Combine(hostingEnvironment.WebRootPath, "img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fileupload.CopyToAsync(stream);
                }

                foodService.UpdateData(FoodID, Name, foodService.ConvertCategoryNametoCategoryId(combobox_Item), Price, Describe, fileName);
            }
            else
            {
                foodService.UpdateData(FoodID, Name, foodService.ConvertCategoryNametoCategoryId(combobox_Item), Price, Describe, null);
            }

            return RedirectToPage("ManageFood");
        }
    }
}
