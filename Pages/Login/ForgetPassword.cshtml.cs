﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurgerWeb.Pages
{
    public class ForgetPasswordModel : PageModel
    {
        private readonly ILogger<ForgetPasswordModel> _logger;

        public ForgetPasswordModel(ILogger<ForgetPasswordModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}