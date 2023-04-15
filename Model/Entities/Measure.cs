using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurgerWeb.Model.Entities
{
    public class Measure
    {
        [Key]
        public int MeasureID { get; set; }

        [Required]
        [StringLength(50)]
        public String MeasureName { get; set; } = String.Empty;
    }
}
