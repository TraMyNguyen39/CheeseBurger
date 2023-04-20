using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace CheeseBurger.Pages
{
    public class LoginRegisterModel : PageModel
    {
        private readonly IAccountService accountService;
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string Message { get; set; }

        public LoginRegisterModel(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult OnPost()
        {
            var user = accountService.GetAccount(Email, Password);
            if (user == null)
            {
                Message = "* Tài khoản / Mật khẩu không đúng!";
                return Page();
            }
            else
            {
                HttpContext.Session.SetInt32("Id", user.AccountID);
                HttpContext.Session.SetString("isStaff", user.isStaff ? "Staff" : "Customer");
                HttpContext.Session.SetString("Name", accountService.GetNamebyID(user.AccountID, user.isStaff));
                if (user.isStaff)
                {
                    HttpContext.Session.SetString("Role", accountService.GetStaffRole(user.AccountID));
                    return RedirectToPage("/User/Menu");
                }
                else
                {
                    return RedirectToPage("/User/Cart");
                }
            }
        }
    }
}