using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IDistrictRespository
    {
        List<District> GetListDistricts();
        District GetDistrict(int id);
    }
}
