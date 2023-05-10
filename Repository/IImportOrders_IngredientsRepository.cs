using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IImportOrders_IngredientsRepository
    {
		void CreateOrderDetail(int orderID, int ingrID, int qty);
		void DeleteOrderDetail(int orderID, int ingreID);
	}
}
