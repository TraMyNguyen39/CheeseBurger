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
		public void DeleteOrderDetail(int orderID, int ingreID)
		{
			var ingre = context.ImportOrders_Ingredients.Where(p => p.ImportOrderID == orderID && p.IngredientsID == ingreID).FirstOrDefault();
			if (ingre != null)
			{
				context.ImportOrders_Ingredients.Remove(ingre);
			}
			context.SaveChanges();
		}
		//public List<LineItemDTO> GetAllLine(int orderID)
		//{
		//	return context.Order_Foods
		//			.Where(p => p.OrderID == orderID)
		//			.Join(context.Foods, c => c.FoodID, f => f.FoodID, (c, f)
		//			=> new LineItemDTO { FoodId = f.FoodID, FoodPic = f.ImageFood, Name = f.FoodName, Price = c.PriceOF, Quantity = c.QuantityOF })
		//			.ToList();
		//}
	}
}
