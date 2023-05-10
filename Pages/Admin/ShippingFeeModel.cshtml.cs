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
        public int Total { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ServiceFee { get; set; }

        [BindProperty(SupportsGet = true)]
        public int InsuranceFee { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PickStationFee { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CouponValue { get; set; }

        [BindProperty(SupportsGet = true)]
        public int R2SFee { get; set; }


        public void OnGet()
        {
            // initialize page state here
        }

        // other page handlers here

        public async Task<IActionResult> OnPostCalculateAsync()
        {
            int fromDistrictId = int.Parse(Request.Form["fromDistrictId"]);
            int serviceId = int.Parse(Request.Form["serviceId"]);
            int toDistrictId = int.Parse(Request.Form["toDistrictId"]);
            string toWardCode = Request.Form["toWardCode"];
            int height = int.Parse(Request.Form["height"]);
            int length = int.Parse(Request.Form["length"]);
            int weight = int.Parse(Request.Form["weight"]);
            int width = int.Parse(Request.Form["width"]);
            int insuranceValue = int.Parse(Request.Form["insuranceValue"]);

            var feeResult = await feeService.GetResult(fromDistrictId, serviceId, toDistrictId, toWardCode, height, length, weight, width, insuranceValue);

            if (feeResult == null)
            {
                return BadRequest("Error getting fee result.");
            }

            return Page();
        }

    }
}
