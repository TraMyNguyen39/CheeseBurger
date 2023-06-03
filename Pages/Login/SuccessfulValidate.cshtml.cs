using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class SuccesfulValidateModel : PageModel
    {
        private readonly IAccountService accountService;        
        public SuccesfulValidateModel(IAccountService accountService)
        {
            this.accountService = accountService;            
        }
        public void OnGet()
        {            
            
        }        
    }
}