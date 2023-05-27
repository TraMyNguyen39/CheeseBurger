using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;
using CheeseBurger.Service;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Pages
{
    public class ForgetPasswordModel : PageModel
    {
        private readonly IAccountService accountService;
        public List<Account> List_Account { get; set; }
        public ForgetPasswordModel(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public void OnGet() {
            List_Account = accountService.GetListAccount();
        }
    }
}