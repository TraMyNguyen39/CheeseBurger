using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class AddressService : IAddressService
	{
		private readonly IAddressRespository addressRespository;
		public AddressService(IAddressRespository addressRespository)
		{
			this.addressRespository = addressRespository;
		}
		public Address GetAddress(int id)
		{
			return addressRespository.GetAddress(id);
		}
	}
}
