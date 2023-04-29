using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRespository customerRespository;
		public CustomerService(ICustomerRespository customerRespository)
		{
			this.customerRespository = customerRespository;
		}
		public CustomerDTO GetCustomer(int id)
		{
			return customerRespository.GetCustomer(id);
		}

		public List<CustomerDTO> GetListCustomers(string arrange, bool isDescending, string searchText)
		{
			return customerRespository.GetListCustomers(arrange, isDescending, searchText);
		}
	}
}
