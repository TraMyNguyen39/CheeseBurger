using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IReviewRepository
    {
        List<ReviewDTO> GetReviewbyFood(int foodId);
    }
}
