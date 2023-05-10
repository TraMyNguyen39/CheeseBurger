using Newtonsoft.Json.Linq;

namespace CheeseBurger.Helpers
{
	public class FeeAPIResult
	{
		public int code { get; set; }
		public string message { get; set; }
		public List<FeeAPI> data { get; set; }
        public static FeeAPIResult FromJson(string json)
        {
            var obj = JObject.Parse(json);
            var result = new FeeAPIResult
            {
                code = (int)obj["code"],
                message = (string)obj["message"],
            };

            var data = obj["data"];
            if (data.Type == JTokenType.Array)
            {
                result.data = data.ToObject<List<FeeAPI>>();
            }
            else if (data.Type == JTokenType.Object)
            {
                var feeApi = data.ToObject<FeeAPI>();
                result.data = new List<FeeAPI> { feeApi };
            }
            else
            {
                throw new InvalidOperationException($"Invalid data type: {data.Type}");
            }

            return result;
        }
    }
}
