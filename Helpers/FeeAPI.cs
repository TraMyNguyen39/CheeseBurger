using Newtonsoft.Json;

namespace CheeseBurger.Helpers
{
    public class FeeAPI
    {
        [JsonProperty("total")]
        public float Total { get; set; }

        [JsonProperty("service_fee")]
        public int ServiceFee { get; set; }

        [JsonProperty("insurance_fee")]
        public int InsuranceFee { get; set; }

        [JsonProperty("pick_station_fee")]
        public int PickStationFee { get; set; }

        [JsonProperty("coupon_value")]
        public int CouponValue { get; set; }

        [JsonProperty("r2s_fee")]
        public int R2SFee { get; set; }
    }
}
