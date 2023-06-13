using CheeseBurger.DTO;
using CheeseBurger.Middleware;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Security;

namespace CheeseBurger.Pages
{
    [Authorize("Quản trị viên")]
    public class ManageUserModel : PageModel
    {
        private readonly ICustomerService customerService;
        private readonly IWardService wardService;
        private readonly IDistrictService districtService;
        private readonly IRoleService roleService;		
		public List<CustomerDTO> customers { get; set; }
        public string sortBy { get; set; }
        public string searchText { get; set; }
		[BindProperty(SupportsGet = true, Name = "p")]
		public int currentPage { get; set; }
		public string MessageUser { get; set; }
		public ManageUserModel(ICustomerService customerService, IWardService wardService,
								IDistrictService districtService, IRoleService roleService)
        {
            this.customerService = customerService;
            this.wardService = wardService;
            this.districtService = districtService;
            this.roleService = roleService;
        }
        public void OnGet()
        {
			this.sortBy = Request.Query["sortBy"];
			this.searchText = Request.Query["search"];
			if (this.searchText != null) this.searchText = this.searchText.Trim();
            if (sortBy == "all")
            {
                customers = customerService.GetListCustomers(null, true, searchText);
            }
            else if (!(sortBy.IsNullOrEmpty()))
			{
				string[] values = sortBy.Split('-');
				string arrange = values[0];
				bool isDescending = (values[1] == "desc");
				customers = customerService.GetListCustomers(arrange, isDescending, searchText);
			}
			else
			{
				customers = customerService.GetListCustomers(null, true, searchText);
			}  
            if (customers.Count == 0)
            {
				MessageUser = "Không có khách hàng nào đáp ứng điều kiện!";
			} else { MessageUser = null;  }         
		}

        public IActionResult OnGetFind(int id)
        {
            var cus = customerService.GetCustomer(id);
            var wrd = new Ward(); var dis = new District();
            if (cus.WardID != 0)
            {
				wrd = wardService.GetWard(cus.WardID);
				dis = districtService.GetDistrict(wrd.DistrictID);                
			}
            var result = new
            {
                id = cus.CusID,
                name = cus.CusName,
                gender = cus.CusGender,
                phone = cus.CusPhone,
                email = cus.CusEmail,
                address = (cus.WardID != 0) ? (cus.HouseNumber + ", " + wrd.WardName + ", " + dis.DistrictName + ", Đà Nẵng") : "",
				wrdd = wrd.WardName,
                diss = dis.DistrictName,
                housenum = cus.HouseNumber
            };          
            return new JsonResult(result);
        }

        public IActionResult OnPostUpdate(int CusID, string combobox_Item)
        {
            if (string.IsNullOrEmpty(combobox_Item))
            {
                ModelState.AddModelError("combobox_Item", "Please select a role");
            }
            var FindIDRole = roleService.GetRoleIDByName(combobox_Item);
            if (FindIDRole != 0)
            {
                customerService.UpdateData(CusID, FindIDRole);
            } 
            return RedirectToPage("/Admin/ManageUser");
        }
        public IActionResult OnPostDelete(int CusID)
        {
            customerService.DeleteData(CusID);
            return RedirectToPage("/Admin/ManageUser");
        }
		public IActionResult OnPostRecycle(int CusID)
		{
			customerService.RecycleData(CusID);
			return RedirectToPage("/Admin/ManageUser");
		}
	}
}
