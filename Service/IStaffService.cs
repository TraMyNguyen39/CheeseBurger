using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface IStaffService
    {
		int GetStaffID(int accountID);
		StaffDTO GetStaff(int id);
		List<StaffDTO> GetListStaffs(string role, string arrange, bool isDescending, string searchText);
		StaffOrderDTO GetStaffOrder(int id);
		void UpdateData(int id, int RoleID);
		void AddCusData(int id, int RoleID);
		void DeleteData(int id);
		void UpdateInfo(int id, string name, string email, string phone, int gender, string house, int WardID);
		List<StaffDTO> GetAllStaffs();
		string GetStaffRole(int staffID);
		void RecycleData(int id);
		List<StaffDTO> GetListStaIsSta();
		List<StaffDTO> GetListStaNotID(int id);
	}
}
