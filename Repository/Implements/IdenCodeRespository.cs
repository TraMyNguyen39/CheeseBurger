using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
	public class IdenCodeRespository : IIdenCodeRespository
    {
		private readonly CheeseBurgerContext context;
		public IdenCodeRespository(CheeseBurgerContext context)
		{
			this.context = context;
		}
        public List<IdenCode> GetListIdenCode()
        {
			return context.IdenCodes.Select(p => p).ToList();
		}	
		public string GetNameIdenCodeByID(int id)
        {
			var _idencode = context.IdenCodes.FirstOrDefault(p => p.IcodeId == id);
			return _idencode.ICodeName;
		}
    }
}
