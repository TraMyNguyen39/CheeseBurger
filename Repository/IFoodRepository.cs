using CheeseBurger.DTO;

namespace CheeseBurger.Repository
{
    public interface IFoodRepository
    {
		List<FoodDTO> GetFoodsMenu(int category, int priceRange, int sortBy);
	}
}
