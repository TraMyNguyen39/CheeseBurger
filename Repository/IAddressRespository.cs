using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IAddressRespository
    {
        Address GetAddress(int id);
    }
}
