using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class CartService : ICartService
	{
		private readonly ICartRepository cartRepository;
		public CartService(ICartRepository cartRepository)
		{
			this.cartRepository = cartRepository;
		}
		public Cart GetCartProdById(int customerID, int cartProductID)
		{
			return cartRepository.GetCartProdById( customerID,  cartProductID);
		}
		public void AddCart(int customerID, int cartProductID, int qty)
		{
			cartRepository.AddCart(customerID, cartProductID, qty);
		}
	}
}
