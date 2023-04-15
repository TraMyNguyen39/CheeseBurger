using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurgerWeb.Model.Entities
{
    public class Ward
    {
        [Key]
        public int WardId { get; set; }

        [Required]
        [StringLength(50)]
        public string WardName { get; set; } = string.Empty;

        public int DistrictID { get; set; }
        [ForeignKey("DistrictID")]
        public District District { get; set; }
    }
}
