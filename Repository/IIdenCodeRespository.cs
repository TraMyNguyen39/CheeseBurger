using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IIdenCodeRespository
    {
        List<IdenCode> GetListIdenCode();
        string GetNameIdenCodeByID(int id);
    }
}
