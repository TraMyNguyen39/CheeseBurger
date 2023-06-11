using CheeseBurger.DTO;
using CheeseBurger.Middleware;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using CheeseBurger.Service.ImplementsGetPrice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace CheeseBurger.Pages.Admin
{
    [Authorize("Quản trị viên","Nhân viên đầu bếp")]
    public class ManageCategoriesModel : PageModel
    {
		private readonly ICategoryService categoryService;
		[BindProperty(SupportsGet = true)]
		public List<CategoryDTO> categories { get; set; }
		public List<CategoryDTO> categoriesAll { get; set; }
		public List<Food> foods { get; set; }
        public List<String> foodName { get; set; }
        [BindProperty(SupportsGet = true, Name = "p")]
		public int currentPage { get; set; }
		public string sortBy { get; set; }
		public string searchText { get; set; }
        public string ModalAddName { get; set; }
		public string MessageCate { get; set; }
		public ManageCategoriesModel(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}
		public void OnGet(int CategoryID)
        {
			categories = categoryService.GetCategory();
			int totalRow = categoryService.getRowCategory();

			this.sortBy = Request.Query["sortBy"];
			if (sortBy == "all")
			{
				categories = categoryService.GetListCategories(null, true);
			}
			else if (!(sortBy.IsNullOrEmpty()))
			{
				string[] values = sortBy.Split('-');
				string arrange = values[0];
				bool isDescending = (values[1] == "desc");
				categories = categoryService.GetListCategories(arrange, isDescending);
			}
			else
			{
				categories = categoryService.GetListCategories(null, true);
			}
			if (categories.Count == 0)
			{
				MessageCate = "Không có nguyên liệu nào đáp ứng điều kiện!";
			}
			else { MessageCate = null; }
		}
        public IActionResult OnPostCreate(string Name)
        {
            
            categoryService.AddData(Name);
            return RedirectToPage("/Admin/ManageCategories");
        }
        public IActionResult OnGetFind(int id)
        {
            var ingre = categoryService.FindCategories(id);
            return new JsonResult(ingre);
        }
        public IActionResult OnPostUpdate(int CategoriesID, string Name)
        {
            categoryService.UpdateData(CategoriesID, Name);
            return RedirectToPage("/Admin/ManageCategories");
        }
        public IActionResult OnPostDelete(int CategoriesID)
        {
            categoryService.DeleteData(CategoriesID);
            return RedirectToPage("/Admin/ManageCategories");
        }

        public IActionResult OnGetCategories(int id)
		{
            foods = categoryService.GetByCategoryID(id);
            return new JsonResult(foods);
        }
    }
}
