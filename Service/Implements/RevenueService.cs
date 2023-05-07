using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class RevenueService : IRevenueService
	{
		private readonly IRevenueRespository revenueRespository;
        public RevenueService(IRevenueRespository revenueRespository)
        {
			this.revenueRespository = revenueRespository;
        }
        public List<Revenue> GetAllRevenues()
		{
			return revenueRespository.GetAllRevenues();
		}
	}
}
