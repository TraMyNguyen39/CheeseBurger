using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly CheeseBurgerContext context;
		public ReviewRepository (CheeseBurgerContext context)
		{
			this.context = context;
		}
		public List<ReviewDTO> GetReviewbyFood(int foodId)
		{
			return context.Reviews.Where(p => p.FoodID == foodId )
				.Join(context.Customers, p => p.CustomerID, c => c.CustomerID, (p, c) => 
				new ReviewDTO { reviewId = p.ReviewID, star = p.Star, dateReview = p.DateReview, content = p.Content, img = p.Img, customerName = c.CustomerName}).ToList();
		}
	}
}
