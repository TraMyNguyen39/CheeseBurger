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

		public List<ImportOrderDTO> GetAllImport()
		{
			return importOrderRepository.GetAllImport();
		}

		public dynamic GetImportOrder(int orderID)
		{
			return importOrderRepository.GetImportOrder(orderID);
		}
	}
}
