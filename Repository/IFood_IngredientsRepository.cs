using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IFood_IngredientsRepository
    {
       void AddFoodRecipe(Food_Ingredients foodIngre);
        void DeleteFoodRecipe(int foodID);
		List<object[]> GetListIngresogFood (int foodID); 
        List<Food_Ingredients> GetAllFoodRecipes(int foodID);
		void DecreaseIngre(int foodID, int qty);
	}
}
