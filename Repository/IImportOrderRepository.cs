using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IImportOrderRepository
    {
        List<ImportOrderDTO> GetAllImport();
		void CreateOrder(ImportOrder order);
        void RemoveOrder(int orderId);
        void CalculateMoney(int orderID);
        ImportOrderDTO GetImportOrder(int orderID);
	}
}
