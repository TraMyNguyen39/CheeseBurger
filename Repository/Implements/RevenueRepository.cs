using CheeseBurger.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CheeseBurger.Repository.Implements
{
	public class RevenueRepository : IRevenueRepository
	{
		private readonly CheeseBurgerContext context;
		public RevenueRepository(CheeseBurgerContext context)
		{
			this.context = context;
		}

		public int NumberOrder(DateTime fromDate, DateTime toDate)
		{
			if (fromDate != default(DateTime) && toDate != default(DateTime))
			{
				return context.Revenues
					.Where(p => p.DateReve >= fromDate && p.DateReve <= toDate)
					.Sum(e => e.NumberOrder);
			}
			return context.Revenues.Sum(e => e.NumberOrder);
		}

		public int NumberIOrder(DateTime fromDate, DateTime toDate)
		{
			if (fromDate != default(DateTime) && toDate != default(DateTime))
			{
				return context.Revenues
					.Where(p => p.DateReve >= fromDate && p.DateReve <= toDate)
					.Sum(e => e.NumberIOrder);
			}
			return context.Revenues.Sum(e => e.NumberIOrder);
		}

		public float TotalFund(DateTime fromDate, DateTime toDate)
		{
			if (fromDate != default(DateTime) && toDate != default(DateTime))
			{
				return context.Revenues
					.Where(p => p.DateReve >= fromDate && p.DateReve <= toDate)
					.Sum(e => e.Fund);
			}
			return context.Revenues.Sum(e => e.Fund);
		}

		public float TotalIncome(DateTime fromDate, DateTime toDate)
		{
			if (fromDate != default(DateTime) && toDate != default(DateTime))
			{
				return context.Revenues
					.Where(p => p.DateReve >= fromDate && p.DateReve <= toDate)
					.Sum(e => e.Income);
			}
			return context.Revenues.Sum(e => e.Income);
		}
	}
}
