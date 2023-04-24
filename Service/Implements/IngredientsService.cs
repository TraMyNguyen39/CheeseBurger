using CheeseBurger.DTO;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
    public class IngredientsService : IIngredientsService
    {
		private readonly IIngredientsRespository ingredientsRespository;
		public IngredientsService(IIngredientsRespository ingredientsRespository)
		{
			this.ingredientsRespository = ingredientsRespository;
		}

		public List<IngredientDTO> GetIngredients(string ingredientName)
		{
			return ingredientsRespository.GetIngredients(ingredientName);
		}

		public List<IngredientDTO> ArrangeIngredients(string ingredientName, string arrange, bool isDescending)
		{
			return ingredientsRespository.ArrangeIngredients(ingredientName, arrange, isDescending);
		}

		public IngredientDTO getEachIngredient(int ingredientID)
		{
			return ingredientsRespository.getEachIngredient(ingredientID);
		}
	}
}
