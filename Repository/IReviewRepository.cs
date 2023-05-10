using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IReviewRepository
    {
        List<ReviewDTO> GetReviewbyFood(int foodId);
        void AddNewReview(int foodID, int star, string content, string img, DateTime date_review, int cusID, int orderID);
        List<Review> GetReviewByOrderID(int orderID);
    }
}
