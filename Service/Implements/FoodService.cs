using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;
using System.Globalization;

namespace CheeseBurger.Service.Implements
{
	public class FoodService : IFoodService
	{
		private readonly IFoodRepository foodRepository;
		private readonly IFood_IngredientsRepository foodIngreRepo;
		public FoodService (IFoodRepository foodRepository, IFood_IngredientsRepository foodIngreRepo)
		{
			this.foodRepository = foodRepository;
			this.foodIngreRepo = foodIngreRepo;
		}

		public Food GetFoodbyId(int foodId)
		{
			return foodRepository.GetFoodbyId(foodId);
		}

		public List<FoodDTO> GetFoodsMenu(int category, int priceRange, string arrange, bool isDescending, string searchText)
		{
			var foods = foodRepository.GetFoodsMenu(category, priceRange, arrange, isDescending, searchText);
			foreach (var food in foods)
			{
				if (GetMaxQuantityofFood(food.IDFood) <= 0)
					food.isStocking = false;
			}
			return foods;
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

		public int GetMaxQuantityofFood(int foodID)
		{
			var list = foodIngreRepo.GetListIngresogFood(foodID);
			// Tinh ra so luong toi da co the mua tu luong nguyen lieu
			if (list.Count > 0)
			{
				var firstObject = list[0];
				int min = Convert.ToInt32(firstObject[2]) / Convert.ToInt32(firstObject[1]);
				foreach (var ingre in list)
				{
					var x = Convert.ToInt32(ingre[2]) / Convert.ToInt32(ingre[1]);
					if (x < min) min = x;
				}
				return min;
			}
			return 0;
		}
	}
}
