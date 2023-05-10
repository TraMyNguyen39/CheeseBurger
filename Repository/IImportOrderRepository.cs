using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IImportOrderRepository
    {
        List<ImportOrderDTO> GetAllImport();
		void CreateOrder(ImportOrder order);
        void CalculateMoney(int orderID);
	}
}
