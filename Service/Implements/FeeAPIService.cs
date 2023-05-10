using CheeseBurger.Helpers;
using CheeseBurger.Repository;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CheeseBurger.Service.Implements
{
    public class FeeAPIService : IFeeAPIService
    {
        private readonly HttpClient _httpClient;

        public FeeAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://online-gateway.ghn.vn/shiip/public-api/v2/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("Token", "312f0089-ed7a-11ed-8a8c-6e4795e6d902");
        }

        public async Task<FeeAPIResult> GetResult(int fromDistrictId, int serviceId, int toDistrictId, string toWardCode, int height, int length, int weight, int width, int insuranceValue)
        {
            var query = new Dictionary<string, string>
    {
        { "from_district_id", fromDistrictId.ToString() },
        { "service_id", serviceId.ToString() },
        { "to_district_id", toDistrictId.ToString() },
        { "to_ward_code", toWardCode },
        { "height", height.ToString() },
        { "length", length.ToString() },
        { "weight", weight.ToString() },
        { "width", width.ToString() },
        { "insurance_value", insuranceValue.ToString() }
    };

            var queryString = string.Join("&", query.Select(x => $"{x.Key}={x.Value}"));

            // Use the registered HttpClient instance
            HttpResponseMessage response = await _httpClient.GetAsync($"shipping-order/fee?{queryString}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
    var feeResult = FeeAPIResult.FromJson(jsonResult);
    return feeResult;
            }

            // Handle the error response
            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error calling API: {response.StatusCode}, {errorResponse}");
        }
    }
}
