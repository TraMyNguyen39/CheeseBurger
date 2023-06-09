using CheeseBurger.DTO;
using CheeseBurger.Middleware;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace CheeseBurger.Pages
{
    [Authorize("Quản trị viên")]
    public class ManageStaffModel : PageModel
    {
        private readonly IStaffService staffService;
        private readonly IRoleService roleService;
		private readonly IWardService wardService;
		private readonly IDistrictService districtService;
        public List<StaffDTO> staffs { set; get; }
		public string roleBy { get; set; }
		public string sortBy { get; set; }
		public string searchText { get; set; }
		[BindProperty(SupportsGet = true, Name = "p")]
		public int currentPage { get; set; }
		public string MessageStaff { get; set; }	
		public int CurStaID { get; set; }
		public ManageStaffModel(IStaffService staffService, IRoleService roleService, IWardService wardService,
								IDistrictService districtService)
        {
            this.staffService = staffService;
            this.roleService = roleService;
            this.wardService = wardService;
            this.districtService = districtService;
        }
        public void OnGet()
        {
			this.roleBy = Request.Query["roleBy"];
			this.sortBy = Request.Query["sortBy"];
			this.searchText = Request.Query["search"];
			if (this.searchText != null) this.searchText = this.searchText.Trim();
			CurStaID = HttpContext.Session.GetInt32("staffID") ?? -1;
			if (sortBy == "all")
			{
				staffs = staffService.GetListStaffs(roleBy, null, true, searchText);
			}
			else if (!(sortBy.IsNullOrEmpty()))
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
			if (staffs.Count == 0)
			{
				MessageStaff = "Không có nhân viên nào đáp ứng điều kiện!";
			}
			else { MessageStaff = null; }
		}

		public IActionResult OnGetFind(int id)
		{
			var sta = staffService.GetStaff(id);
			var wrd = new Ward(); var dis = new District();
			if (sta.WardID != 0)
			{
				wrd = wardService.GetWard(sta.WardID);
				dis = districtService.GetDistrict(wrd.DistrictID);
			}		
			var result = new
			{
				id = sta.StaID,
				name = sta.StaName,
				gender = sta.StaGender,
				phone = sta.StaPhone,
				email = sta.StaEmail,
				rolnamee = sta.StaRoleName,
				address = (sta.WardID != 0) ? (sta.HouseNumber + ", " + wrd.WardName + ", " + dis.DistrictName + ", Đà Nẵng") : "",
				wrdd = wrd.WardName,
				diss = dis.DistrictName,
				housenum = sta.HouseNumber
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

		public IActionResult OnPostDelete(int StaID)
		{
			staffService.DeleteData(StaID);
			return RedirectToPage("ManageStaff");
		}
		public IActionResult OnPostRecycle(int StaID)
		{
			staffService.RecycleData(StaID);
			return RedirectToPage("ManageStaff");
		}
	}
}
