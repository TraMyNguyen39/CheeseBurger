using System.ComponentModel.DataAnnotations;

namespace CheeseBurger.Model.Entities
{
	public class Partner
	{
		[Key]
		public int PartnerID { get; set; }
		[Required]
		[StringLength(50)]
		public string PartnerName { get; set; }
		[Required]
		[StringLength(50)]
		public string Email { get; set; }
		[Required]
		public bool isDeleted { get; set; }
	}
}
