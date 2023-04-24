using CheeseBurger.DTO;

namespace CheeseBurger.Service
{
    public interface IIngredientsService
    {
		List<IngredientDTO> GetIngredients(string ingredientName);
		List<IngredientDTO> ArrangeIngredients(string ingredientName, string arrange, bool isDescending);
		IngredientDTO getEachIngredient(int ingredientID);
	}
}
