using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        public int Star { get; set; }

        [StringLength(Int32.MaxValue)]
        public String Content { get; set; }

        [StringLength(Int32.MaxValue)]
        public String Img { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime DateReview { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        public int FoodID { get; set; }
        [ForeignKey("FoodID")]
        public Food Food { get; set; }
    }
}
