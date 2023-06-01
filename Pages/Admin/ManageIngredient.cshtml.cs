using CheeseBurger.DTO;
using CheeseBurger.Middleware;
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
	[Authorize("Quản trị viên", "Nhân viên đầu bếp")]
	public class ManageIngredientModel : PageModel
	{
		private readonly IIngredientsService ingredientService;
		private readonly IPartnerService partnerService;
		[BindProperty(SupportsGet = true)]
		public List<IngredientDTO> ingredients { get; set; }
		[BindProperty(SupportsGet = true)]
		public IngredientDTO ingredient { get; set; }

		[BindProperty(SupportsGet = true)]
		public List<string> measureName { get; set; }
		[BindProperty(SupportsGet = true)]
		public List<CBBPartnerDTO> partner { get; set; }

		[BindProperty(SupportsGet = true)]
		public int measureId { get; set; }
		public ManageIngredientModel(IIngredientsService ingredientsService, IPartnerService partnerService)
		{
			this.ingredientService = ingredientsService;
			this.partnerService = partnerService;
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
			partner = partnerService.GetPartnerNames();
			ingredient = ingredientService.getEachIngredient(IngredientID);

			this.sortBy = Request.Query["sortBy"];
			this.searchText = Request.Query["search"];
			if (this.searchText != null)
			{
				this.searchText = this.searchText.Trim();
				searchText.Replace("%20", " ");
			}
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
		public IActionResult OnPostCreate(string Name, string combobox_Item, float Price, int ncc)
		{
			//if (string.IsNullOrEmpty(combobox_Item))
			//{
			//    ModelState.AddModelError("combobox_Item", "Please select a measure.");
			//}
			ingredientService.AddData(Name, ingredientService.ConvertMeasureNametoMeasureId(combobox_Item), Price, ncc);
			return RedirectToPage("ManageIngredient");
		}

		public IActionResult OnPostDelete(int IngredientID)
		{
			ingredientService.DeleteData(IngredientID);
			return RedirectToPage("ManageIngredient");
		}

		public IActionResult OnGetFind(int id)
		{
			var ingre = ingredientService.getEachIngredient(id);
			return new JsonResult(ingre);
		}

		public IActionResult OnPostUpdate(int IngredientID, string Name, string combobox_Item, float Price, int ncc, float nlHong)
		{
			if (string.IsNullOrEmpty(combobox_Item))
			{
				ModelState.AddModelError("combobox_Item", "Please select a measure.");
			}
			if (nlHong != 0)
				ingredientService.UpdateData(IngredientID, Name, ingredientService.ConvertMeasureNametoMeasureId(combobox_Item), Price, ncc, nlHong);
			else
				ingredientService.UpdateData(IngredientID, Name, ingredientService.ConvertMeasureNametoMeasureId(combobox_Item), Price, ncc);
			return RedirectToPage("ManageIngredient");
		}
	}
}
