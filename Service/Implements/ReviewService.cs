using CheeseBurger.DTO;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class ReviewService : IReviewService
	{
		private readonly IReviewRepository reviewRepository;
		public ReviewService (IReviewRepository reviewRepository)
		{
			this.reviewRepository = reviewRepository;
		}
		public List<ReviewDTO> GetReviewbyFood(int foodId)
		{
			return reviewRepository.GetReviewbyFood(foodId);
		}
	}
}
