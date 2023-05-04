using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface IOrderService
    {
		void CreateOrder(Orders order);
	}
}
