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
		public int GetCustomerID(int accountID)
		{
			return customerRespository.GetCustomerID(accountID);
		}
		public CustomerDTO GetCustomer(int id)
		{
			return customerRespository.GetCustomer(id);
		}

		public List<CustomerDTO> GetListCustomers(string arrange, bool isDescending, string searchText)
		{
			return customerRespository.GetListCustomers(arrange, isDescending, searchText);
		}

		public void UpdateData(int id, int roleID)
		{
			customerRespository.UpdateData(id, roleID);
		}
		public void DeleteData(int id)
		{
			customerRespository.DeleteData(id);
		}
		public List<CustomerDTO> GetAllCustomers()
		{
			return customerRespository.GetAllCustomers();
		}
		public void UpdateInfo(int id, string name, string email, string phone, int gender, string house, int WardID)
		{
			customerRespository.UpdateInfo(id, name, email, phone, gender, house, WardID);
		}
		public void AddNewCus(string name, string phone)
		{
			customerRespository.AddNewCus(name, phone);
		}
		public int GetCusIDByPhone(string phone)
		{
			return customerRespository.GetCusIDByPhone(phone);
		}
    }
}
