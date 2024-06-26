﻿using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IStaffRespository
    {
        int GetStaffID(int accountID);
        StaffDTO GetStaff(int id);
		StaffOrderDTO GetStaffOrder(int id);
        List<StaffDTO> GetListStaffs(string role, string arrange, bool isDescending, string searchText);
        void UpdateData(int id, int RoleID);
        void AddCusData(int id, int RoleID);
        void DeleteData(int id);
        void UpdateInfo(int id, string name, string email, string phone, int gender, string house, int WardID);
        List<StaffDTO> GetAllStaffs();
        string GetStaffRole(int staffID);
		void RecycleData(int id);
        List<StaffDTO> GetStaffChef();
        List<StaffDTO> GetStaffShip();
        List<StaffDTO> GetListStaIsSta();
        List<StaffDTO> GetListStaNotID(int id);
	}
}
