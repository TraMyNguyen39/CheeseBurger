using CheeseBurger.DTO;
using CheeseBurger.Model;

namespace CheeseBurger.Repository.Implements
{
    public class IngredientsRespository : IIngredientsRespository
    {
		private readonly CheeseBurgerContext context;

		public IngredientsRespository(CheeseBurgerContext context)
		{
			this.context = context;
		}


		public List<IngredientDTO> GetIngredients(string ingredientName)
		{
			if (ingredientName != null)
			{
				return context.Ingredients.Where(p => p.IngredientsName.Contains(ingredientName))
							  .Select(p => new IngredientDTO { IngredientID = p.IngredientsId, IngredientName = p.IngredientsName, IngredientInputPrice = p.IngredientsPrice, MeasureName = p.Measure.MeasureName }).ToList();
			}
			else
			{
				return context.Ingredients.Select(p => new IngredientDTO { IngredientID = p.IngredientsId, IngredientName = p.IngredientsName, IngredientInputPrice = p.IngredientsPrice, MeasureName = p.Measure.MeasureName }).ToList();
			}
		}

		public List<IngredientDTO> ArrangeIngredients(string ingredientName, string arrange, bool isDescending)
		{
			List<IngredientDTO> data = GetIngredients(ingredientName);
			if (arrange == "")
			{
				data = data.OrderBy(p => p.IngredientID).ToList();
			}
			else
			{
				data = isDescending ? data.OrderByDescending(p => p.IngredientName).ToList() : data.OrderBy(p => p.IngredientName).ToList();
			}
			return data;
		}

		public IngredientDTO getEachIngredient(int ingredientID)
		{
			return context.Ingredients.Where(p => p.IngredientsId.Equals(ingredientID))
				.Select(p => new IngredientDTO { IngredientID = p.IngredientsId, IngredientName = p.IngredientsName, IngredientInputPrice = p.IngredientsPrice, MeasureName = p.Measure.MeasureName })
				.FirstOrDefault();
		}

		public void AddData()
		{

		}
	}
}
