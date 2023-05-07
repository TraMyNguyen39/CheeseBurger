using CheeseBurger.DTO;
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

		public List<CartDTO> GetAllCarts(int customerID)
		{
			return cartRepository.GetAllCarts(customerID);
		}

		public void UpdateCart(int customerID, int cartProductID, int qty)
		{
			cartRepository.UpdateCart(customerID, cartProductID, qty);
		}

		public void DeleteCart(int customerID, int cartProductID)
		{
			cartRepository.DeleteCart(customerID, cartProductID);
		}

        public double GetCartTotal(List<CartDTO> carts)
        {
            double total = 0;
            foreach (var cart in carts)
            {
                total += cart.Price * cart.Quantity;
            }
            return total;
        }
    }
}
