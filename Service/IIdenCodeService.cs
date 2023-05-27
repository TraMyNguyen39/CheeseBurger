using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface IIdenCodeService
    {
        List<IdenCode> GetListIdenCode();
        string GetNameIdenCodeByID(int id);
    }
}
