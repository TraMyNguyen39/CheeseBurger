using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class Cart
    {
        [Key]
        [Column(Order = 1)]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        [Key]
        [Column(Order = 2)]
        public int FoodID { get; set; }
		public int Quantity { get; set; }
    }

}
