using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class TPassService : ITPassService
	{
		private readonly ITPassRespository tPassRespository;
		public TPassService(ITPassRespository tPassRespository)
		{
			this.tPassRespository = tPassRespository;
		}
        public List<TPass> GetListTPass()
        {
			return tPassRespository.GetListTPass();
		}		
		public string GetNameTPassByID(int id)
        {
			return tPassRespository.GetNameTPassByID(id);
		}
    }
}
