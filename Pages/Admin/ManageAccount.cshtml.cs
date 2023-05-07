using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class ManageAccountModel : PageModel
    {
		private readonly IStaffService staffService;
		private readonly IWardService wardService;
		private readonly IDistrictService districtService;		
		private readonly ICustomerService customerService;
		public StaffDTO staff { get; set; }
		public string address { get; set; }		
		public List<District> List_Districts { get; set; }
		public List<Ward> List_Wards { get; set; }		
		public List<CustomerDTO> List_Customers { get; set; }
		public List<StaffDTO> List_Staffs { get; set; }
		[BindProperty]
		public int StaID { get; set; }
		[BindProperty(SupportsGet = true)]
		public string Name { get; set; }
		[BindProperty(SupportsGet = true)]
		public string Email { get; set; }
		[BindProperty(SupportsGet = true)]
		public string Phone { get; set; }
		[BindProperty(SupportsGet = true)]
		public int Gender { get; set; }
		[BindProperty(SupportsGet = true)]
		public int DistrictID { get; set; }
		[BindProperty(SupportsGet = true)]
		public int WardID { get; set; }
		[BindProperty(SupportsGet = true)]
		public int wardId { get; set; }
		[BindProperty(SupportsGet = true)]
		public string HouseNum { get; set; }
		public ManageAccountModel(IStaffService staffService, IWardService wardService, IDistrictService districtService, 
								  ICustomerService customerService)
        {
            this.staffService = staffService;
			this.wardService = wardService;
			this.districtService = districtService;			
			this.customerService = customerService;
		}		
        public IActionResult OnGet()
        {
			List_Districts = districtService.GetListDistricts();
			List_Wards = wardService.GetListWards();			
			List_Customers = customerService.GetAllCustomers();
			List_Staffs = staffService.GetAllStaffs();
			var staffId = HttpContext.Session.GetInt32("staffID");			
			if (staffId != null)
			{				
				staff = staffService.GetStaff((int)staffId);
				var oldName = HttpContext.Session.GetString("Name");
				if (oldName != staff.StaName)
				{
					HttpContext.Session.SetString("Name", staff.StaName);
				}
				if (staff.WardID != 0)
				{
					var wrd = wardService.GetWard((int)staff.WardID);
					var dis = districtService.GetDistrict(wrd.DistrictID);
					address = staff.HouseNumber + ", " + wrd.WardName + ", " + dis.DistrictName + ", Đà Nẵng";					
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
			var wrd = new Ward(); var dis = new District();
			wrd.WardId = 0; dis.DistrictID = 0;
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
				wrdd = wrd.WardName,
				wrdID = wrd.WardId,
				diss = dis.DistrictName,
				disID = dis.DistrictID,
				housenum = sta.HouseNumber
			};
			return new JsonResult(result);
		}

		public IActionResult OnPostUpdate()
		{					
			staffService.UpdateInfo(StaID, Name, Email, Phone, Gender, HouseNum, wardId);
			return RedirectToPage("ManageAccount");
		}
	}
}
