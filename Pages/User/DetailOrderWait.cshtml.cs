using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class DetailOrderWaitModel : PageModel
    {
        private readonly ILogger<DetailOrderWaitModel> _logger;

        public DetailOrderWaitModel(ILogger<DetailOrderWaitModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

    }
}