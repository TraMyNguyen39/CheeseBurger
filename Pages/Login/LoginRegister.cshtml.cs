using CheeseBurger.DTO;
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
        private readonly INewPassService newPassService;
        private readonly ITPassService tPassService;
        public List<CustomerDTO> List_Customers { get; set; }
        public List<StaffDTO> List_Staffs { get; set; }
        //public int _IdNewPass { get; set; } = -1;
        //public int _IdAcc { get; set; } = -1;
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

        public LoginRegisterModel(IAccountService accountService, ICustomerService customerService, IStaffService staffService,
                                    INewPassService newPassService, ITPassService tPassService)
        {
            this.accountService = accountService;
            this.customerService = customerService;
            this.staffService = staffService;
            this.newPassService = newPassService;
            this.tPassService = tPassService;
        }

        public void OnGet()
        {
            List_Customers = customerService.GetAllCustomers();
            List_Staffs = staffService.GetAllStaffs();
            //string idnValue = Request.Query["idn"];
            //_IdNewPass = string.IsNullOrEmpty(idnValue) ? -1 : Convert.ToInt32(idnValue);
            //string idaValue = Request.Query["d"];
            //_IdAcc = string.IsNullOrEmpty(idaValue) ? -1 : Convert.ToInt32(idaValue);
            //_IdAcc = HttpContext.Session.GetInt32("IdAccCP") ?? -1;
            //_IdNewPass = HttpContext.Session.GetInt32("IdNP") ?? -1;
        }

        public IActionResult OnPost()
        {
            var user = accountService.GetAccount(Email, Password);
            if (user == null)
            {
                Message = "* Tài khoản/ Mật khẩu không đúng!";
                List_Customers = customerService.GetAllCustomers();
                List_Staffs = staffService.GetAllStaffs();
                //string idnValue = Request.Query["idn"];
                //_IdNewPass = string.IsNullOrEmpty(idnValue) ? -1 : Convert.ToInt32(idnValue);
                //string idaValue = Request.Query["d"];
                //_IdAcc = string.IsNullOrEmpty(idaValue) ? -1 : Convert.ToInt32(idaValue);
                //_IdAcc = HttpContext.Session.GetInt32("IdAccCP") ?? -1;
                //_IdNewPass = HttpContext.Session.GetInt32("IdNP") ?? -1;
                return Page();
            }
            else if(user.isDeleted == true)
			{
				Message = "* Tài khoản đã bị chặn vì vi phạm tiêu chuẩn cộng đồng!";
                List_Customers = customerService.GetAllCustomers();
                List_Staffs = staffService.GetAllStaffs();
                //string idnValue = Request.Query["idn"];
                //_IdNewPass = string.IsNullOrEmpty(idnValue) ? -1 : Convert.ToInt32(idnValue);
                //string idaValue = Request.Query["d"];
                //_IdAcc = string.IsNullOrEmpty(idaValue) ? -1 : Convert.ToInt32(idaValue);
                //_IdAcc = HttpContext.Session.GetInt32("IdAccCP") ?? -1;
                //_IdNewPass = HttpContext.Session.GetInt32("IdNP") ?? -1;
                return Page();
			}   
            //else if (IdNewPass != -1)
            //{
            //    int idalg = accountService.GetIDAccountByMail(Email);
            //    if (idalg == IdAcc)
            //    {
            //        string sendTimeStr = HttpContext.Session.GetString("SendTime");
            //        DateTime sendTime;
            //        if (DateTime.TryParse(sendTimeStr, out sendTime))
            //        {
            //            DateTime currentTime = DateTime.Now;
            //            TimeSpan timeDifference = currentTime - sendTime;

            //            if (timeDifference.TotalMinutes > 1)
            //            {
            //                Message = "* Mật khẩu này đã quá hạn cho phép !";
            //                List_Customers = customerService.GetAllCustomers();
            //                List_Staffs = staffService.GetAllStaffs();
            //                //string idnValue = Request.Query["idn"];
            //                //_IdNewPass = string.IsNullOrEmpty(idnValue) ? -1 : Convert.ToInt32(idnValue);
            //                //string idaValue = Request.Query["d"];
            //                //_IdAcc = string.IsNullOrEmpty(idaValue) ? -1 : Convert.ToInt32(idaValue);
            //                _IdAcc = HttpContext.Session.GetInt32("IdAccCP") ?? -1;
            //                _IdNewPass = HttpContext.Session.GetInt32("IdNP") ?? -1;

            //                int seed = DateTime.Now.Millisecond;
            //                Random rnd = new Random(seed);                            
            //                var listTP = tPassService.GetListTPass();
            //                var idx = rnd.Next(0, listTP.Count);
            //                var tp_name = listTP[idx].TPassName;
            //                accountService.ChangePassword(idalg, tp_name);
            //                return Page();
            //            }
            //            else
            //            {
            //                var redirectUrl = "/Login/ChangeNewPass";
            //                return RedirectToPage(redirectUrl);
            //            }
            //        }
            //    }
            //    HttpContext.Session.SetInt32("Id", user.AccountID);
            //    HttpContext.Session.SetString("isStaff", user.isStaff ? "Staff" : "Customer");
            //    HttpContext.Session.SetString("Name", accountService.GetNamebyID(user.AccountID, user.isStaff));
            //    if (user.isStaff)
            //    {
            //        var staffID = staffService.GetStaffID(staffService.GetStaffID(user.AccountID));
            //        HttpContext.Session.SetInt32("staffID", staffID);
            //        var staffRole = staffService.GetStaffRole(staffID);
            //        HttpContext.Session.SetString("Role", staffRole);
            //        if (staffRole != "Quản trị viên")
            //        {
            //            return RedirectToPage("/Admin/ManageExportOrder");
            //        }
            //        return RedirectToPage("/Admin/SyncRevenue");
            //    }
            //    else
            //    {
            //        var customerID = customerService.GetCustomerID(user.AccountID);
            //        HttpContext.Session.SetInt32("customerID", customerID);
            //        return RedirectToPage("/User/Menu");
            //    }
            //}
            else
            {
				HttpContext.Session.SetInt32("Id", user.AccountID);
                HttpContext.Session.SetString("isStaff", user.isStaff ? "Staff" : "Customer");
                HttpContext.Session.SetString("Name", accountService.GetNamebyID(user.AccountID, user.isStaff));
                if (user.isStaff)
                {
                    var staffID = staffService.GetStaffID(staffService.GetStaffID(user.AccountID));
					HttpContext.Session.SetInt32("staffID", staffID);
                    var staffRole = staffService.GetStaffRole(staffID);                    
                    HttpContext.Session.SetString("Role", staffRole);
                    if (staffRole != "Quản trị viên")
                    {
                        return RedirectToPage("/Admin/ManageExportOrder");
                    }
                    return RedirectToPage("/Admin/SyncRevenue");
                }
                else
                {
                    var customerID = customerService.GetCustomerID(user.AccountID);
                    HttpContext.Session.SetInt32("customerID", customerID);
                    return RedirectToPage("/User/Menu");
                }
            }
        }
        public void OnGetLogout ()
        {
            HttpContext.Session.Clear();
            List_Customers = customerService.GetAllCustomers();
            List_Staffs = staffService.GetAllStaffs();
            //string idnValue = Request.Query["idn"];
            //_IdNewPass = string.IsNullOrEmpty(idnValue) ? -1 : Convert.ToInt32(idnValue);
            //string idaValue = Request.Query["d"];
            //_IdAcc = string.IsNullOrEmpty(idaValue) ? -1 : Convert.ToInt32(idaValue);
            //_IdAcc = HttpContext.Session.GetInt32("IdAccCP") ?? -1;
            //_IdNewPass = HttpContext.Session.GetInt32("IdNP") ?? -1;
        }
        //public IActionResult OnPostRegister(string name, string email, string phone, string pass) 
        //{
        //    accountService.AddNewAccount(email, pass);
        //    customerService.AddNewCus(name, phone);
        //    return RedirectToPage("/Login/LoginRegister");
        //}
    }
}