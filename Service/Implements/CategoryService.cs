using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.Implements
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository categoryRepository;
		public CategoryService(ICategoryRepository categoryRepository)
		{
			this.categoryRepository = categoryRepository;
		}
		public List<Category> GetAllCategory()
		{
			return categoryRepository.GetAllCategory();
		}

		public Category GetCategorybyId(int categoryId)
		{
			return categoryRepository.GetCategorybyId(categoryId);
		}
	}
}
