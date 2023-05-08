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
		public List<Ward> GetListWards()
		{
			return context.Wards.Select(p => p).ToList();
		}
		public Ward GetWard(int id)
		{
			return context.Wards.Where(p => p.WardId == id).FirstOrDefault();
		}
		public int GetWardIDByName(string name)
		{
			var IDWard = context.Wards.FirstOrDefault(p => p.WardName.Equals(name));
			if (IDWard != null)
			{
				return IDWard.WardId;
			}
			return 0;
		}
	}
}
