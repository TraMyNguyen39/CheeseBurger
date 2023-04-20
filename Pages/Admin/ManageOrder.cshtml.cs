using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurgerWeb.Pages
{
    public class ManageOrderModel : PageModel
    {
        private readonly ILogger<ManageOrderModel> _logger;

        public ManageOrderModel(ILogger<ManageOrderModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
