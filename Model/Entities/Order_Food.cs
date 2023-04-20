using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class Order_Food
    {
        [Key]
        [Column(Order = 1)]
        public int OrderDetID { get; set; }
        public virtual Orders Orders { get; set; }

        public int QuantityOG { get; set; }

        [Key]
        [Column(Order = 2)]
        public int FoodID { get; set; }
        public virtual Food Food { get; set; }
    }
}
