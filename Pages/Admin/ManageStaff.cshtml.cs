using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace CheeseBurger.Pages
{
    public class ManageStaffModel : PageModel
    {
        private readonly IStaffService staffService;
        private readonly IRoleService roleService;
		private readonly IAddressService addressService;
		private readonly IWardService wardService;
		private readonly IDistrictService districtService;
        public List<StaffDTO> staffs { set; get; }
		public string roleBy { get; set; }
		public string sortBy { get; set; }
		public string searchText { get; set; }
		public ManageStaffModel(IStaffService staffService, IRoleService roleService, IAddressService addressService, IWardService wardService,
								IDistrictService districtService)
        {
            this.staffService = staffService;
            this.roleService = roleService;
            this.addressService = addressService;
            this.wardService = wardService;
            this.districtService = districtService;
        }
        public void OnGet()
        {
			this.roleBy = Request.Query["roleBy"];
			this.sortBy = Request.Query["sortBy"];
			this.searchText = Request.Query["search"];
			if (this.searchText != null) this.searchText = this.searchText.Trim();			
			if (!(sortBy.IsNullOrEmpty()) || sortBy == "all")
			{
				string[] values = sortBy.Split('-');
				string arrange = values[0];
				bool isDescending = (values[1] == "desc");
				staffs = staffService.GetListStaffs(roleBy, arrange, isDescending, searchText);
			}
			else
			{
				staffs = staffService.GetListStaffs(roleBy, null, true, searchText);
			}			
        }

		public IActionResult OnGetFind(int id)
		{
			var sta = staffService.GetStaff(id);			
			var adr = addressService.GetAddress(sta.StaAccID);
			var wrd = wardService.GetWard(adr.WardID);
			var dis = districtService.GetDistrict(wrd.DistrictID);
			var result = new
			{
				id = sta.StaID,
				name = sta.StaName,
				gender = sta.StaGender,
				phone = sta.StaPhone,
				email = sta.StaEmail,
				rolnamee = sta.StaRoleName,
				address = adr.NumberHouse + ", " + wrd.WardName + ", " + dis.DistrictName,
				wrdd = wrd.WardName,
				diss = dis.DistrictName,
				housenum = adr.NumberHouse
			};
			return new JsonResult(result);
		}

		public IActionResult OnPostUpdate(int StaID, string combobox_Item)
		{
			if (string.IsNullOrEmpty(combobox_Item))
			{
				ModelState.AddModelError("combobox_Item", "Please select a role");
			}
			var FindIDRole = roleService.GetRoleIDByName(combobox_Item);
			if (FindIDRole != 0)
			{
				staffService.UpdateData(StaID, FindIDRole);
			} else
			{
				staffService.AddCusData(StaID, FindIDRole);
			}
			return RedirectToPage("ManageStaff");
		}
	}
}
