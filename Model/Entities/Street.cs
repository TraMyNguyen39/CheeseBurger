using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheeseBurgerWeb.Model.Entities
{
    public class Street
    {
        [Key]
        public int StreetID { get; set; }

        [Required]
        [StringLength(50)]
        public String StreetName { get; set; } = String.Empty;

        public int WardID { get; set; }
        [ForeignKey("WardID")]
        public Ward Ward { get; set; }
    }
}
