using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
    public class Food_IngredientsService : IFood_IngredientsService
    {
        public IFood_IngredientsRepository Food_IngredientsRepository;
        public Food_IngredientsService(IFood_IngredientsRepository food_IngredientsRepository)
        {
            this.Food_IngredientsRepository = food_IngredientsRepository;
        }

		public void AddFoodRecipe(Food_Ingredients foodIngre)
		{
			Food_IngredientsRepository.AddFoodRecipe(foodIngre);
		}

		public void DeleteFoodRecipe(int foodID)
		{
			Food_IngredientsRepository.DeleteFoodRecipe(foodID);
		}

		public List<Food_Ingredients> GetAllFoodRecipes(int foodID)
		{
			return Food_IngredientsRepository.GetAllFoodRecipes(foodID);
		}
	}
}
