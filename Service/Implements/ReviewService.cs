using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
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
		public void AddNewReview(int foodID, int star, string content, string img, DateTime date_review, int cusID, int orderID)
		{
			reviewRepository.AddNewReview(foodID, star, content, img, date_review, cusID, orderID);
		}
		public List<Review> GetReviewByOrderID(int orderID)
		{
			return reviewRepository.GetReviewByOrderID(orderID);
		}
	}
}
