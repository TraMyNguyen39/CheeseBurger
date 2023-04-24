using CheeseBurger.DTO;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class FoodService : IFoodService
	{
		private readonly IFoodRepository foodRepository;
		public FoodService (IFoodRepository foodRepository)
		{
			this.foodRepository = foodRepository;
		}
		public List<FoodDTO> GetFoodsMenu(int category, int priceRange, int sortBy)
		{
			return foodRepository.GetFoodsMenu(category, priceRange, sortBy);
		}
	}
}
