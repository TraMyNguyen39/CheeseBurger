using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class MyOrderModel : PageModel
    {
        private readonly ILogger<MyOrderModel> _logger;

        public MyOrderModel(ILogger<MyOrderModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

    }
}