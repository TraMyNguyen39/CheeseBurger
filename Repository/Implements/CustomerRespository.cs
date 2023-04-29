using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;

namespace CheeseBurger.Repository.Implements
{
	public class CustomerRespository : ICustomerRespository
	{
		private readonly CheeseBurgerContext context;
		public CustomerRespository(CheeseBurgerContext context)
		{
			this.context = context;
		}
		public CustomerDTO GetCustomer(int id)
		{
			var cus_data = from c in context.Customers
						   join a in context.Accounts on c.AccountID equals a.AccountID
						   join adr in context.Addresses on c.AddressID equals adr.AddressID
						   select new CustomerDTO
						   {
							   CusID = c.CustomerID,
							   CusName = c.CustomerName,
							   CusGender = c.Gender,
							   CusPhone = c.Phone,
							   CusEmail = a.Email,
							   CusIsStaff = a.isStaff,
							   CusAccID = a.AccountID,
							   CusAddID = adr.AddressID
						   };
			return cus_data.Where(p => p.CusID == id).FirstOrDefault();
		}

		public List<CustomerDTO> GetListCustomers(string arrange, bool isDescending, string searchText)
		{
			var cus_data = from c in context.Customers
						   join a in context.Accounts on c.AccountID equals a.AccountID
						   join adr in context.Addresses on c.AddressID equals adr.AddressID
						   select new CustomerDTO
						   {
							   CusID = c.CustomerID,
							   CusName = c.CustomerName,
							   CusGender = c.Gender,
							   CusPhone = c.Phone,
							   CusEmail = a.Email,
							   CusIsStaff = a.isStaff,
							   CusAccID = a.AccountID,
							   CusAddID = adr.AddressID
						   };						 
			if (!searchText.IsNullOrEmpty())
			{
				cus_data = cus_data.Where(p => p.CusName.Contains(searchText)).Select(p => p);
			}
			switch (arrange)
			{
				case "name":
					cus_data = isDescending ? cus_data.OrderByDescending(p => p.CusName) : cus_data.OrderBy(p => p.CusName);
					break;
			}		
			return cus_data.ToList();
		}
	}
}
