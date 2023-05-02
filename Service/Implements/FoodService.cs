using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;
using System.Globalization;

namespace CheeseBurger.Service.Implements
{
	public class FoodService : IFoodService
	{
		private readonly IFoodRepository foodRepository;
		public FoodService (IFoodRepository foodRepository)
		{
			this.foodRepository = foodRepository;
		}

		public Food GetFoodbyId(int foodId)
		{
			return foodRepository.GetFoodbyId(foodId);
		}

		public List<FoodDTO> GetFoodsMenu(int category, int priceRange, string arrange, bool isDescending, string searchText)
		{
			return foodRepository.GetFoodsMenu(category, priceRange, arrange, isDescending, searchText);
		}
	}
}
