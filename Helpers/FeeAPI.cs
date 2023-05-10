using Newtonsoft.Json;

namespace CheeseBurger.Helpers
{
    public class FeeAPI
    {
        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("service_fee")]
        public decimal ServiceFee { get; set; }

        [JsonProperty("insurance_fee")]
        public decimal InsuranceFee { get; set; }

        [JsonProperty("pick_station_fee")]
        public decimal PickStationFee { get; set; }

        [JsonProperty("coupon_value")]
        public decimal CouponValue { get; set; }

        [JsonProperty("r2s_fee")]
        public decimal R2SFee { get; set; }
    }
}
