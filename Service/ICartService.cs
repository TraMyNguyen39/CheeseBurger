using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface ICartService
    {
        Cart GetCartProdById(int customerID, int cartProductID);
        void AddCart(int customerID, int cartProductID, int qty);
	}
}
