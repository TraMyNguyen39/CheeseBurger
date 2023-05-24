namespace CheeseBurger.DTO
{
	public class FoodDTO
	{
		public int IDFood { get; set; }
		public string NameFood { get; set; }
		public float PriceFood { get; set;}
		public string ImgFood { get; set; }
		public string TotalRating { get; set; }
		public bool isStocking { get; set; }
	}
}
