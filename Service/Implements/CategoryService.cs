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
		public List<Category> GetAllCategoryName()
		{
			return categoryRepository.GetAllCategoryName();
		}
	}
}
