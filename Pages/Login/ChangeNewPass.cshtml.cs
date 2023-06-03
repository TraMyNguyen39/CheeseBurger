using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;
using CheeseBurger.Service;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service.Implements;

namespace CheeseBurger.Pages
{
    public class ChangeNewPassModel : PageModel
    {
        private readonly IAccountService accountService;        
        public int _idMailChangePass { get; set; }

        public ChangeNewPassModel(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public void OnGet() {
           _idMailChangePass = HttpContext.Session.GetInt32("IdAccCP") ?? -1; 
        }
        public IActionResult OnPostUpdate(int idAcc, string newpass, string confirmpass)
        {
			string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newpass);
			accountService.ChangePassword(idAcc, hashedPassword);
            return RedirectToPage("SuccessfulChangePass");
        }
    }
}