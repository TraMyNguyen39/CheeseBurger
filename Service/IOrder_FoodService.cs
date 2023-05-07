using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface IOrder_FoodService
    {
        void CreateOrderDetail(Order_Food orderLine);
    }
}
