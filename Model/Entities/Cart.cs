using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class Cart
    {
        [Key]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        [Key]
        public int FoodID { get; set; }
		public virtual Food Food { get; set; }
		public int Quantity { get; set; }
    }

}
