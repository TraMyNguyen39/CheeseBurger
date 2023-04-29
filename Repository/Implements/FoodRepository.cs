using CheeseBurger.DTO;
using CheeseBurger.Model;
using Microsoft.IdentityModel.Tokens;

namespace CheeseBurger.Repository.Implements
{
	public class FoodRepository : IFoodRepository
	{
		private readonly CheeseBurgerContext context;
		public FoodRepository (CheeseBurgerContext context)
		{
			this.context = context;
		}

		public List<FoodDTO> GetFoodsMenu(int category, int priceRange, string arrange, bool isDescending, string searchText)
		{
			var foods = context.Foods.Select(p => p);
			if (category != 0)
				foods = foods.Where(p => p.CategoryID == category).Select(p => p);

			switch (priceRange)
			{
				case 1:
					foods = foods.Where(p => p.Price >= 0 && p.Price <= 20000).Select(p => p);
					break;
				case 2:
					foods = foods.Where(p => p.Price >= 20000 && p.Price <= 50000).Select(p => p);
					break;
				case 3:
					foods = foods.Where(p => p.Price >= 50000 && p.Price <= 70000).Select(p => p);
					break;
				case 4:
					foods = foods.Where(p => p.Price >= 70000 && p.Price <= 100000).Select(p => p);
					break;
			}
			
			switch(arrange)
			{
				case "name":
					foods = isDescending ? foods.OrderByDescending(p => p.FoodName) : foods.OrderBy(p => p.FoodName);
					break;
				case "price":
					foods = isDescending ? foods.OrderByDescending(p => p.Price) : foods.OrderBy(p => p.Price);
					break;
			}
			
			if (!searchText.IsNullOrEmpty())
			{
				foods = foods.Where(p => p.FoodName.Contains(searchText)).Select(p => p);
			}	

			return foods.Select(p => new FoodDTO { IDFood = p.FoodID, NameFood = p.FoodName, PriceFood = p.Price, ImgFood = p.ImageFood }).ToList();
		}
	}
}
