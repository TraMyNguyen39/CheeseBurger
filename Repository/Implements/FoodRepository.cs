using CheeseBurger.DTO;
using CheeseBurger.Model;

namespace CheeseBurger.Repository.Implements
{
	public class FoodRepository : IFoodRepository
	{
		private readonly CheeseBurgerContext context;
		public FoodRepository (CheeseBurgerContext context)
		{
			this.context = context;
		}
		public List<FoodDTO> GetFoodsMenu(int category, int priceRange, int sortBy)
		{
			if (category != 0)
				return context.Foods.Where(p => p.CategoryID == category)
								.Select(p => new FoodDTO {IDFood = p.FoodID, NameFood = p.FoodName, PriceFood = p.Price, ImgFood = p.ImageFood})
								.ToList();
			else return context.Foods.Select(p => new FoodDTO { IDFood = p.FoodID, NameFood = p.FoodName, PriceFood = p.Price, ImgFood = p.ImageFood }).ToList();
		}
	}
}
