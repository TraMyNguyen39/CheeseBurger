using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime SaleDate { get; set; }

		[StringLength(Int32.MaxValue)]
		public String Note { get; set; } = String.Empty;
		[Required]
		public float TotalMoney { get; set; }

        [StringLength(50)]
        public int StatusOdr { get; set; }

        public int? StaffID { get; set; }
        [ForeignKey("StaffID")]
        public Staff Staff { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        public string HourseNumber { get; set; }
        public int WardID { get; set; }
        [ForeignKey("AddressID")]
        public Ward Address { get; set; }
    }
}
