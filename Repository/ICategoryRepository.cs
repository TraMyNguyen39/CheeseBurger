using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface ICategoryRepository
    {
		List<Category> GetAllCategory();
		List<Category> GetCategory();
		List<int> GetQuantities();
		int getRowCategory();
		List<Category> GetListCategories(string arrange, bool isDescending);
		public void AddData(string Name);
		dynamic FindCategories(int id);
		void UpdateData(int id, string Name);
		void DeleteData(int id);
		List<Food> GetByCategoryID(int CateId);
		Category GetCategorybyId(int categoryId);
		int GetCategoryIdByName(string Name);
	}
}
