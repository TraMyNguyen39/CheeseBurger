using CheeseBurger.DTO;
using CheeseBurger.Middleware;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace CheeseBurger.Pages.Admin
{
    [Authorize("Quản trị viên","Nhân viên đầu bếp","Nhân viên giao hàng")]
    public class ChangePasswordAdminModel : PageModel
    {
        private readonly IStaffService staffService;
        private readonly IAccountService accountService;
		public StaffDTO staff { get; set; }
        public string currentPassword { get; set; }
		[BindProperty(SupportsGet = true)]
		public string newPassword { get; set; }
		public ChangePasswordAdminModel(IStaffService staffService, IAccountService accountService)
        {
            this.staffService = staffService;
            this.accountService = accountService;
        }
        public IActionResult OnGet()
        {
			var staffId = HttpContext.Session.GetInt32("staffID");
			if (staffId != null)
			{
				staff = staffService.GetStaff((int)staffId);
				currentPassword = accountService.GetPasswordbyID((int)staff.StaAccID);
				return Page();
			}
			else
			{
				return RedirectToPage("/Login/LoginRegister");
			}
		}
		public IActionResult OnPostUpdate()
		{
			var staffId = HttpContext.Session.GetInt32("staffID");
			if (staffId != null)
			{
				staff = staffService.GetStaff((int)staffId);
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                accountService.ChangePassword((int)staff.StaAccID, hashedPassword);
				return RedirectToPage("/Admin/ManageAccount/ManageAccount");
			}
			else
			{
				return RedirectToPage("/Login/LoginRegister");
			}			
		}
    }
}
