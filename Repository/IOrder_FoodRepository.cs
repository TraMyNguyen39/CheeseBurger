using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IOrder_FoodRepository
    {
        void CreateOrderDetail(Order_Food orderLine);
    }
}
