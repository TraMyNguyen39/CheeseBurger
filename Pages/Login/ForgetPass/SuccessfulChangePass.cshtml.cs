using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages.Login.ForgetPass
{
    public class SuccessfulChangePassModel : PageModel
    {
        private readonly IAccountService accountService;
        public SuccessfulChangePassModel(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public void OnGet()
        {

        }
    }
}