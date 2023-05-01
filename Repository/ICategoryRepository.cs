using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface ICategoryRepository
    {
		List<Category> GetAllCategory();
		Category GetCategorybyId(int categoryId);
	}
}
