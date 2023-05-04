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
		public List<District> GetListDistricts()
		{
			return context.Districts.Select(p => p).ToList();
		}
		public District GetDistrict(int id)
		{
			return context.Districts.Where(p => p.DistrictID == id).FirstOrDefault();
		}
		public int GetDistrictIDByName(string name)
		{
			var IDDistrict = context.Districts.FirstOrDefault(p => p.DistrictName.Equals(name));
			if (IDDistrict != null)
			{
				return IDDistrict.DistrictID;
			}
			return 0;
		}
	}
}
