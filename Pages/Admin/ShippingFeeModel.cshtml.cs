using Azure;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;

namespace CheeseBurger.Pages.Admin
{
    public class ShippingFeeModel : PageModel
    {
        private readonly IFeeAPIService feeService;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        public ShippingFeeModel(IFeeAPIService feeService, IConfiguration config)
        {
            this.feeService = feeService;
            _config = config;
        }

        [BindProperty(SupportsGet = true)]
        public float Total { get; set; }


        public void OnGet()
        {
            // initialize page state here
        }

        // other page handlers here

        public async Task<IActionResult> OnPostCalculateAsync()
        {
            int fromDistrictId;
            int serviceId;
            int toDistrictId;
            string toWardCode;
            int height;
            int length;
            int weight;
            int width;
            int insuranceValue;

            // Validate user input and parse values
            if (!int.TryParse(Request.Form["fromDistrictId"], out fromDistrictId))
            {
                ViewData["ErrorMessage"] = "Invalid fromDistrictId value";
                return Page();
            }

            if (!int.TryParse(Request.Form["serviceId"], out serviceId))
            {
                ViewData["ErrorMessage"] = "Invalid serviceId value";
                return Page();
            }

            if (!int.TryParse(Request.Form["toDistrictId"], out toDistrictId))
            {
                ViewData["ErrorMessage"] = "Invalid toDistrictId value";
                return Page();
            }

            toWardCode = Request.Form["toWardCode"];

            if (!int.TryParse(Request.Form["height"], out height))
            {
                ViewData["ErrorMessage"] = "Invalid height value";
                return Page();
            }

            if (!int.TryParse(Request.Form["length"], out length))
            {
                ViewData["ErrorMessage"] = "Invalid length value";
                return Page();
            }

            if (!int.TryParse(Request.Form["weight"], out weight))
            {
                ViewData["ErrorMessage"] = "Invalid weight value";
                return Page();
            }

            if (!int.TryParse(Request.Form["width"], out width))
            {
                ViewData["ErrorMessage"] = "Invalid width value";
                return Page();
            }

            if (!int.TryParse(Request.Form["insuranceValue"], out insuranceValue))
            {
                ViewData["ErrorMessage"] = "Invalid insuranceValue value";
                return Page();
            }

            try
            {
                var feeResults = await feeService.GetResult(fromDistrictId, serviceId, toDistrictId, toWardCode, height, length, weight, width, insuranceValue);
                foreach(var feeResult in feeResults.data)
                {
                    Total = feeResult.Total;
                }
                if (feeResults != null) // check if result is valid
                {
                    ViewData["SuccessMessage"] = "API call successful";
                }
                else
                {
                    ViewData["ErrorMessage"] = "Invalid API response";
                }

                return Page();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return Page();
            }
        }

    }
}
