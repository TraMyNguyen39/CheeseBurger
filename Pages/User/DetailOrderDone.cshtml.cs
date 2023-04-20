using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class DetailOrderDoneModel : PageModel
    {
        private readonly ILogger<DetailOrderDoneModel> _logger;

        public DetailOrderDoneModel(ILogger<DetailOrderDoneModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

    }
}