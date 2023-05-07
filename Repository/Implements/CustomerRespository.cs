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
						   select new { c, a};
			
			var customer = from p in cus_data
						   from adr in context.Wards.Where(adr => adr.WardId == p.c.WardID).DefaultIfEmpty()
						   select new CustomerDTO
						   {
							   CusID = p.c.CustomerID,
							   CusName = p.c.CustomerName,
							   CusGender = p.c.Gender ?? true,
							   CusPhone = p.c.Phone,
							   CusEmail = p.a.Email,
							   CusIsStaff = p.a.isStaff,
							   CusIsDeleted = p.a.isDeleted,
							   CusAccID = p.a.AccountID,
							   WardID = (adr == null) ? 0 : adr.WardId,
							   HouseNumber = p.c.HouseNumber
						   };
			return customer.Where(p => p.CusID == id).FirstOrDefault();
		}

		public List<CustomerDTO> GetListCustomers(string arrange, bool isDescending, string searchText)
		{
			var cus_data = from c in context.Customers
						   join a in context.Accounts on c.AccountID equals a.AccountID
						   select new { c, a };

			var customer = from p in cus_data
						   from adr in context.Wards.Where(adr => adr.WardId == p.c.WardID).DefaultIfEmpty()
						   select new CustomerDTO
						   {
							   CusID = p.c.CustomerID,
							   CusName = p.c.CustomerName,
							   CusGender = p.c.Gender ?? true,
							   CusPhone = p.c.Phone,
							   CusEmail = p.a.Email,
							   CusIsStaff = p.a.isStaff,
							   CusIsDeleted = p.a.isDeleted,
							   CusAccID = p.a.AccountID,
							   WardID = (adr == null) ? 0 : adr.WardId,
							   HouseNumber = p.c.HouseNumber
						   };						 
			if (!searchText.IsNullOrEmpty())
			{
				customer = customer.Where(p => p.CusName.Contains(searchText)).Select(p => p);
			}
			switch (arrange)
			{
				case "name":
					customer = isDescending ? customer.OrderByDescending(p => p.CusName) : customer.OrderBy(p => p.CusName);
					break;
			}		
			return customer.ToList();
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
					WardID = cus_data.WardID,
					HouseNumber = cus_data.HouseNumber,
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
		public List<CustomerDTO> GetAllCustomers()
		{
			var cus_data = from c in context.Customers
						   join a in context.Accounts on c.AccountID equals a.AccountID
						   select new { c, a };

			var customer = from p in cus_data
						   from adr in context.Wards.Where(adr => adr.WardId == p.c.WardID).DefaultIfEmpty()
						   select new CustomerDTO
						   {
							   CusID = p.c.CustomerID,
							   CusName = p.c.CustomerName,
							   CusGender = p.c.Gender ?? true,
							   CusPhone = p.c.Phone,
							   CusEmail = p.a.Email,
							   CusIsStaff = p.a.isStaff,
							   CusIsDeleted = p.a.isDeleted,
							   CusAccID = p.a.AccountID,
							   WardID = (adr == null) ? 0 : adr.WardId,
							   HouseNumber = p.c.HouseNumber
						   };
			return customer.ToList();
		}
		public void UpdateInfo(int id, string name, string email, string phone, int gender, string house, int WardID)
		{
            var cus_data = context.Customers.Where(p => p.CustomerID == id).Select(p => p).FirstOrDefault();
            var cus_acc = context.Accounts.Where(p => p.AccountID == cus_data.AccountID).Select(p => p).FirstOrDefault();
            cus_data.CustomerName = name;
            cus_data.HouseNumber = (house == "") ? null : house;
            cus_data.Gender = (gender == 1 ? true : false);
            cus_data.Phone = phone;
            cus_data.WardID = (WardID == 0) ? null : WardID;
            cus_acc.Email = email;
            context.SaveChanges();
        }
    }
}
