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
		public void AddNewReview(int foodID, int star, string content, string img, DateTime date_review, int cusID, int orderID)
		{
			var new_review = new Review
			{
				Star = star,
				Content = content,
				Img = img,
				DateReview = date_review,
				CustomerID = cusID,
				FoodID = foodID,
				OrderID = orderID
			};
			context.Reviews.Add(new_review);
			context.SaveChanges();
		}
		public List<Review> GetReviewByOrderID(int orderID)
		{
			return context.Reviews.Where(p => p.OrderID == orderID).Select(p => p).ToList();
		}
	}
}
