using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class ImportOrders_Ingredients
    {
		[Key]
		public int ImportOrderID { get; set; }
		public ImportOrder ImportOrder { get; set; }
		[Key]
		public int IngredientsID { get; set; }
		public Ingredients Ingredients { get; set; }

		public int QuantityIO { get; set; }

		public float PriceIO { get; set; }
	}
}
