using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IOrder_FoodRepository
    {
        void CreateOrderDetail(Order_Food orderLine);
        List<LineItemDTO> GetAllLine(int orderID);
		List<Order_Food> CartReOrder(int orderID);
	}
}
