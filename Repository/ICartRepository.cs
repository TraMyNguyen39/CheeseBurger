using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface ICartRepository
    {
		Cart GetCartProdById(int customerID, int cartProductID);
		void AddCart(int customerID, int cartProductID, int qty);
	}
}
