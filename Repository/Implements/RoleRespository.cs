using CheeseBurger.Model.Entities;
using CheeseBurger.Model;

namespace CheeseBurger.Repository.Implements
{
    public class RoleRespository : IRoleRespository
    {
		private readonly CheeseBurgerContext context;
		public RoleRespository(CheeseBurgerContext context)
		{
			this.context = context;
		}
		public List<Role> GetAllRoleName()
		{
			return context.Roles.Select(p => p).ToList();
		}
	}
}
