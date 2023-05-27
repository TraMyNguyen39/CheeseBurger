using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
    public class ImportOrderService :IImportOrderService
    {
        private readonly IImportOrderRepository importOrderRepository;
        public ImportOrderService(IImportOrderRepository importOrderRepository)
        {
            this.importOrderRepository = importOrderRepository;
        }

		public void CalculateMoney(int orderID)
		{
			importOrderRepository.CalculateMoney(orderID);
		}

		public void CreateOrder(ImportOrder order)
		{
			importOrderRepository.CreateOrder(order);
		}

		public List<ImportOrderDTO> GetAllImport(DateTime timeStart, DateTime timeEnd, string searchText)
		{
			return importOrderRepository.GetAllImport(timeStart, timeEnd, searchText);
		}

		public ImportOrderDTO GetImportOrder(int orderID)
		{
			return importOrderRepository.GetImportOrder(orderID);
		}

		public void RemoveOrder(int orderId)
		{
			importOrderRepository.RemoveOrder(orderId);
		}
	}
}
