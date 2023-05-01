using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
	public class WardRespository : IWardRespository
	{
		private readonly CheeseBurgerContext context;
		public WardRespository(CheeseBurgerContext context)
		{
			this.context = context;
		}
		public Ward GetWard(int id)
		{
			return context.Wards.Where(p => p.WardId == id).FirstOrDefault();
		}
	}
}
