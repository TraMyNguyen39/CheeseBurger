using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CheeseBurger.Repository.Implements
{
	public class CartRepository : ICartRepository
	{
		private readonly CheeseBurgerContext context;
		public CartRepository (CheeseBurgerContext context)
		{
			this.context = context;
		}

		public List<CartDTO> GetAllCarts(int customerID)
		{
			return context.Carts
					.Where(p => p.CustomerID == customerID & p.Quantity > 0)
				    .Join(context.Foods, c => c.FoodID, f => f.FoodID, (c, f) 
					=> new CartDTO { FoodId = f.FoodID, FoodPic = f.ImageFood, Name = f.FoodName, Price = f.Price, Quantity = c.Quantity })
					.ToList();
		}


		public Cart GetCartProdById(int customerID, int cartProductID)
		{
			return context.Carts.Where(p => p.CustomerID == customerID && p.FoodID == cartProductID).FirstOrDefault();
		}

		public void UpdateCart(int customerID, int cartProductID, int qty)
		{
			var cart = context.Carts
					.Where(p => p.CustomerID == customerID && p.FoodID == cartProductID)
					.Select(p => p)
					.FirstOrDefault();
			if (cart != null)
			{
				cart.Quantity = qty;
				context.SaveChanges();
			}
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

		public void DeleteCart(int customerID, int cartProductID)
		{
			var cartProd = context.Carts.Where(p => p.CustomerID == customerID && p.FoodID == cartProductID).FirstOrDefault();
			if (cartProd != null)
			{
				context.Carts.Remove(cartProd);
				context.SaveChanges();
			}
		}
		//public float GetCartChange(int customerID, int cartProductID, int qty)
		//{
		//	var cart = UpdateCart(customerID, cartProductID, qty);
		//	return cart.Quantity * cart.Price;
		//}
	}
}
