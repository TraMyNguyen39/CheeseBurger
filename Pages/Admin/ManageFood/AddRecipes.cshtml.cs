using CheeseBurger.DTO;
using CheeseBurger.Middleware;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System;

namespace CheeseBurger.Pages.Admin.ManageFood
{
	public class AddRecipesModel : PageModel
	{
		private readonly IIngredientsService ingredientService;
		private readonly IFood_IngredientsService food_IngredientsService;
		private readonly IFoodService food_Service;
		[BindProperty]
		public List<IngredientDTO> ingredients { get; set; }
		[BindProperty]
		public List<IngredientDTO> ingreUsed { get; set; }
		[BindProperty]
		public List<float> qty { get; set; }
		[BindProperty]
		public List<int> ingreID { get; set; }
		[BindProperty(SupportsGet = true)]
		public int foodID { get; set; }

		public AddRecipesModel(IIngredientsService ingredientsService,
			IFood_IngredientsService food_IngredientsService, IFoodService food_Service)
		{
			ingredientService = ingredientsService;
			this.food_IngredientsService = food_IngredientsService;
			this.food_Service = food_Service;
		}

		public IActionResult OnGet()
		{
			var food = food_Service.GetFoodbyId(foodID);
			if (food != null)
			{
				// Danh sach nguyen lieu
				ingredients = ingredientService.GetListIngredients("name", false, null);
				// Nguyen lieu ban dau cho mon an
				var foodIngre = food_IngredientsService.GetAllFoodRecipes(foodID);
				// Nguyen lieu tam thoi (chua luu)
				ingreUsed = new List<IngredientDTO>();
				qty = new List<float>();
				ingreID = new List<int>();
				foreach (var i in foodIngre)
				{
					var item = ingredientService.getEachIngredient(i.IngredientsId);
					if (item != null)
					{
						ingreUsed.Add(item);
						qty.Add(i.QuantityIG);
						ingreID.Add(item.IngredientID);
					}
				}
				HttpContext.Session.SetString("FoodName", food.FoodName);
				return Page();
			}
			else
			{
				return RedirectToPage("/Error");
			}
		}
		public IActionResult OnPostSaveRecipe(int countItem, List<int> mainIngre, List<float> mainQty)
		{
			if (countItem != 0)
			{
				food_IngredientsService.DeleteFoodRecipe(foodID);
				for (var i = 0; i < countItem; i++)
				{
					ingreID.Add(mainIngre[i]);
					qty.Add(mainQty[i]);
					food_IngredientsService.AddFoodRecipe(new Food_Ingredients
					{
						FoodID = foodID,
						IngredientsId = ingreID[i],
						QuantityIG = qty[i]
					});
				}
				food_Service.UpdatePrice(foodID);
			}
			return RedirectToPage("/Admin/ManageFood/ManageFoodRecipe");
		}

		public IActionResult OnGetFind(int id)
		{
			var ingre = ingredientService.getEachIngredients(id);
			return new JsonResult(ingre);
		}
	}
}
