using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheeseBurgerWeb.Model.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [StringLength(50)]
        public string CustomerName { get; set; } = string.Empty;
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = string.Empty;
        public bool Gender { get; set; }
        [StringLength(255)]
        public string Address { get; set; } = string.Empty;
        public int AccountID { get; set; }
        [Required]
        [ForeignKey("AccountID")]
        public Account Account { get; set; } 

    }
}
