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
		public List<Revenues> GetRevenuesRangeTime(DateTime fromDate, DateTime toDate)
		{
			return revenueRepository.GetRevenuesRangeTime(fromDate, toDate);
		}
	}
}
