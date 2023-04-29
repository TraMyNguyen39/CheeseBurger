using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface ICustomerRespository
    {
		int GetCustomerID(int accountID);
		CustomerDTO GetCustomer(int id);
        List<CustomerDTO> GetListCustomers(string arrange, bool isDescending, string searchText);
    }
}
