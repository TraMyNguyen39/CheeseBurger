using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheeseBurgerWeb.Model.Entities
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [StringLength(50)]
        public string AdminName { get; set; } = string.Empty;
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = string.Empty;
        public bool Gender { get; set; }
        [StringLength(255)]
        public string Address { get; set; } = string.Empty;
        [DataType(DataType.DateTime)]
        public DateTime Birth { get; set; }
        public int AccountID { get; set; }
        public int RoleID { get; set; }
        [Required]
        [ForeignKey("AccountID")]
        public Account Account { get; set; }
        [Required]
        [ForeignKey("RoleID")]
        public Role Role { get; set; }
    }
}
