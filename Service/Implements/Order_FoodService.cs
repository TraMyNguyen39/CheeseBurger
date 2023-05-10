using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;
using CheeseBurger.Repository.Implements;

namespace CheeseBurger.Service.Implements
{
    public class Order_FoodService : IOrder_FoodService
    {
        private readonly IOrder_FoodRepository orderFoodRepository;
        public Order_FoodService (IOrder_FoodRepository orderFoodRepository)
        {
            this.orderFoodRepository = orderFoodRepository;
        }

		public void CreateOrderDetail(Order_Food orderLine)
		{
			orderFoodRepository.CreateOrderDetail(orderLine);
		}

		public List<LineItemDTO> GetAllLine(int orderID)
		{
			return orderFoodRepository.GetAllLine(orderID);
		}

		public List<Order_Food> ReOrder(int orderID)
		{
			return orderFoodRepository.CartReOrder(orderID);
		}
	}
}
