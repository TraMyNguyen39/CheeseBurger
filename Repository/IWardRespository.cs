using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IWardRespository
    {
        List<Ward> GetListWards();
        Ward GetWard(int id);
        int GetWardIDByName(string name);
    }
}
