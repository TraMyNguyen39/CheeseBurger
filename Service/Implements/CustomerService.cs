using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRespository	customerRespository;
		public CustomerService (ICustomerRespository customerRespository)
		{
			this.customerRespository = customerRespository;
		}
		public int GetCustomerID(int accountID)
		{
			return customerRespository.GetCustomerID(accountID);
		}
	}
}
