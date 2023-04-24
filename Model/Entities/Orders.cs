using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime SaleDate { get; set; }

        [StringLength(500)]
        public String Note { get; set; } = String.Empty;

        public float TotalMoney { get; set; }

        [StringLength(50)]
        public String StatusOdr { get; set; } = String.Empty;

        public int StaffID { get; set; }
        [ForeignKey("StaffID")]
        public Staff Staff { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        public int AddressID { get; set; }
        [ForeignKey("AddressID")]
        public Address Address { get; set; }
    }
}
