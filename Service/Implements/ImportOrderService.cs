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

		public List<ImportOrder> GetAllImport()
		{
			return importOrderRepository.GetAllImport();
		}
	}
}
