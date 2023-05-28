using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;
using CheeseBurger.Service;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service.Implements;
using Org.BouncyCastle.Crypto;

namespace CheeseBurger.Pages
{
    public class EnterIdenCodeModel : PageModel
    {
        private readonly IAccountService accountService;
        private readonly ICustomerService customerService;
        public string ICodeName { get; set; } = String.Empty;
        public string NewAccMail { get; set; } = String.Empty;
        public string NewCusName { get; set; } = String.Empty;
        public string NewAccPassw { get; set; } = String.Empty;
        public string NewCusPhone { get; set; } = String.Empty;
        public EnterIdenCodeModel(IAccountService accountService, ICustomerService customerService)
        {
            this.accountService = accountService;
            this.customerService = customerService;
        }
        public void OnGet() {
            ICodeName = HttpContext.Session.GetString("NewAccICode");
            NewAccMail = HttpContext.Session.GetString("NewAccEmail");
            NewCusName = HttpContext.Session.GetString("NewAccName");
            NewCusPhone = HttpContext.Session.GetString("NewAccPhone");
            NewAccPassw = HttpContext.Session.GetString("NewAccPass");
        }
        public IActionResult OnPostUpdate(string typebtn, string icname, string newmail, string newname, string newpassw, string newphone)
        {
            if (typebtn == "1")
            {
                accountService.AddNewAccount(newmail, newpassw);
                customerService.AddNewCus(newname, newphone);
                return RedirectToPage("/Login/SuccessfulRegister");
            }
            return RedirectToPage("/Index");
        }
    }
}