using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using Microsoft.IdentityModel.Tokens;

namespace CheeseBurger.Repository.Implements
{
	public class ImportOrderRepository : IImportOrderRepository
	{
		private readonly CheeseBurgerContext context;
		public ImportOrderRepository(CheeseBurgerContext context)
		{
			this.context = context;
		}

		public void CalculateMoney(int orderID)
		{
			var orderLines = context.ImportOrders_Ingredients
									.Where(p => p.ImportOrderID == orderID)
									.ToList();
			float total = 0;
			foreach (var line in orderLines)
			{
				total += line.PriceIO * line.QuantityIO;
			}
			var order = context.ImportOrders.Find(orderID);
			if (order != null)
			{
				order.TMoneyIO = total;
				context.SaveChanges();
			}
		}

		public void CreateOrder(ImportOrder order)
		{
			context.ImportOrders.Add(order);
			context.SaveChanges();
		}

		public List<ImportOrderDTO> GetAllImport(DateTime timeStart, DateTime timeEnd, string searchText)
		{
			var import = from c in context.ImportOrders
						 join a in context.Partners on c.PartnerID equals a.PartnerID
						 select new ImportOrderDTO { 
							 ImportOrderID = c.ImportOrderID,
							 TMoneyIO = c.TMoneyIO,
							 DateIO = c.DateIO,
							 PartnerName = a.PartnerName,
							 StaffID= c.StaffID,
						 };
			if (timeStart != default(DateTime) || timeEnd != default(DateTime))
			{
				import = import.Where(p => p.DateIO >= timeStart && p.DateIO <= timeEnd);
			}
			if (!searchText.IsNullOrEmpty())
			{
				import = import.Where(p => p.PartnerName.Contains(searchText));
			}
			return import.OrderByDescending(p => p.DateIO).ToList();
		}

		public ImportOrderDTO GetImportOrder(int orderID)
		{
			var order = context.ImportOrders.Where(p => p.ImportOrderID == orderID)
											.Select(p => new ImportOrderDTO
											{
												DateIO = p.DateIO,
												ImportOrderID = p.ImportOrderID,
												PartnerName = p.Partner.PartnerName,
												TMoneyIO = p.TMoneyIO,
												StaffID = p.StaffID,
											});
			return order.FirstOrDefault();
		}

		public void RemoveOrder(int orderId)
		{
			var order = context.ImportOrders.Find(orderId);
			if (order != null)
			{
				context.ImportOrders.Remove(order);
				context.SaveChanges();
			}
		}
	}
}
