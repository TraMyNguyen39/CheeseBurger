using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface IImportOrderService
    {
		List<ImportOrderDTO> GetAllImport(DateTime timeStart, DateTime timeEnd, string searchText);
		void CreateOrder(ImportOrder order);
		void RemoveOrder(int orderId);
		void CalculateMoney(int orderID);
		ImportOrderDTO GetImportOrder(int orderID);
	}
}
