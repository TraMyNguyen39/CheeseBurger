using CheeseBurger.DTO;

namespace CheeseBurger.Service
{
    public interface IReviewService
    {
		List<ReviewDTO> GetReviewbyFood(int foodId);
	}
}
