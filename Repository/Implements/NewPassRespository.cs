using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
	public class NewPassRespository : INewPassRespository
    {
		private readonly CheeseBurgerContext context;
		public NewPassRespository(CheeseBurgerContext context)
		{
			this.context = context;
		}
		public List<NewPass> GetListNewPass()
		{
			return context.NewPasses.Select(p => p).ToList();
		}	
		public string GetNamePassByID(int id)
		{
			var _newpass = context.NewPasses.FirstOrDefault(p => p.NewPassID == id);
			return _newpass.NewPassName;
		}
    }
}
