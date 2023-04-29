using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class DistrictService : IDistrictService
	{
		private readonly IDistrictRespository districtRespository;
		public DistrictService(IDistrictRespository districtRespository)
		{
			this.districtRespository = districtRespository;
		}
		public District GetDistrict(int id)
		{
			return districtRespository.GetDistrict(id);
		}
	}
}
