using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class Revenue
    {
        [Key]
        public int RevenueID { get; set; }
        public DateTime DateReve { get; set; }
        public int NumberOrder { get; set; }
        public int NumberIOrder { get; set; }
        public int Fund { get; set; }
        public int Income { get; set; }
    }
}
