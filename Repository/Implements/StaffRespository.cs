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

		public int GetStaffID(int accountID)
		{
			var staff = context.Staffs.Where(p => p.AccountID == accountID).Select(p => p).FirstOrDefault();
			return staff != null ? staff.StaffID : 0;
		}
		public StaffDTO GetStaff(int id)
		{
			var staff_data = from c in context.Staffs
							 join a in context.Accounts on c.AccountID equals a.AccountID
							 join rol in context.Roles on c.RoleID equals rol.RoleID
							 select new { c, a, rol };
			var sta_data = from p in staff_data
						   from adr in context.Wards.Where(adr => adr.WardId == p.c.WardID).DefaultIfEmpty()
						   select new StaffDTO
						   {
							   StaID = p.c.StaffID,
							   StaName = p.c.StaffName,
							   StaGender = p.c.Gender ?? true,
							   StaPhone = p.c.Phone,
							   StaEmail = p.a.Email,
							   StaIsStaff = p.a.isStaff,
							   StaIsDeleted = p.a.isDeleted,
							   StaAccID = p.a.AccountID,
							   WardID = (adr == null) ? 0 : adr.WardId,
							   StaRoleName = p.rol.RoleName ,
							   HouseNumber = p.c.HouseNumber
						   };
			return sta_data.Where(p => p.StaID == id).FirstOrDefault();
		}
		public List<StaffDTO> GetListStaffs(string role, string arrange, bool isDescending, string searchText)
		{
			var staff_data = from c in context.Staffs
							 join a in context.Accounts on c.AccountID equals a.AccountID
							 join rol in context.Roles on c.RoleID equals rol.RoleID
							 select new { c, a, rol };
			var sta_data = from p in staff_data
						   from adr in context.Wards.Where(adr => adr.WardId == p.c.WardID).DefaultIfEmpty()
						   select new StaffDTO
						   {
							   StaID = p.c.StaffID,
							   StaName = p.c.StaffName,
							   StaGender = p.c.Gender ?? true,
							   StaPhone = p.c.Phone,
							   StaEmail = p.a.Email,
							   StaIsStaff = p.a.isStaff,
							   StaIsDeleted = p.a.isDeleted,
							   StaAccID = p.a.AccountID,
							   WardID = (adr == null) ? 0 : adr.WardId,
							   StaRoleName = p.rol.RoleName,
							   HouseNumber = p.c.HouseNumber
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
					WardID = sta_data.WardID,
					HouseNumber = sta_data.HouseNumber,
				};
				context.Customers.Add(cus);
				context.SaveChanges();
			} else
			{
				sta_acc.isStaff = false;
				context.SaveChanges();
			}
		}
		public void DeleteData(int id)
		{
			var sta_data = context.Staffs.Where(p => p.StaffID == id).Select(p => p).FirstOrDefault();
			var cus_acc = context.Accounts.Where(p => p.AccountID == sta_data.AccountID).Select(p => p).FirstOrDefault();
			cus_acc.isDeleted = true;
			context.SaveChanges();
		}
		public void UpdateInfo(int id, string name, string email, string phone, string gender, string house, int WardID)
		{
			var sta_data = context.Staffs.Where(p => p.StaffID == id).Select(p => p).FirstOrDefault();
			var sta_acc = context.Accounts.Where(p => p.AccountID == sta_data.AccountID).Select(p => p).FirstOrDefault();
			sta_data.StaffName = name;
			sta_data.HouseNumber = house;
			sta_data.Gender = (gender == "Nam" ? true : false);
			sta_data.Phone = phone;
			sta_data.WardID = WardID;
			sta_acc.Email = email;
			context.SaveChanges();
		}
	}
}
