using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class Order_Food
    {

		[Key]
		[Column(Order = 1)]
		public int OrderID { get; set; }
		public Orders Orders { get; set; }

		[Key]
		[Column(Order = 2)]
		public int FoodID { get; set; }
		public Food Food { get; set; }
		[Required]
		public int QuantityOF { get; set; }
		[Required]
		public decimal PriceOF { get; set; }
	}
}
