using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IFood_IngredientsRepository
    {
        public void AddFoodRecipe(Food_Ingredients foodIngre);
        public void DeleteFoodRecipe(int foodID);
        public List<Food_Ingredients> GetAllFoodRecipes(int foodID);
	}
}
