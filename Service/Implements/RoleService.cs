using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class RoleService : IRoleService
	{
		private readonly IRoleRespository roleRepository;
		public RoleService(IRoleRespository roleRepository)
		{
			this.roleRepository = roleRepository;
		}
		public int GetRoleIDByName(string name)
		{
			return roleRepository.GetRoleIDByName(name);
		}
	}
}
