using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;
using CheeseBurger.Repository.Implements;

namespace CheeseBurger.Service.Implements
{
	public class ImportOrders_IngredientsService : IImportOrders_IngredientsService
	{
		private readonly IImportOrders_IngredientsRepository importOrders_IngredientsRepository;
		public ImportOrders_IngredientsService(IImportOrders_IngredientsRepository importOrders_IngredientsRepository)
		{
			this.importOrders_IngredientsRepository = importOrders_IngredientsRepository;
		}

		public void CreateOrderDetail(int orderID, int ingrID, int qty)
		{
			importOrders_IngredientsRepository.CreateOrderDetail(orderID, ingrID, qty);
		}

		public void DeleteOrderDetail(int orderID)
		{
			importOrders_IngredientsRepository.DeleteOrderDetail(orderID);
		}

		public List<ImportLineDTO> GetAllLines(int orderID)
		{
			return importOrders_IngredientsRepository.GetAllLines(orderID);
		}
	}
}
