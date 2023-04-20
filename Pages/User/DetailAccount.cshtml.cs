using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class DetailAccountModel : PageModel
    {
        private readonly ILogger<DetailAccountModel> _logger;

        public DetailAccountModel(ILogger<DetailAccountModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

    }
}