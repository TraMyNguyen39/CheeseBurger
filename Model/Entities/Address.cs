using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public int NumberHouse { get; set; }

        public int StreetID { get; set; }
        [ForeignKey("StreetID")]
        public Street Street { get; set; }

    }
}
