using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
	public class TPassRespository : ITPassRespository
    {
		private readonly CheeseBurgerContext context;
		public TPassRespository(CheeseBurgerContext context)
		{
			this.context = context;
		}
		public List<TPass> GetListTPass()
        {
			return context.TPasses.Select(p => p).ToList();
		}	
		public string GetNameTPassByID(int id)
        {
			var _tpass = context.TPasses.FirstOrDefault(p => p.TPassID == id);
			return _tpass.TPassName;
		}
    }
}
