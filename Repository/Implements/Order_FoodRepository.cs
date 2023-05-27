using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
    public class Order_FoodRepository : IOrder_FoodRepository
    {
        private readonly CheeseBurgerContext context;
        public Order_FoodRepository (CheeseBurgerContext context)
        {
            this.context = context;
        }

		public void CreateOrderDetail(Order_Food orderLine)
		{
			context.Order_Foods.Add(orderLine);
            context.SaveChanges();
		}
		public List<LineItemDTO> GetAllLine(int orderID)
		{
			return context.Order_Foods
					.Where(p => p.OrderID == orderID)
					.Join(context.Foods, c => c.FoodID, f => f.FoodID, (c, f)
					=> new LineItemDTO { FoodId = f.FoodID, FoodPic = f.ImageFood, Name = f.FoodName, Price = c.PriceOF, Quantity = c.QuantityOF })
					.ToList();
		}

		public List<Order_Food> CartReOrder(int orderID)
		{
			return context.Order_Foods.Where(p => p.OrderID == orderID).Select(p => p).ToList();
		}
	}
}
