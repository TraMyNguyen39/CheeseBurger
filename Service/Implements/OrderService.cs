using CheeseBurger.DTO;
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

		public void ChangeStatus(int orderID, int status)
		{
			orderRepository.ChangeStatus(orderID, status);
		}

		public void CreateOrder(Orders order)
		{
			orderRepository.CreateOrder(order);
		}

		public List<OrderItemDTO> GetAllOrder(int status)
		{
			return orderRepository.GetAllOrder(status);
		}

		public List<OrderItemDTO> GetAllOrderAdmin(int status, DateTime timeStart, DateTime timeEnd, string search)
		{
			return orderRepository.GetAllOrderAdmin(status, timeStart, timeEnd, search);
		}

		public List<OrderItemDTO> GetListOrderByUser(int customerID, int status)
		{
			return orderRepository.GetListOrderByUser(customerID, status);
		}

		public int[] GetOrderCount(int customerId)
		{
			return orderRepository.GetOrderCount(customerId);
		}

        public Orders GetOrderDetail(int customerID, int orderID)
        {
            return orderRepository.GetOrderDetail(customerID, orderID);
        }

		public void UpdateChef(int orderID, int chefID)
		{
			orderRepository.UpdateChef(orderID, chefID);
		}

		public void UpdateShipper(int orderID, int shipperID)
		{
			orderRepository.UpdateShipper(orderID, shipperID);
		}

		public int NewestOrderID()
		{
			return orderRepository.NewestOrderID();
		}
	}
}
