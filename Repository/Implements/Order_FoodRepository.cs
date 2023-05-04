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
	}
}
