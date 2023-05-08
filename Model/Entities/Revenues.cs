using System.ComponentModel.DataAnnotations;

namespace CheeseBurger.Model.Entities
{
	public class Revenues
	{
		[Required]
		public DateTime DateReve { get; set; }
		[Required]
		public int NumberOrder { get; set; }
		[Required]
		public int NumberIOrder { get; set; }
		[Required]
		public float Fund { get; set; }
		[Required]
		public float Income { get; set; }
	}
}
