﻿using CheeseBurger.DTO;
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
		
	}
}
