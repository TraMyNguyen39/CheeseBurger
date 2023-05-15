using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class SuccesfulValideModel : PageModel
    {
        private readonly IAccountService accountService;
        public SuccesfulValideModel(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public void OnGet()
        {
            string _newPass = "123456A@a";
            accountService.ChangePassword(2, _newPass);
        }
    }
}