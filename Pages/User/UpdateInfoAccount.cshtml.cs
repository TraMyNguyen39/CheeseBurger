using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class UpdateInfoAccountModel : PageModel
    {
        private readonly ILogger<UpdateInfoAccountModel> _logger;

        public UpdateInfoAccountModel(ILogger<UpdateInfoAccountModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

    }
}