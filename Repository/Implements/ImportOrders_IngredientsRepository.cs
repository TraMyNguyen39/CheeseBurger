using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Model;

namespace CheeseBurger.Repository.Implements
{
	public class ImportOrders_IngredientsRepository : IImportOrders_IngredientsRepository
	{
		private readonly CheeseBurgerContext context;
		public ImportOrders_IngredientsRepository(CheeseBurgerContext context)
		{
			this.context = context;
		}

		public void CreateOrderDetail(int orderID, int ingrID, int qty)
		{
			var price = context.Ingredients.Find(ingrID);
			var oldDetail = context.ImportOrders_Ingredients
									.Where(p => p.ImportOrderID == orderID && p.IngredientsID == ingrID)
									.FirstOrDefault();
			if (oldDetail == null)
			{
				context.ImportOrders_Ingredients.Add(new ImportOrders_Ingredients
				{
					ImportOrderID = orderID,
					IngredientsID = ingrID,
					QuantityIO = qty,
					PriceIO = price.IngredientsPrice
				});
			}
			else
			{
				oldDetail.QuantityIO += qty;
			}
			context.SaveChanges();
		}
		public void DeleteOrderDetail(int orderID)
		{
			var ingre = context.ImportOrders_Ingredients.Where(p => p.ImportOrderID == orderID).FirstOrDefault();
			if (ingre != null)
			{
				context.ImportOrders_Ingredients.RemoveRange(ingre);
			}
			context.SaveChanges();
		}

		public List<ImportLineDTO> GetAllLines(int orderID)
		{
			return context.ImportOrders_Ingredients
					.Where(p => p.ImportOrderID == orderID)
					.Select(p => new ImportLineDTO
					{
						IngredientName = p.Ingredients.IngredientsName,
						PriceIO = p.PriceIO,
						QuantityIO = p.QuantityIO,
						Unit = p.Ingredients.Measure.MeasureName
					}).ToList();
		}
	}
}
