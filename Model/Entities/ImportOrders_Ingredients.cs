using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurgerWeb.Model.Entities
{
    public class ImportOrders_Ingredients
    {
        [Key]
        public int ImportOrderID { get; set; }

        public int IngredientsID { get; set; }
        [ForeignKey("IngredientsID")]
        public Ingredients Ingredients { get; set; }

        public int QuantityIO { get; set; }

        public float PriceIO { get; set; }
    }
}
