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
		public int GetCustomerID(int accountID)
		{
			var customer = context.Customers.Where(p => p.AccountID == accountID).Select(p => p).FirstOrDefault();
			return customer != null ? customer.CustomerID : 0;
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
							   CusIsDeleted = a.isDeleted,
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
							   CusIsDeleted = a.isDeleted,
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
		public void UpdateData(int id, int roleID)
		{			
			var cus_data = context.Customers.Where(p => p.CustomerID == id).Select(p => p).FirstOrDefault();
			var sta_data = context.Staffs.Where(p => p.Phone.Equals(cus_data.Phone)).Select(p => p).FirstOrDefault();
			var cus_acc = context.Accounts.Where(p => p.AccountID == cus_data.AccountID).Select(p => p).FirstOrDefault();
			if (sta_data == null) 
			{				
				cus_acc.isStaff = true;
				var staff = new Staff
				{
					StaffName = cus_data.CustomerName,
					Phone = cus_data.Phone,
					Gender = cus_data.Gender,
					AccountID = cus_data.AccountID,
					RoleID = roleID,
					AddressID = cus_data.AddressID
				};
				context.Staffs.Add(staff);
				context.SaveChanges();
			}
			else
			{
				cus_acc.isStaff = true;
				sta_data.RoleID = roleID;
				context.SaveChanges();
			}
		}
		public void DeleteData(int id)
		{
			var cus_data = context.Customers.Where(p => p.CustomerID == id).Select(p => p).FirstOrDefault();
			var cus_acc = context.Accounts.Where(p => p.AccountID == cus_data.AccountID).Select(p => p).FirstOrDefault();
			cus_acc.isDeleted = true;
			context.SaveChanges();
		}
	}
}
