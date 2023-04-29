using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface ICustomerService
    {
		int GetCustomerID(int accountID);
		CustomerDTO GetCustomer(int id);
		List<CustomerDTO> GetListCustomers(string arrange, bool isDescending, string searchText);
	}
}
