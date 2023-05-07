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
		List<CustomerDTO> GetAllCustomers();
		void UpdateInfo(int id, string name, string email, string phone, int gender, string house, int WardID);

    }
}
