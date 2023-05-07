using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface IOrder_FoodService
    {
        void CreateOrderDetail(Order_Food orderLine);
		List<LineItemDTO> GetAllLine(int orderID);
		List<Order_Food> ReOrder(int orderID);
	}
}
