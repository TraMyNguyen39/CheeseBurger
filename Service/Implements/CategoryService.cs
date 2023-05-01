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
			return categoryRepository.GetCategory();
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
			return categoryRepository.GetListCategories(arrange, isDescending);
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
    }
}
