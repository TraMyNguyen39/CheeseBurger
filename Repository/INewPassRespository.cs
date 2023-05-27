using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface INewPassRespository
    {
        List<NewPass> GetListNewPass();
        string GetNamePassByID(int id);
    }
}
