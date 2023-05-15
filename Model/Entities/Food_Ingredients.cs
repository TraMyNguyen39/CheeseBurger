using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class Food_Ingredients
    {
        [Key]
        [Column(Order = 1)]
        public int FoodID { get; set; }
        public virtual Food Food { get; set; }

        [Key]
        [Column(Order = 2)]
        public int IngredientsId { get; set; }
        public virtual Ingredients Ingredients { get; set; }

        public float QuantityIG { get; set; }
    }
}
