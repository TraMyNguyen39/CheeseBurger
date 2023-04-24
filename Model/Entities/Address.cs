using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
		[Required]
		[StringLength(100)]
		public string NumberHouse { get; set; } = string.Empty;

		public int WardID { get; set; }
		[ForeignKey("WardID")]
		public Ward Ward { get; set; }

	}
}
