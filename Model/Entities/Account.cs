using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheeseBurger.Model.Entities
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }

        [Required]
        [StringLength(Int32.MaxValue)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        [Required]
        public bool isDeleted { get; set; }

        [Required]
        public bool isStaff { get; set; }

    }
}
