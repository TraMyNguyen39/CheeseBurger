using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class NewPassService : INewPassService
	{
		private readonly INewPassRespository newPassRespository;
		public NewPassService(INewPassRespository newPassRespository)
		{
			this.newPassRespository = newPassRespository;
		}
        public List<NewPass> GetListNewPass()
		{
			return newPassRespository.GetListNewPass();
		}		
		public string GetNamePassByID(int id)
		{
			return newPassRespository.GetNamePassByID(id);
		}
    }
}
