using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using Microsoft.IdentityModel.Tokens;

namespace CheeseBurger.Repository.Implements
{
	public class StaffRespository : IStaffRespository
	{
		private readonly CheeseBurgerContext context;
		public StaffRespository(CheeseBurgerContext context)
		{
			this.context = context;
		}
		public StaffDTO GetStaff(int id)
		{
			var sta_data = from c in context.Staffs
						   join a in context.Accounts on c.AccountID equals a.AccountID
						   join adr in context.Addresses on c.AddressID equals adr.AddressID
						   join rol in context.Roles on c.RoleID equals rol.RoleID
						   select new StaffDTO
						   {
							   StaID = c.StaffID,
							   StaName = c.StaffName,
							   StaGender = c.Gender,
							   StaPhone = c.Phone,
							   StaEmail = a.Email,
							   StaIsStaff = a.isStaff,
							   StaIsDeleted = a.isDeleted,
							   StaAccID = a.AccountID,
							   StaAddID = adr.AddressID,
							   StaRoleName = rol.RoleName
						   };
			return sta_data.Where(p => p.StaID == id).FirstOrDefault();
		}
		public List<StaffDTO> GetListStaffs(string role, string arrange, bool isDescending, string searchText)
		{
			var sta_data = from c in context.Staffs
						   join a in context.Accounts on c.AccountID equals a.AccountID
						   join adr in context.Addresses on c.AddressID equals adr.AddressID
						   join rol in context.Roles on c.RoleID equals rol.RoleID
						   select new StaffDTO
						   {
							   StaID = c.StaffID,
							   StaName = c.StaffName,
							   StaGender = c.Gender,
							   StaPhone = c.Phone,
							   StaEmail = a.Email,
							   StaIsStaff = a.isStaff,
							   StaIsDeleted = a.isDeleted,
							   StaAccID = a.AccountID,
							   StaAddID = adr.AddressID,
							   StaRoleName = rol.RoleName
						   };
			switch (role)
			{
				case "admin":
					sta_data = sta_data.Where(p => p.StaRoleName.Equals("Quản trị viên")).Select(p => p);
					break;
				case "chef":
					sta_data = sta_data.Where(p => p.StaRoleName.Equals("Nhân viên đầu bếp")).Select(p => p);
					break;
				case "shipper":
					sta_data = sta_data.Where(p => p.StaRoleName.Equals("Nhân viên giao hàng")).Select(p => p);
					break;
			}
			if (!searchText.IsNullOrEmpty())
			{
				sta_data = sta_data.Where(p => p.StaName.Contains(searchText)).Select(p => p);
			}
			switch (arrange)
			{
				case "name":
					sta_data = isDescending ? sta_data.OrderByDescending(p => p.StaName) : sta_data.OrderBy(p => p.StaName);
					break;
			}
			return sta_data.ToList();
		}
		public void UpdateData(int id, int RoleID)
		{
			var sta_data = context.Staffs.Where(p => p.StaffID == id).Select(p => p).FirstOrDefault();
			if (sta_data.RoleID != RoleID)
			{
				sta_data.RoleID = RoleID;
				context.SaveChanges();
			}
		}
		public void AddCusData(int id, int RoleID)
		{
			var sta_data = context.Staffs.Where(p => p.StaffID == id).Select(p => p).FirstOrDefault();
			var cus_data = context.Customers.Where(p => p.Phone.Equals(sta_data.Phone)).Select(p => p).FirstOrDefault();
			var sta_acc = context.Accounts.Where(p => p.AccountID == sta_data.AccountID).Select(p => p).FirstOrDefault();
			if (cus_data == null)
			{
				sta_acc.isStaff = false;
				var cus = new Customer
				{
					CustomerName = sta_data.StaffName,
					Phone = sta_data.Phone,
					Gender = sta_data.Gender,
					AccountID = sta_data.AccountID,
					AddressID = sta_data.AddressID,
				};
				context.Customers.Add(cus);
				context.SaveChanges();
			} else
			{
				sta_acc.isStaff = false;
				context.SaveChanges();
			}
		}
	}
}
