using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface ICartService
    {
        Cart GetCartProdById(int customerID, int cartProductID);
		List<CartDTO> GetAllCarts(int customerID);
		void AddCart(int customerID, int cartProductID, int qty);
		void UpdateCart(int customerID, int cartProductID, int qty);
		void DeleteCart(int customerID, int cartProductID);
	}
}
