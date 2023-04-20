using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class ImportOrder
    {
        [Key]
        public int ImportOrderID { get; set; }

        [Required]
        [StringLength(Int32.MaxValue)]
        public string IOName { get; set; } = String.Empty;

        public DateTime DateIO { get; set; }

        public float TMoneyIO { get; set; }

        public int StaffID { get; set; }
        [ForeignKey("StaffID")]
        public Staff Staff { get; set; }
    }
}
