namespace CheeseBurger.Repository
{
	public interface IRevenueRepository
	{
		int NumberOrder(DateTime fromDate, DateTime toDate);
		int NumberIOrder(DateTime fromDate, DateTime toDate);
		float TotalFund(DateTime fromDate, DateTime toDate);
		float TotalIncome(DateTime fromDate, DateTime toDate);
	}
}
