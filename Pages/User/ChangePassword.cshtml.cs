using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class ChangePasswordModel : PageModel
    {
		private readonly ICustomerService customerService;
		private readonly IAccountService accountService;
		public CustomerDTO customer { get; set; }
		public string currentPassword { get; set; }
		[BindProperty(SupportsGet = true)]
		public string newPassword { get; set; }
        public ChangePasswordModel(ICustomerService customerService, IAccountService accountService)
        {
            this.customerService = customerService;
            this.accountService = accountService;
        }
		public IActionResult OnGet()
		{
			var customerId = HttpContext.Session.GetInt32("customerID");
			if (customerId != null)
			{
				customer = customerService.GetCustomer((int)customerId);
				currentPassword = accountService.GetPasswordbyID((int)customer.CusAccID);
				return Page();
			}
			else
			{
				return RedirectToPage("/Login/LoginRegister");
			}
		}
        public IActionResult OnPostUpdate()
        {
            var customerId = HttpContext.Session.GetInt32("customerID");
            if (customerId != null)
            {
                customer = customerService.GetCustomer((int)customerId);
                accountService.ChangePassword((int)customer.CusAccID, newPassword);
                return RedirectToPage("DetailAccount");
            }
            else
            {
                return RedirectToPage("/Login/LoginRegister");
            }
        }
    }
}