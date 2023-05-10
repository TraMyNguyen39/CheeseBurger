using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
	public class ImportOrderRepository : IImportOrderRepository
	{
		private readonly CheeseBurgerContext context;
		public ImportOrderRepository(CheeseBurgerContext context)
		{
			this.context = context;
		}
		public List<ImportOrder> GetAllImport()
		{
			return context.ImportOrders.OrderByDescending(p => p.DateIO).ToList();
		}
	}
}
