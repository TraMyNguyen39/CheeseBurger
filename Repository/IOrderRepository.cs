using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IOrderRepository
    {
        void CreateOrder(Orders order);
    }
}
