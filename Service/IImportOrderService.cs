using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface IImportOrderService
    {
		List<ImportOrderDTO> GetAllImport();
		void CreateOrder(ImportOrder order);
		void CalculateMoney(int orderID);
		dynamic GetImportOrder(int orderID);
	}
}
