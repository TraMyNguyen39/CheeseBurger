using CheeseBurger.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CheeseBurger.DTO
{
	public class ReviewDTO
	{
		public int reviewId { get; set; }
		public int star { get; set; }
		public string content { get; set; }
		public string img { get; set; }
		public DateTime dateReview { get; set; }
		public string customerName { get; set; }
	}
}
