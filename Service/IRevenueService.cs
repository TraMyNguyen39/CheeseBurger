using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
	public interface IRevenueService
	{
		int NumberOrder(DateTime fromDate, DateTime toDate);
		int NumberIOrder(DateTime fromDate, DateTime toDate);
		float TotalFund(DateTime fromDate, DateTime toDate);
		float TotalIncome(DateTime fromDate, DateTime toDate);
		List<Orders> GetOrdersRangeTime(DateTime fromDate, DateTime toDate);
		List<ImportOrder> GetIOrdersRangeTime(DateTime fromDate, DateTime toDate);
		List<Food> GetFoodRangeTime(DateTime fromDate, DateTime toDate);
	}
}
