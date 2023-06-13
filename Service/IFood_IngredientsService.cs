using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface IFood_IngredientsService
    {
		public void AddFoodRecipe(Food_Ingredients foodIngre);
		public void DeleteFoodRecipe(int foodID);
        public List<Food_Ingredients> GetAllFoodRecipes(int foodID);
		void DecreaseIngre(int foodID, int qty);
		void IncreaseIngre(int foodID, int qty);
	}
}
