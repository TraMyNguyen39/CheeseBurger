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
		public void ChangeArriveTime(int orderID, DateTime arriveTime)
		{
			orderRepository.ChangeArriveTime(orderID, arriveTime);
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
		public int[] GetManageOrderCount(DateTime timeStart, DateTime timeEnd, string search)
		{
			return orderRepository.GetManageOrderCount(timeStart, timeEnd, search);
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
		public List<OrderItemDTO> GetAllOrderChef(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search)
		{
			return orderRepository.GetAllOrderChef(status1, status2 , timeStart, timeEnd, search);
		}
		public int[] GetManageOrderCountChef(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search)
		{
			return orderRepository.GetManageOrderCountChef(status1, status2, timeStart, timeEnd, search);
		}
		public List<OrderItemDTO> GetAllOrderShip1(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search)
		{
			return orderRepository.GetAllOrderShip1(status1, status2, timeStart , timeEnd, search);
		}
		public List<OrderItemDTO> GetAllOrderShip2(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search)
		{
			return orderRepository.GetAllOrderShip2(status1, status2, timeStart, timeEnd, search);
		}
		public int[] GetManageOrderCountShip(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search)
		{
			return orderRepository.GetManageOrderCountShip(status1, status2, timeStart, timeEnd, search);
		}
	}
}
