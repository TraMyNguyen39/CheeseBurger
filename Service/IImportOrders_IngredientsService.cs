using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface IImportOrders_IngredientsService
    {
		void CreateOrderDetail(int orderID, int ingrID, int qty);
		void DeleteOrderDetail(int orderID, int ingreID);
	}
}
