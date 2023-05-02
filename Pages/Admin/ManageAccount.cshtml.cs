using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class ManageAccountModel : PageModel
    {
		private readonly IStaffService staffService;
		private readonly IAddressService addressService;
		private readonly IWardService wardService;
		private readonly IDistrictService districtService;
		public StaffDTO staff { get; set; }
		public string address { get; set; }		
		public List<District> List_Districts { get; set; }
		public List<Ward> List_Wards { get; set; }
        public ManageAccountModel(IStaffService staffService, IAddressService addressService, IWardService wardService, IDistrictService districtService)
        {
            this.staffService = staffService;
			this.addressService = addressService;
			this.wardService = wardService;
			this.districtService = districtService;
		}
        public IActionResult OnGet()
        {
			List_Districts = districtService.GetListDistricts();
			List_Wards = wardService.GetListWards();
			var staffId = HttpContext.Session.GetInt32("staffID");
			if (staffId != null)
			{
				staff = staffService.GetStaff((int)staffId);
				if (staff.StaAddID != 0)
				{
					var adr = addressService.GetAddress((int)staff.StaAddID);
					var wrd = wardService.GetWard(adr.WardID);
					var dis = districtService.GetDistrict(wrd.DistrictID);
					address = adr.NumberHouse + ", " + wrd.WardName + ", " + dis.DistrictName + ", Đà Nẵng";					
				}
				return Page();
			} else
			{
				return RedirectToPage("/Login/LoginRegister");
			}
		}
		public IActionResult OnGetFind(int id)
		{
			var sta = staffService.GetStaff(id);
			var adr = addressService.GetAddress(sta.StaAddID);
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
				wrdd = wrd.WardName,
				diss = dis.DistrictName,
				disID = dis.DistrictID,
				housenum = adr.NumberHouse
			};
			return new JsonResult(result);
		}
	}
}
