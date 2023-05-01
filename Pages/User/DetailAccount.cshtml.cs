using CheeseBurger.DTO;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class DetailAccountModel : PageModel
    {
		private readonly ICustomerService customerService;
		private readonly IAddressService addressService;
		private readonly IWardService wardService;
		private readonly IDistrictService districtService;
		public CustomerDTO customer { get; set; }
        public string address { get; set; }
        public DetailAccountModel (ICustomerService customerService, IAddressService addressService, IWardService wardService, IDistrictService districtService)
        {
            this.customerService = customerService;
			this.addressService = addressService;
			this.wardService = wardService;
			this.districtService = districtService;
        }

		public IActionResult OnGet()
        {
            var customerId = HttpContext.Session.GetInt32("customerID");
            if (customerId != null)
            {
				customer = customerService.GetCustomer((int)customerId);
				if (customer.CusAddID != 0)
				{
					var adr = addressService.GetAddress((int)customer.CusAddID);
					var wrd = wardService.GetWard(adr.WardID);
					var dis = districtService.GetDistrict(wrd.DistrictID);
					address = adr.NumberHouse + ", " + wrd.WardName + ", " + dis.DistrictName + ", Đà Nẵng";
				}
				return Page();
			}
			else
            {
                return RedirectToPage("/Login/LoginRegister");
            }
		}

    }
}