using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheeseBurger.Model.Entities
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }
        [StringLength(50)]
        public string StaffName { get; set; }
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public bool Gender { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Birth { get; set; }
        public int AccountID { get; set; }
        [ForeignKey("AccountID")]
        public Account Account { get; set; }
        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Role Role { get; set; }

        public int? AddressID { get; set; }
        [ForeignKey("AddressID")]
        public Address Address { get; set; }
    }
}
