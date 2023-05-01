using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
	public class AddressRespository : IAddressRespository
	{
		private readonly CheeseBurgerContext context;
		public AddressRespository(CheeseBurgerContext context)
		{
			this.context = context;
		}
		public Address GetAddress(int id)
		{
			return context.Addresses.Where(p => p.AddressID == id).FirstOrDefault();
		}
	}
}
