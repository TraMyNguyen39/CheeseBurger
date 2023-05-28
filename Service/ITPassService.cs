using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface ITPassService
    {
        List<TPass> GetListTPass();
        string GetNameTPassByID(int id);
    }
}
