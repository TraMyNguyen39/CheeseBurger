﻿using CheeseBurger.DTO;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;

namespace CheeseBurger.Pages
{
    public class LoginRegisterModel : PageModel
    {
        private readonly IAccountService accountService;
        private readonly ICustomerService customerService;
        private readonly IStaffService staffService;        
        public List<CustomerDTO> List_Customers { get; set; }
        public List<StaffDTO> List_Staffs { get; set; }
        
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public int IdNewPass { get; set; }
        [BindProperty]
        public int IdAcc { get; set; }
        [BindProperty(SupportsGet = true)]
		public string Message { get; set; }        
        public LoginRegisterModel(IAccountService accountService, ICustomerService customerService, IStaffService staffService)
        {
            this.accountService = accountService;
            this.customerService = customerService;
            this.staffService = staffService;           
        }

        public void OnGet()
        {
            List_Customers = customerService.GetAllCustomers();
            List_Staffs = staffService.GetAllStaffs();            
		}
        public IActionResult OnPost()
        {
            var user = accountService.GetAccount(Email, Password);
            if (user == null)
            {
                Message = "* Tài khoản/ Mật khẩu không đúng!";
                List_Customers = customerService.GetAllCustomers();
                List_Staffs = staffService.GetAllStaffs();				
				return Page();
            }
            else if (user.isDeleted == true)
            {
                Message = "* Tài khoản đã bị chặn vì vi phạm tiêu chuẩn cộng đồng!";
                List_Customers = customerService.GetAllCustomers();
                List_Staffs = staffService.GetAllStaffs();				
				return Page();
			}               
            else
            {
                HttpContext.Session.SetString("EmailUser", Email);
                HttpContext.Session.SetInt32("Id", user.AccountID);
                HttpContext.Session.SetString("isStaff", user.isStaff ? "Staff" : "Customer");
                HttpContext.Session.SetString("Name", accountService.GetNamebyID(user.AccountID, user.isStaff));
                if (user.isStaff)
                {
                    var staffID = staffService.GetStaffID(user.AccountID);
                    HttpContext.Session.SetInt32("staffID", staffID);
                    var staffRole = staffService.GetStaffRole(staffID);
                    HttpContext.Session.SetString("Role", staffRole);
                    if (staffRole != "Quản trị viên")
                    {
                        return RedirectToPage("/Admin/ManageExport/ManageExportOrder");
                    }
                    return RedirectToPage("/Admin/SyncRevenue");
                }
                else
                {
                    var customerID = customerService.GetCustomerID(user.AccountID);
                    HttpContext.Session.SetInt32("customerID", customerID);
                    return RedirectToPage("/User/Food/Menu");
                }
            }
        }
        public void OnGetLogout ()
        {
            HttpContext.Session.Clear();
            List_Customers = customerService.GetAllCustomers();
            List_Staffs = staffService.GetAllStaffs();			
		}        
    }
}