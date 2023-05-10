using CheeseBurger.DTO;
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

		public void ChangeStatus(int orderID, int status)
		{
			var order = context.Orders.Find(orderID);
			if (order != null)
			{
				order.StatusOdr = status;
				context.SaveChanges();
			}
		}

		public void CreateOrder(Orders order)
		{
			context.Orders.Add(order);
			context.SaveChanges();
		}

		public List<OrderItemDTO> GetAllOrder(int status)
		{
			var orders = context.Orders.Select(p => new OrderItemDTO
								 {
									 orderId = p.OrderID,
									 createDate = p.SaleDate,
									 arriveDate = p.ArriveTime,
									 houseNumber = p.HourseNumber,
									 tempMoney = p.TempMoney,
									 shippingMoney = p.ShippingMoney,
									 statusOrder = p.StatusOdr,
									 customerName = p.CustomerName,
								 });
			if (status != 0)
				orders = orders.Where(p => p.statusOrder == status);

			return orders.OrderByDescending(p => p.createDate).ToList();
		}

		public List<OrderItemDTO> GetListOrderByUser(int customerID, int status)
		{
			var orders = context.Orders.Where(p => p.CustomerID == customerID)
								 .Select(p => new OrderItemDTO
								 {
									 orderId = p.OrderID,
									 createDate = p.SaleDate,
									 arriveDate = p.ArriveTime,
									 houseNumber = p.HourseNumber,
									 tempMoney = p.TempMoney,
									 shippingMoney = p.ShippingMoney,
									 statusOrder = p.StatusOdr,
									 customerName = p.CustomerName,
								 });
			if (status != 0)
				orders = orders.Where(p => p.statusOrder == status);

			return orders.OrderByDescending(p => p.createDate).ToList();
		}

		public int[] GetOrderCount(int customerId)
		{
			int[] status = new int[8];
			var orders = context.Orders.Select(p => p).ToList();
			if (customerId != 0)
			{
				orders = orders.Where(p => p.CustomerID == customerId).ToList();
			}
			foreach (var item in orders)
			{
				// trang thai duoc mo ta trong EmumOrderStatus
				var index = item.StatusOdr;
				status[index]++;
			}
			// trang thai 0 la trang thai tat ca
			status[0] = orders.Count;
			return status;
		}

        public Orders GetOrderDetail(int customerID, int orderID)
        {
            var order = context.Orders.Where(p => p.OrderID == orderID);
			if (customerID != 0)
				order = order.Where(p => p.CustomerID == customerID);
			return order.FirstOrDefault();
        }

		public void UpdateChef(int orderID, int chefID)
		{
			var order = context.Orders.Find(orderID);
			order.ChefID = chefID;
			context.SaveChanges();
		}

		public void UpdateShipper(int orderID, int shipperID)
		{
			var order = context.Orders.Find(orderID);
			order.ShipperID = shipperID;
			context.SaveChanges();
		}
	}
}
