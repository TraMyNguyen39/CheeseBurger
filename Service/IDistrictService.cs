using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface IDistrictService
    {
		List<District> GetListDistricts();
		District GetDistrict(int id);
		int GetDistrictIDByName(string name);
	}
}
