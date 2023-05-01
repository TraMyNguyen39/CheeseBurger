using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CheeseBurger.Repository.Implements
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly CheeseBurgerContext context;
		public CategoryRepository(CheeseBurgerContext context)
		{
			this.context = context;
		}
		public List<CategoryDTO> GetCategory() {
			var categories = context.Categories.ToList();
			var quantities = GetQuantities();
			return categories.Select((p, i) => new CategoryDTO
			{
				CategoryID = p.CategoryID,
				Quantity = quantities.ElementAtOrDefault(i),
				CategoryName = p.CategoryName
			}).ToList();
		}
		
		public List<int> GetQuantities()
		{
			var result = from p in context.Categories
						 join m in context.Foods on p.CategoryID equals m.CategoryID
						 group m by p.CategoryID into g
						 select g.Count();
			return result.ToList();
		}

		public List<Category> GetAllCategory()
		{
			return context.Categories.Select(p => p).ToList();
		}

		public Category GetCategorybyId(int categoryId)
		{
			return context.Categories.Find(categoryId);
		}
		public int getRowCategory()
		{
			return context.Categories.Count();
		}

		public List<CategoryDTO> GetListCategories(string arrange, bool isDescending)
		{
			var categories = GetCategory();
			switch (arrange)
			{
				case "name":
					categories = isDescending ? categories.OrderByDescending(p => p.CategoryName).ToList() : categories.OrderBy(p => p.CategoryName).ToList();
					break;
			}
			return categories;
		}

		public void AddData(string Name)
		{
			var CategoryName = context.Categories.Any(m => m.CategoryName == Name);
			if (!CategoryName)
			{
				var category = new Category
				{
					CategoryName = Name
				};
				context.Categories.Add(category);
				context.SaveChanges();
			}
			else
			{
				throw new ArgumentException($"Category with name {CategoryName} already exist in the Categories table.");
			}
		}
        public dynamic FindCategories(int id)
        {
            return context.Categories.Find(id);
        }
        public void UpdateData(int id, string Name)
        {
			var category = context.Categories.Find(id);
            category.CategoryName = Name;
            context.SaveChanges();
        }
        public void DeleteData(int id)
        {
            var categories = context.Categories.Find(id);
            if (categories != null)
            {
                context.Categories.Remove(categories);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Category not found with {id}:");
            }
        }
        public List<Food> GetByCategoryID(int CateId)
        {
            // Query the database to get the foods by categoryID
            var foods = context.Foods.Where(f => f.CategoryID == CateId).ToList();

            // Log the number of foods returned
            Console.WriteLine($"Found {foods.Count} foods with category ID {CateId}");

            return foods;
        }
    }
}
