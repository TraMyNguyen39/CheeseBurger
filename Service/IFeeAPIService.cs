using CheeseBurger.Helpers;

namespace CheeseBurger.Service
{
    public interface IFeeAPIService
    {
        Task<FeeAPIResult> GetResult(int fromDistrictId, int serviceId, int toDistrictId, string toWardCode, int height, int length, int weight, int width, int insuranceValue);
    }
}
