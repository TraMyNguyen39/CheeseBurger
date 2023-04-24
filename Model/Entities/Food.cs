using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class Food
    {
        [Key]
        public int FoodID { get; set; }

        [Required]
		[StringLength(Int32.MaxValue)]
		public String FoodName { get; set; } = String.Empty;
		[Required]
		public int Quantity { get; set; }
		[Required]
		public float Price { get; set; }

        [StringLength(Int32.MaxValue)]
        public String ImageFood { get; set; } = String.Empty;

        [StringLength(Int32.MaxValue)]
        public String Description { get; set; } = String.Empty;
		[Required]
		public bool IsDeleted { get; set; }

        public int? CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
    }
}
