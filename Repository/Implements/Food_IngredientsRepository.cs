using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
    public class Food_IngredientsRepository : IFood_IngredientsRepository
    {
        private readonly CheeseBurgerContext context;
        public Food_IngredientsRepository (CheeseBurgerContext context)
        {
            this.context = context;
        }

		public void AddFoodRecipe(Food_Ingredients foodIngre)
		{
			context.Food_Ingredients.Add(foodIngre);
			context.SaveChanges();
		}
		public void DeleteFoodRecipe(int foodID)
		{
			var recipe = GetAllFoodRecipes(foodID);
			if (recipe != null)
			{
				context.Food_Ingredients.RemoveRange(recipe);
				context.SaveChanges();
			}
		}

		public void DecreaseIngre(int foodID, int qty)
		{
			var recipes = GetAllFoodRecipes(foodID);
			foreach (var item in recipes)
			{
				var ingre = context.Ingredients.Where(p => p.IngredientsId == item.IngredientsId).FirstOrDefault();
				ingre.IngredientsQty -= item.QuantityIG * qty;
				context.SaveChanges();
			}
		}

		public List<Food_Ingredients> GetAllFoodRecipes(int foodID)
		{
			return context.Food_Ingredients.Where(p => p.FoodID == foodID).ToList();
		}

		public List<object[]> GetListIngresogFood(int foodID)
		{
			return context.Food_Ingredients.Where(p => p.FoodID == foodID)
											.Select(p => new object[] { p.IngredientsId, p.QuantityIG, p.Ingredients.IngredientsQty })
											.ToList();
		}
	}
}
