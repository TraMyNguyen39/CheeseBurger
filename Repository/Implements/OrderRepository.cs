using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using Microsoft.IdentityModel.Tokens;

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
		public void ChangeArriveTime(int orderID, DateTime arriveTime)
		{
			var order = context.Orders.Find(orderID);
			if (order != null)
			{
				order.ArriveTime = arriveTime;
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

		public List<OrderItemDTO> GetAllOrderAdmin(int status, DateTime timeStart, DateTime timeEnd, string search)
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
			if (timeStart != default(DateTime) && timeEnd != default(DateTime))
			{
				orders = orders.Where(p => p.createDate >= timeStart && p.createDate <= timeEnd);
			}
			if (!search.IsNullOrEmpty())
			{
				orders = orders.Where(p => p.customerName.Contains(search));
			}
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
		public int[] GetManageOrderCount(DateTime timeStart, DateTime timeEnd, string search)
		{
			int[] status = new int[8];			
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
			if (timeStart != default(DateTime) && timeEnd != default(DateTime))
			{
				orders = orders.Where(p => p.createDate >= timeStart && p.createDate <= timeEnd);
			}
			if (!search.IsNullOrEmpty())
			{
				orders = orders.Where(p => p.customerName.Contains(search));
			}
			foreach (var item in orders)
			{
				// trang thai duoc mo ta trong EmumOrderStatus
				var index = item.statusOrder;
				status[index]++;
			}
			// trang thai 0 la trang thai tat ca
			status[0] = orders.Count();
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
		public int NewestOrderID()
		{
			var newestOrder = context.Orders.OrderByDescending(p => p.OrderID).FirstOrDefault();
			if (newestOrder != null)
			{
				return newestOrder.OrderID;
			}
			return 0; // or any other appropriate default value if there are no orders
		}
		public List<OrderItemDTO> GetAllOrderChef(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search)
		{
			if (status1 == 0 && status2 == 0) return Enumerable.Empty<OrderItemDTO>().ToList();
			var orders1 = context.Orders.Select(p => new OrderItemDTO
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
			var orders = orders1;
			if (status1 == 0)
			{
				orders = orders1.Where(p => p.statusOrder == status2);
			} 
			else
			{
				var orders2 = orders1;
				orders1 = orders1.Where(p => p.statusOrder == status1);
				orders2 = orders2.Where(p => p.statusOrder == status2);
				orders = orders1.Concat(orders2);
			}
			if (timeStart != default(DateTime) && timeEnd != default(DateTime))
			{
				orders = orders.Where(p => p.createDate >= timeStart && p.createDate <= timeEnd);
			}
			if (!search.IsNullOrEmpty())
			{
				orders = orders.Where(p => p.customerName.Contains(search));
			}
			return orders.OrderByDescending(p => p.createDate).ToList();
		}
		public int[] GetManageOrderCountChef(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search)
		{
			int[] status = new int[8];
			var orders1 = context.Orders.Select(p => new OrderItemDTO
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
			var orders2 = orders1;
			orders1 = orders1.Where(p => p.statusOrder == status1);
			orders2 = orders2.Where(p => p.statusOrder == status2);
			var orders = orders1.Concat(orders2);		
			if (timeStart != default(DateTime) && timeEnd != default(DateTime))
			{
				orders = orders.Where(p => p.createDate >= timeStart && p.createDate <= timeEnd);
			}
			if (!search.IsNullOrEmpty())
			{
				orders = orders.Where(p => p.customerName.Contains(search));
			}
			foreach (var item in orders)
			{
				// trang thai duoc mo ta trong EmumOrderStatus
				var index = item.statusOrder;
				status[index]++;
			}
			// trang thai 0 la trang thai tat ca
			status[0] = orders.Count();
			return status;
		}
		public int[] GetManageOrderCountShip(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search)
		{
			int[] status = new int[8];
			var orders1 = context.Orders.Select(p => new OrderItemDTO
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
			var orders2 = orders1.Where(p => p.statusOrder == status1);
			var orders3 = orders1.Where(p => p.statusOrder == status2);
			var orders = orders1.Except(orders2);
			orders = orders.Except(orders3);
			if (timeStart != default(DateTime) && timeEnd != default(DateTime))
			{
				orders = orders.Where(p => p.createDate >= timeStart && p.createDate <= timeEnd);
			}
			if (!search.IsNullOrEmpty())
			{
				orders = orders.Where(p => p.customerName.Contains(search));
			}
			foreach (var item in orders)
			{
				// trang thai duoc mo ta trong EmumOrderStatus
				var index = item.statusOrder;
				status[index]++;
			}
			// trang thai 0 la trang thai tat ca
			status[0] = orders.Count();
			return status;
		}

		public List<OrderItemDTO> GetAllOrderShip1(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search)
		{			
			var orders1 = context.Orders.Select(p => new OrderItemDTO
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
			var orders2 = orders1.Where(p => p.statusOrder == status1);
			var orders3 = orders1.Where(p => p.statusOrder == status2);
			var orders = orders1.Except(orders2);
			orders = orders.Except(orders3);
			if (timeStart != default(DateTime) && timeEnd != default(DateTime))
			{
				orders = orders.Where(p => p.createDate >= timeStart && p.createDate <= timeEnd);
			}
			if (!search.IsNullOrEmpty())
			{
				orders = orders.Where(p => p.customerName.Contains(search));
			}
			return orders.OrderByDescending(p => p.createDate).ToList();
		}
		public List<OrderItemDTO> GetAllOrderShip2(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search)
		{
			if (status1 == 0 && status2 == 0) return Enumerable.Empty<OrderItemDTO>().ToList();
			var orders1 = context.Orders.Select(p => new OrderItemDTO
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
			var orders = orders1.Where(p => p.statusOrder == status2);			
			if (timeStart != default(DateTime) && timeEnd != default(DateTime))
			{
				orders = orders.Where(p => p.createDate >= timeStart && p.createDate <= timeEnd);
			}
			if (!search.IsNullOrEmpty())
			{
				orders = orders.Where(p => p.customerName.Contains(search));
			}
			return orders.OrderByDescending(p => p.createDate).ToList();
		}
	}
}
