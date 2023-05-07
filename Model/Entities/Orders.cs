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
		[Required]
		[StringLength(50)]
		public string CustomerName { get; set; }
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }

		[StringLength(Int32.MaxValue)]
		public String Note { get; set; } = String.Empty;
		[Required]
		public float TotalMoney { get; set; }
		[Required]
		public int StatusOdr { get; set; }

        public int? ChefID { get; set; }
		public int? ShipperID { get; set; }
		[ForeignKey("ChefID")]
        public Staff ChefStaff { get; set; }
		[ForeignKey("ShipperID")]
		public Staff ShipperStaff { get; set; }

		public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        public string HourseNumber { get; set; }
        public int WardID { get; set; }
        [ForeignKey("WarđID")]
        public Ward Ward { get; set; }
    }
}
