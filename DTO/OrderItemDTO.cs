namespace CheeseBurger.DTO
{
	public class OrderItemDTO
	{
		public int orderId { get; set; }
		public string customerName { get; set; }
		public DateTime createDate { get; set; }
		public DateTime? arriveDate { get; set; }
		public string houseNumber { get; set; }
		public int statusOrder { get; set; }
		public float tempMoney { get; set; }
		public float shippingMoney { get; set; }
	}
}
