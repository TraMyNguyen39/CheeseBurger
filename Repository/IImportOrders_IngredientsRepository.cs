using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IImportOrders_IngredientsRepository
    {
		void CreateOrderDetail(int orderID, int ingrID, int qty);
		void DeleteOrderDetail(int orderID);
		List<ImportLineDTO> GetAllLines(int orderID);
	}
}
