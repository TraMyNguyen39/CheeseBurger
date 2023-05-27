using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class IdenCodeService : IIdenCodeService
    {
		private readonly IIdenCodeRespository idenCodeRespository;
		public IdenCodeService(IIdenCodeRespository idenCodeRespository)
		{
			this.idenCodeRespository = idenCodeRespository;
		}        
        public List<IdenCode> GetListIdenCode()
        {
			return idenCodeRespository.GetListIdenCode();
		}		
		public string GetNameIdenCodeByID(int id)
        {
			return idenCodeRespository.GetNameIdenCodeByID(id);
		}
    }
}
