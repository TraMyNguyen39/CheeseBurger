using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Net.Security;

namespace CheeseBurger.Pages
{
    public class ManageUserModel : PageModel
    {
        private readonly ICustomerService customerService;
        private readonly IAddressService addressService;
        private readonly IWardService wardService;
        private readonly IDistrictService districtService;
        private readonly IRoleService roleService;		
		public List<CustomerDTO> customers { get; set; }
        public string sortBy { get; set; }
        public string searchText { get; set; }
        public ManageUserModel(ICustomerService customerService, IAddressService addressService, IWardService wardService,
								IDistrictService districtService, IRoleService roleService)
        {
            this.customerService = customerService;
            this.addressService = addressService;
            this.wardService = wardService;
            this.districtService = districtService;
            this.roleService = roleService;
        }
        public void OnGet()
        {
			this.sortBy = Request.Query["sortBy"];
			this.searchText = Request.Query["search"];
			if (this.searchText != null) this.searchText = this.searchText.Trim();			
			if (!(sortBy.IsNullOrEmpty()) || sortBy == "all")
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
		}

        public IActionResult OnGetFind(int id)
        {
            var cus = customerService.GetCustomer(id);
            var adr = addressService.GetAddress(cus.CusAddID);
            var wrd = wardService.GetWard(adr.WardID);
            var dis = districtService.GetDistrict(wrd.DistrictID);
            var result = new
            {
                id = cus.CusID,
                name = cus.CusName,
                gender = cus.CusGender,
                phone = cus.CusPhone,
                email = cus.CusEmail,
                address = adr.NumberHouse + ", " + wrd.WardName + ", " + dis.DistrictName + ", Đà Nẵng",
                wrdd = wrd.WardName,
                diss = dis.DistrictName,
                housenum = adr.NumberHouse
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
            return RedirectToPage("ManageUser");
        }
        public IActionResult OnPostDelete(int CusID)
        {
            customerService.DeleteData(CusID);
            return RedirectToPage("ManageUser");
        }
    }
}
