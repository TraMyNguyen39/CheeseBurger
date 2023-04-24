using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class ManageStaffModel : PageModel
    {
		private readonly CheeseBurgerContext _context;
		public List<Staff> Staffs { get; set; }
		public List<Account> Accounts { get; set; }
		public List<Role> Roles { get; set; }
        public ManageStaffModel(CheeseBurgerContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Staffs = _context.Staffs.ToList();
            Accounts = _context.Accounts.ToList();
            Roles = _context.Roles.ToList();
        }
    }
}
