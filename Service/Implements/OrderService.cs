using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository orderRepository;
		public OrderService(IOrderRepository orderRepository)
		{
			this.orderRepository = orderRepository;
		}
		public void CreateOrder(Orders order)
		{
			orderRepository.CreateOrder(order);
		}
	}
}
