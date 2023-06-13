using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IOrderRepository
    {
        void CreateOrder(Orders order);
        List<OrderItemDTO> GetListOrderByUser(int customerID, int status);
		List<OrderItemDTO> GetAllOrder(int status);
		Orders GetOrderDetail(int customerID, int orderID); 
		int[] GetOrderCount(int customerId);
		int[] GetManageOrderCount(DateTime timeStart, DateTime timeEnd, string search);
		int[] GetManageOrderCountChef(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search);
		int[] GetManageOrderCountShip(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search);
		void ChangeStatus(int orderID, int status);
		void ChangeArriveTime(int orderID, DateTime arriveTime);
		void UpdateChef(int orderID, int chefID);
		void UpdateShipper(int orderID, int shipperID);
		List<OrderItemDTO> GetAllOrderAdmin(int status, DateTime timeStart, DateTime timeEnd, string search);
		List<OrderItemDTO> GetAllOrderChef(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search);
		List<OrderItemDTO> GetAllOrderShip1(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search);
		List<OrderItemDTO> GetAllOrderShip2(int status1, int status2, DateTime timeStart, DateTime timeEnd, string search);
		int NewestOrderID();

	}
}
