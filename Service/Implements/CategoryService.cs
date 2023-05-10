using CheeseBurger.DTO;
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

		public List<CategoryDTO> GetCategory()
		{
			var quantities = categoryRepository.GetQuantities();
			var category = categoryRepository.GetCategory();
			return category.Select((p, i) => new CategoryDTO
			{
				CategoryID = p.CategoryID,
				Quantity = quantities.ElementAtOrDefault(i),
				CategoryName = p.CategoryName
			}).ToList();
		}
		public List<int> GetQuantities()
		{
			return categoryRepository.GetQuantities();
		}
		public int getRowCategory()
		{
			return categoryRepository.getRowCategory();
		}
		public List<CategoryDTO> GetListCategories(string arrange, bool isDescending)
		{
			var quantities = categoryRepository.GetQuantities();
			return categoryRepository.GetListCategories(arrange, isDescending)
				.Select((p, i) => new CategoryDTO
			{
				CategoryID = p.CategoryID,
				Quantity = quantities.ElementAtOrDefault(i),
				CategoryName = p.CategoryName
			}).ToList();
		}
		public void AddData(string Name)
		{
			categoryRepository.AddData(Name);
		}
		public dynamic FindCategories(int id)
		{
			return categoryRepository.FindCategories(id);
		}
		public void UpdateData(int id, string Name)
		{
			categoryRepository.UpdateData(id, Name);
		}
		public void DeleteData(int id)
		{
			categoryRepository.DeleteData(id);
		}
		public List<Food> GetByCategoryID(int CateId)
		{
			return categoryRepository.GetByCategoryID(CateId);
		}

		public Category GetCategorybyId(int categoryId)
		{
			return categoryRepository.GetCategorybyId(categoryId);
		}

		public int GetCategoryIdByName(string Name)
		{
			return categoryRepository.GetCategoryIdByName(Name);
		}
	}
}
