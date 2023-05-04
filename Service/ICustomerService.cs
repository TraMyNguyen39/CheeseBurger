using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface ICustomerService
    {
		int GetCustomerID(int accountID);
		CustomerDTO GetCustomer(int id);
		List<CustomerDTO> GetListCustomers(string arrange, bool isDescending, string searchText);
		void UpdateData(int id, int roleID);
		void DeleteData(int id);
	}
}
