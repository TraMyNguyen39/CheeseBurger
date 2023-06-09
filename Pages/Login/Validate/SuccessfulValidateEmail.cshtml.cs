using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages.Login.Validate
{
    public class SuccesfulValidate1Model : PageModel
    {
        public string EmailValidate;
        public void OnGet()
        {
            EmailValidate = HttpContext.Request.Form["email"].ToString();
        }
    }
}