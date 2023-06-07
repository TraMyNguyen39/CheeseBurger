using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace CheeseBurger.Pages
{
    public class UpdateInfoAccountModel : PageModel
    {
        private readonly IStaffService staffService;
        private readonly IWardService wardService;
        private readonly IDistrictService districtService;
        private readonly ICustomerService customerService;
        public CustomerDTO customer { get; set; }
        public List<District> List_Districts { get; set; }
        public List<Ward> List_Wards { get; set; }
        public List<CustomerDTO> List_Customers { get; set; }
        public List<StaffDTO> List_Staffs { get; set; }    
        public int curWardID { get; set; }
        public int curDisID { get; set; }
        public int curGender { get; set; }
        [BindProperty]
        public int CusID { get; set; }
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
        public UpdateInfoAccountModel(IStaffService staffService, IWardService wardService, IDistrictService districtService, ICustomerService customerService)
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
            List_Staffs = staffService.GetListStaIsSta();
            var customerId = HttpContext.Session.GetInt32("customerID");
			List_Customers = customerService.GetListCusNotId((int)customerId);
			if (customerId != null)
            {
                customer = customerService.GetCustomer((int)customerId);
                curWardID = 0; curDisID = 0; curGender = 1;
                if (customer.CusGender == false) curGender = 2;
                var oldName = HttpContext.Session.GetString("Name");
                if (oldName != customer.CusName)
                {
                    HttpContext.Session.SetString("Name", customer.CusName);
                }
                if (customer.WardID != 0)
                {
                    curWardID = customer.WardID;
                    var wrd = wardService.GetWard((int)customer.WardID);
                    curDisID = districtService.GetDistrict(wrd.DistrictID).DistrictID;
                }                
                return Page();
            }
            else
            {
                return RedirectToPage("/Login/LoginRegister");
            }
        }
        public IActionResult OnPostUpdate()
        {
            customerService.UpdateInfo(CusID, Name, Email, Phone, Gender, HouseNum, wardId);
            return RedirectToPage("UpdateInfoAccount");
        }
    }
}