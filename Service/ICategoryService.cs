using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface ICategoryService
    {
        List<Category> GetAllCategory();
		Category GetCategorybyId(int categoryId);
	}
}
