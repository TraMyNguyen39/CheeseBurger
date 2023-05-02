using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;

namespace CheeseBurger.Repository.Implements
{
	public class FoodRepository : IFoodRepository
	{
		private readonly CheeseBurgerContext context;
		public FoodRepository(CheeseBurgerContext context)
		{
			this.context = context;
		}

		public Food GetFoodbyId(int foodId)
		{
			return context.Foods.Find(foodId);
		}

		public List<FoodDTO> GetFoodsMenu(int category, int priceRange, string arrange, bool isDescending, string searchText)
		{
			var foods = context.Foods.Where(p => p.IsDeleted == false).Select(p => p);
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

			switch (arrange)
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
			/// Nhom sao trung binh theo mon an
			var groupby = context.Reviews.GroupBy(p => p.FoodID)
										 .Select(g => new
										 {
											 IDFood = g.Key,
											 Star = g.Average(p => p.Star)
										 });
			// Nhom cac bang lai roi lay ra FoodDTO
			return foods.GroupJoin(groupby, p => p.FoodID, q => q.IDFood, (p, q) => new { food = p, review = q })
						.SelectMany(foodrating => foodrating.review.DefaultIfEmpty(),
									(p, q) => new FoodDTO
									{
										IDFood = p.food.FoodID,
										NameFood = p.food.FoodName,
										ImgFood = p.food.ImageFood,
										PriceFood = p.food.Price,
										TotalRating = q.Star.ToString()
									}).ToList();
		}


	}
}
