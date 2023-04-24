using CheeseBurger.DTO;

namespace CheeseBurger.Repository
{
    public interface IIngredientsRespository
    {
		List<IngredientDTO> GetIngredients(string ingredientName);
		List<IngredientDTO> ArrangeIngredients(string ingredientName, string arrange, bool isDescending);
		IngredientDTO getEachIngredient(int ingredientID);
	}
}
