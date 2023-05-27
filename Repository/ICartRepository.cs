using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface ICartRepository
    {
		Cart GetCartProdById(int customerID, int cartProductID);
		List<CartDTO> GetAllCarts(int customerID);
		void AddCart(int customerID, int cartProductID, int qty);
		void UpdateCart(int customerID, int cartProductID, int qty);
		void DeleteCart(int customerID, int cartProductID);
		int GetQuantityofFood(int customerID, int cartProductID);
	}
}
