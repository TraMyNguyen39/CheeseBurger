using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IRoleRespository
    {
		int GetRoleIDByName(string name);
	}
}
