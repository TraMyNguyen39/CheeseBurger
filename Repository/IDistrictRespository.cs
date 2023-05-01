using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IDistrictRespository
    {
        District GetDistrict(int id);
    }
}
