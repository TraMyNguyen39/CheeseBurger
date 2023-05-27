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
    public class EnterIdenCodeFPModel : PageModel
    {        
        public string ICodeNameFP { get; set; } = String.Empty;
        public int MailIdFP { get; set; } = -1;               
        public void OnGet() {
            ICodeNameFP = HttpContext.Session.GetString("NameICodeFP");
            MailIdFP = HttpContext.Session.GetInt32("IdAccCP") ?? -1;         
        }
        public IActionResult OnPostUpdate(string typebtn)
        {
            if (typebtn == "1")
            {                
                return RedirectToPage("/Login/ChangeNewPass");
            }
            return RedirectToPage("/Index");
        }
    }
}