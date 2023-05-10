namespace CheeseBurger.Helpers
{
	public class FeeAPIResult
	{
		public int code { get; set; }
		public string message { get; set; }
		public List<FeeAPI> data { get; set; }
	}
}
