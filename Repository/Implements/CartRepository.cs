 using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
	public class CartRepository : ICartRepository
	{
		private readonly CheeseBurgerContext context;
		public CartRepository (CheeseBurgerContext context)
		{
			this.context = context;
		}

		public void AddCart(int customerID, int cartProductID, int qty)
		{
			var cartProd = GetCartProdById(customerID, cartProductID);
			if (cartProd == null)
			{
				context.Carts.Add(new Cart { CustomerID = customerID, FoodID = cartProductID, Quantity = qty });
			}
			else
			{
				cartProd.Quantity += qty;
			}
			context.SaveChanges();
		}

		public Cart GetCartProdById(int customerID, int cartProductID)
		{
			return context.Carts.Where(p => p.CustomerID == customerID && p.FoodID == cartProductID).FirstOrDefault();
		}
	}
}
