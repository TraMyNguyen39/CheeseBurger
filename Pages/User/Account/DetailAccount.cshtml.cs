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
		private readonly IWardService wardService;
		private readonly IDistrictService districtService;
		public CustomerDTO customer { get; set; }
        public string address { get; set; }
        public DetailAccountModel (ICustomerService customerService, IWardService wardService, IDistrictService districtService)
        {
            this.customerService = customerService;
			this.wardService = wardService;
			this.districtService = districtService;
        }

		public IActionResult OnGet()
        {
            var customerId = HttpContext.Session.GetInt32("customerID");
            if (customerId != null)
            {
				customer = customerService.GetCustomer((int)customerId);
				var oldName = HttpContext.Session.GetString("Name");
				if (oldName != customer.CusName)
				{
					HttpContext.Session.SetString("Name", customer.CusName);
				}
				if (customer.WardID != 0)
				{
					var wrd = wardService.GetWard((int)customer.WardID);
					var dis = districtService.GetDistrict(wrd.DistrictID);
					address = customer.HouseNumber + ", " + wrd.WardName + ", " + dis.DistrictName + ", Đà Nẵng";
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