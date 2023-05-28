using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class SuccesfulValidateModel : PageModel
    {
        private readonly IAccountService accountService;
        private readonly INewPassService newPassService;
        public int _idValidate;
        public int _idNPass;
        public SuccesfulValidateModel(IAccountService accountService, INewPassService newPassService)
        {
            this.accountService = accountService;
            this.newPassService = newPassService;
        }
        public void OnGet()
        {            
            _idValidate = HttpContext.Session.GetInt32("IdAccCP") ?? -1;
            _idNPass = HttpContext.Session.GetInt32("IdNP") ?? -1;
            string _newPass = newPassService.GetNamePassByID(_idNPass);           
            accountService.ChangePassword(_idValidate, _newPass);
        }
        public IActionResult OnPost(int idnp, int ida)
        {
            //var redirectUrl = "/Login/LoginRegister?d=" + ida.ToString() + "&idn=" + idnp.ToString();
            var redirectUrl = "/Login/LoginRegister";
            return RedirectToPage(redirectUrl);
        }
    }
}