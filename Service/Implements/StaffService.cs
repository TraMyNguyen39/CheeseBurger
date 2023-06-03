using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class StaffService : IStaffService
	{
		private readonly IStaffRespository staffRespository;
		public StaffService(IStaffRespository staffRespository)
		{
			this.staffRespository = staffRespository;
		}

		public int GetStaffID(int accountID)
		{
			return staffRespository.GetStaffID(accountID);
		}
		public List<StaffDTO> GetListStaffs(string role, string arrange, bool isDescending, string searchText)
		{
			return staffRespository.GetListStaffs(role, arrange, isDescending, searchText);
		}

		public StaffDTO GetStaff(int id)
		{
			return staffRespository.GetStaff(id);
		}
		public void UpdateData(int id, int RoleID)
		{
			staffRespository.UpdateData(id, RoleID);
		}
		public void AddCusData(int id, int RoleID)
		{
			staffRespository.AddCusData(id, RoleID);
		}
		public void DeleteData(int id)
		{
			staffRespository.DeleteData(id);
		}
		public void UpdateInfo(int id, string name, string email, string phone, int gender, string house, int WardID)
		{
			staffRespository.UpdateInfo(id, name, email, phone, gender, house, WardID);
		}
		public List<StaffDTO> GetAllStaffs()
		{
			return staffRespository.GetAllStaffs();
		}
		public StaffOrderDTO GetStaffOrder(int id)
		{
			return staffRespository.GetStaffOrder(id);
		}

		public string GetStaffRole(int staffID)
		{
			return staffRespository.GetStaffRole(staffID);
		}
		public void RecycleData(int id)
		{
			staffRespository.RecycleData(id);
		}
	}
}
