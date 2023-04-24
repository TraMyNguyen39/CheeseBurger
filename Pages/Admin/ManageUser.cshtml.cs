using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class ManageUserModel : PageModel
    {
        private readonly CheeseBurgerContext _context;
        public List<Customer> Customers { get; set; }   
        public List<Account> Accounts { get; set; }
        public ManageUserModel(CheeseBurgerContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Customers = _context.Customers.ToList();
            Accounts = _context.Accounts.ToList();
        }

        public IActionResult OnGetFind(int id)
        {
            var customer = _context.Customers.Find(id);
            return new JsonResult(customer);
        }
    }
}
