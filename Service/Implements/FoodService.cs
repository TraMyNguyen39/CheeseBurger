using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;
using System.Globalization;

namespace CheeseBurger.Service.Implements
{
	public class FoodService : IFoodService
	{
		private readonly IFoodRepository foodRepository;
		public FoodService (IFoodRepository foodRepository)
		{
			this.foodRepository = foodRepository;
		}

		public Food GetFoodbyId(int foodId)
		{
			return foodRepository.GetFoodbyId(foodId);
		}

		public List<FoodDTO> GetFoodsMenu(int category, int priceRange, string arrange, bool isDescending, string searchText)
		{
			return foodRepository.GetFoodsMenu(category, priceRange, arrange, isDescending, searchText);
		}
		public List<AdminFoodDTO> GetFoodAdmin()
		{
			return foodRepository.GetFoodAdmin();
		}
        public List<AdminFoodDTO> GetAllFoodAdmin()
		{
            return foodRepository.GetAllFoodAdmin();
        }

        public int getRowFood()
		{
			return foodRepository.getRowFood();
		}
        public List<String> GetNameCategories()
		{
			return foodRepository.GetNameCategories();
		}
        public List<AdminFoodDTO> GetListFoods(string categories, string arrange, bool isDescending, string searchText)
		{
			return foodRepository.GetListFoods(categories, arrange, isDescending, searchText);
		}
		public int ConvertCategoryNametoCategoryId(string Name)
		{
			return foodRepository.ConvertCategoryNametoCategoryId(Name);
		}
        public void AddData(string Name, int cateID, float Price, string Describe, string fileupload)
		{
			foodRepository.AddData(Name, cateID, Price, Describe, fileupload);
		}
        public void DeleteData(int id)
		{
			foodRepository.DeleteData(id);
		}
		public dynamic FindFood(int id)
		{
			return foodRepository.FindFood(id);
		}
        public void UpdateData(int FoodID, string Name, int CategoryID, float Price, string Describe, string fileupload)
		{
			foodRepository.UpdateData(FoodID, Name, CategoryID, Price, Describe, fileupload);
		}

        public void RecycleData(int id)
        {
            foodRepository.RecycleData(id);
        }

		public void UpdatePrice(int foodID)
		{
			foodRepository.UpdatePrice(foodID);
		}
	}
}
