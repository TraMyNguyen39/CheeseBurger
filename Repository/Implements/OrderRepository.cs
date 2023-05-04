using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
	public class OrderRepository : IOrderRepository
	{
		private readonly CheeseBurgerContext context;
		public OrderRepository (CheeseBurgerContext context)
		{
			this.context = context;
		}
		public void CreateOrder(Orders order)
		{
			context.Orders.Add(order);
			context.SaveChanges();
		}
	}
}
