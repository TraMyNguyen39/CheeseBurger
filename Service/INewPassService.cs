using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface INewPassService
    {
        List<NewPass> GetListNewPass();
        string GetNamePassByID(int id);
    }
}
