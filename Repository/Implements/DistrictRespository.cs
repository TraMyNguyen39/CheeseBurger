using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
	public class DistrictRespository : IDistrictRespository
	{
		private readonly CheeseBurgerContext context;
		public DistrictRespository(CheeseBurgerContext context)
		{
			this.context = context;
		}
		public District GetDistrict(int id)
		{
			return context.Districts.Where(p => p.DistrictID == id).FirstOrDefault();
		}
	}
}
