using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class RevenueService:IRevenueService
	{
		private readonly IRevenueRepository revenueRepository;
		public RevenueService(IRevenueRepository revenueRepository)
		{
			this.revenueRepository = revenueRepository;
		}
		public int NumberOrder(DateTime fromDate, DateTime toDate)
		{
			return revenueRepository.NumberOrder(fromDate, toDate);
		}
		public int NumberIOrder(DateTime fromDate, DateTime toDate)
		{
			return revenueRepository.NumberIOrder(fromDate, toDate);
		}

		public float TotalFund(DateTime fromDate, DateTime toDate)
		{
			return revenueRepository.TotalFund(fromDate, toDate);
		}
		public float TotalIncome(DateTime fromDate, DateTime toDate)
		{
			return revenueRepository.TotalIncome(fromDate, toDate);
		}		
		public List<Orders> GetOrdersRangeTime(DateTime fromDate, DateTime toDate)
		{
			return revenueRepository.GetOrdersRangeTime(fromDate, toDate);
		}
		public List<ImportOrder> GetIOrdersRangeTime(DateTime fromDate, DateTime toDate)
		{
			return revenueRepository.GetIOrdersRangeTime(fromDate, toDate);
		}
		public List<FoodRevenueDTO> GetFoodRangeTime(DateTime fromDate, DateTime toDate)
		{
			return revenueRepository.GetFoodRangeTime(fromDate, toDate);
		}
		public List<CustomerRevenueDTO> GetCustomerRangeTime(DateTime fromDate, DateTime toDate)
		{
			return revenueRepository.GetCustomerRangeTime(fromDate, toDate);
		}
	}
}
