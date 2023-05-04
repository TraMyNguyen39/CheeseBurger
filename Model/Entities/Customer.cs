using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheeseBurger.Model.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [StringLength(100)]
        public string CustomerName { get; set; }
		[StringLength(10)]
		[DataType(DataType.PhoneNumber)]
        [Required]
        public string Phone { get; set; }
        public bool? Gender { get; set; }
		public string HouseNumber { get; set; }
		public int? WardID { get; set; }
        [ForeignKey("WardID")]
        public Ward Ward { get; set; }
        public int AccountID { get; set; }
        [ForeignKey("AccountID")]
        public Account Account { get; set; }
    }
}