using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface ITPassRespository
    {
        List<TPass> GetListTPass();
        string GetNameTPassByID(int id);
    }
}
