using CheeseBurger.DTO;
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
		List<FoodRevenueDTO> GetFoodRangeTime(DateTime fromDate, DateTime toDate);
		List<CustomerRevenueDTO> GetCustomerRangeTime(DateTime fromDate, DateTime toDate);
	}
}
