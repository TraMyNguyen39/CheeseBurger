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
        public int AddressID { get; set; }
        [ForeignKey("AddressID")]
        public Address Address { get; set; }
        public int AccountID { get; set; }
        [ForeignKey("AccountID")]
        public Account Account { get; set; }
    }
}
