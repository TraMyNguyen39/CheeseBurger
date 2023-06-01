using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface IImportOrders_IngredientsService
    {
		void CreateOrderDetail(int orderID, int ingrID, float qty);
		void DeleteOrderDetail(int orderID);
		List<ImportLineDTO> GetAllLines(int orderID);
	}
}
