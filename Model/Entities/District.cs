using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class District
    {
        [Key]
        public int DistrictID { get; set; }

        [Required]
        [StringLength(50)]
        public String DistrictName { get; set; } = string.Empty;

    }
}
