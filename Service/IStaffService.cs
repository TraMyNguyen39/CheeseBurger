using CheeseBurger.DTO;

namespace CheeseBurger.Service
{
    public interface IStaffService
    {
		StaffDTO GetStaff(int id);
		List<StaffDTO> GetListStaffs(string role, string arrange, bool isDescending, string searchText);
		void UpdateData(int id, int RoleID);
		void AddCusData(int id, int RoleID);
		void DeleteData(int id);
	}
}
