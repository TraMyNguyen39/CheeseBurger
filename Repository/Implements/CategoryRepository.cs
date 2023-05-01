using CheeseBurger.Model;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository.Implements
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly CheeseBurgerContext context;
		public CategoryRepository(CheeseBurgerContext context)
		{
			this.context = context;
		}
		public List<Category> GetAllCategory()
		{
			return context.Categories.Select(p => p).ToList();
		}

		public Category GetCategorybyId(int categoryId)
		{
			return context.Categories.Find(categoryId);
		}
	}
}
