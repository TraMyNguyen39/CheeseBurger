using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
	public class RevenueRespository : IRevenueRespository
	{
		private readonly CheeseBurgerContext context;
		public RevenueRespository(CheeseBurgerContext context)
		{
			this.context = context;
		}
		public List<Revenue> GetAllRevenues()
		{
			return context.Revenues.Select(p => p).ToList();
		}
	}
}
