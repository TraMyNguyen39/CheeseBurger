using CheeseBurger.DTO;

namespace CheeseBurger.Service
{
    public interface IFoodService
    {
        List<FoodDTO> GetFoodsMenu(int category, int priceRange ,int sortBy);
    }
}
