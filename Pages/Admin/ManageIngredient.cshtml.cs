using CheeseBurger.DTO;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages.Admin
{
    public class ManageIngredientModel : PageModel
    {
		private readonly IIngredientsService ingredientService;

		[BindProperty(SupportsGet = true)]
		public List<IngredientDTO> ingredients { get; set; }
		[BindProperty(SupportsGet = true)]
		public IngredientDTO ingredient { get; set; }

		public ManageIngredientModel(IIngredientsService ingredientsService)
		{
			this.ingredientService = ingredientsService;
		}

		public void OnGet(int IngredientID, string IngredientName, string arrange, bool isDescending)
		{
			ingredients = ingredientService.ArrangeIngredients(IngredientName, arrange, isDescending);
			if (IngredientID != 0) // Add a null check
			{
				ingredient = ingredientService.getEachIngredient(IngredientID);
			}
		}

		public void OnPost(int IngredientID, string IngredientName, string combobox_Item)
		{
			string[] values = combobox_Item.Split('-');
			string arrange = values[0];
			bool isDescending = (values[1] == "desc");

			// call the ArrangeIngredients method with the selected arrange and isDescending values
			ingredients = ingredientService.ArrangeIngredients(IngredientName, arrange, isDescending);
			ingredient = ingredientService.getEachIngredient(IngredientID);
		}
	}
}
