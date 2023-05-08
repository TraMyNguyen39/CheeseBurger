using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Globalization;

namespace CheeseBurger.Pages.Admin
{
	public class ManageIngredientModel : PageModel
	{
		private readonly IIngredientsService ingredientService;
		[BindProperty(SupportsGet = true)]
		public List<IngredientDTO> ingredients { get; set; }
		[BindProperty(SupportsGet = true)]
		public IngredientDTO ingredient { get; set; }

		[BindProperty(SupportsGet = true)]
		public List<string> measureName { get; set; }

		[BindProperty(SupportsGet = true)]
		public int measureId { get; set; }
		public ManageIngredientModel(IIngredientsService ingredientsService)
		{
			this.ingredientService = ingredientsService;
		}

		[BindProperty(SupportsGet = true, Name = "p")]
		public int currentPage { get; set; }
		public string sortBy { get; set; }
		public string searchText { get; set; }
		public List<Ingredients> ingredientes { get; set; }
		public string ExistError { get; set; }

		public void OnGet(int IngredientID, string IngredientName)
		{
			ingredients = ingredientService.GetIngredients(IngredientName);

			// paging
			int totalRow = ingredientService.getRowIngredient();

			// GetIngredient
			measureName = ingredientService.getIngredientName();
			ingredient = ingredientService.getEachIngredient(IngredientID);

			this.sortBy = Request.Query["sortBy"];
			this.searchText = Request.Query["search"];
			if (this.searchText != null) this.searchText = this.searchText.Trim();
			if (!(sortBy.IsNullOrEmpty()) || sortBy == "all")
			{
				string[] values = sortBy.Split('-');
				string arrange = values[0];
				bool isDescending = (values[1] == "desc");
				ingredients = ingredientService.GetListIngredients(arrange, isDescending, searchText);
			}
			else
			{
				ingredients = ingredientService.GetListIngredients(null, true, searchText);
			}
		}
        public IActionResult OnPostCreate(string Name, string combobox_Item, float Price)
        {
			//if (string.IsNullOrEmpty(combobox_Item))
			//{
			//    ModelState.AddModelError("combobox_Item", "Please select a measure.");
			//}
			ingredientService.AddData(Name, ingredientService.ConvertMeasureNametoMeasureId(combobox_Item), Price);
            return RedirectToPage("ManageIngredient");
        }

        public IActionResult OnPostDelete(int IngredientID)
		{
			ingredientService.DeleteData(IngredientID);
			return RedirectToPage("ManageIngredient");
		}

        public IActionResult OnGetFind(int id)
		{
			var ingre = ingredientService.FindIngredient(id);
			return new JsonResult(ingre);
		}

		public IActionResult OnPostUpdate(int IngredientID, string Name, string combobox_Item, float Price)
		{
			if (string.IsNullOrEmpty(combobox_Item))
			{
				ModelState.AddModelError("combobox_Item", "Please select a measure.");
			}
			ingredientService.UpdateData(IngredientID, Name, ingredientService.ConvertMeasureNametoMeasureId(combobox_Item), Price);
			return RedirectToPage("ManageIngredient");
		}
	}
}
