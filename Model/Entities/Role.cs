using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheeseBurgerWeb.Model.Entities
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        [Required]
        [StringLength(15)]
        public string RoleName { get; set; } = string.Empty;

    }
}
