using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface IWardService
    {
		List<Ward> GetListWards();
		Ward GetWard(int id);
		int GetWardIDByName(string name);
	}
}
