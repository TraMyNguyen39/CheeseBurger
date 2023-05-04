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
		public int GetRoleIDByName(string name)
		{
			var IDRole = context.Roles.FirstOrDefault(p => p.RoleName.Equals(name));
			if (IDRole != null)
			{
				return IDRole.RoleID;
			}
			return 0;
		}
	}
}
