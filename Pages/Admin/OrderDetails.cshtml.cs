using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages.Admin
{
    public class OrderDetailsModel : PageModel
    {
        private readonly ILogger<OrderDetailsModel> _logger;

        public OrderDetailsModel(ILogger<OrderDetailsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
