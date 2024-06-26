﻿using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;

namespace CheeseBurger.Repository.Implements
{
	public class FoodRepository : IFoodRepository
	{
		private readonly CheeseBurgerContext context;
		public FoodRepository(CheeseBurgerContext context)
		{
			this.context = context;
		}

		public Food GetFoodbyId(int foodId)
		{
			return context.Foods.Find(foodId);
		}

		public List<FoodDTO> GetFoodsMenu(int category, int priceRange, string arrange, bool isDescending, string searchText)
		{
			var foods = context.Foods.Where(p => p.IsDeleted == false).Select(p => p);
			if (category != 0)
				foods = foods.Where(p => p.CategoryID == category).Select(p => p);

			switch (priceRange)
			{
				case 1:
					foods = foods.Where(p => p.Price >= 0 && p.Price <= 20000).Select(p => p);
					break;
				case 2:
					foods = foods.Where(p => p.Price >= 20000 && p.Price <= 50000).Select(p => p);
					break;
				case 3:
					foods = foods.Where(p => p.Price >= 50000 && p.Price <= 70000).Select(p => p);
					break;
				case 4:
					foods = foods.Where(p => p.Price >= 70000 && p.Price <= 100000).Select(p => p);
					break;
			}

			switch (arrange)
			{
				case "name":
					foods = isDescending ? foods.OrderByDescending(p => p.FoodName) : foods.OrderBy(p => p.FoodName);
					break;
				case "price":
					foods = isDescending ? foods.OrderByDescending(p => p.Price) : foods.OrderBy(p => p.Price);
					break;
			}

			if (!searchText.IsNullOrEmpty())
			{
				foods = foods.Where(p => p.FoodName.Contains(searchText)).Select(p => p);
			}
			/// Nhom sao trung binh theo mon an
			var groupby = context.Reviews.GroupBy(p => p.FoodID)
										 .Select(g => new
										 {
											 IDFood = g.Key,
											 Star = g.Average(p => p.Star)
										 });
			// Nhom cac bang lai roi lay ra FoodDTO
			return foods.GroupJoin(groupby, p => p.FoodID, q => q.IDFood, (p, q) => new { food = p, review = q })
						.SelectMany(foodrating => foodrating.review.DefaultIfEmpty(),
									(p, q) => new FoodDTO
									{
										IDFood = p.food.FoodID,
										NameFood = p.food.FoodName,
										ImgFood = p.food.ImageFood,
										PriceFood = p.food.Price,
										TotalRating = q.Star.ToString(),
										isStocking = true
									}).ToList();
		}
		public List<AdminFoodDTO> GetFoodAdmin()
		{
			return context.Foods.Where(p => p.IsDeleted == false)
				.Select(p => new AdminFoodDTO { FoodID = p.FoodID, FoodName = p.FoodName, FoodInputPrice = p.Price, CategoryName = p.Category.CategoryName }).ToList();
		}

        public List<AdminFoodDTO> GetAllFoodAdmin()
        {
            return context.Foods.Select(p => new AdminFoodDTO { FoodID = p.FoodID, FoodName = p.FoodName, FoodInputPrice = p.Price, CategoryName = p.Category.CategoryName }).ToList();
        }

        public int getRowFood()
		{
			return context.Foods.Count();
		}
		public List<String> GetNameCategories()
		{
			return context.Categories.Select(p => p.CategoryName).Distinct().ToList();
		}
		public List<AdminFoodDTO> GetListFoods(string categories, string arrange, bool isDescending, string searchText)
		{
			var sta_data = from c in context.Foods
						   join a in context.Categories on c.CategoryID equals a.CategoryID
						   select new AdminFoodDTO
						   {
							   FoodID = c.FoodID,
							   FoodName = c.FoodName,
							   FoodInputPrice = c.Price,
							   CategoryName = a.CategoryName,
							   isDeleted = c.IsDeleted
						   };

			if (!string.IsNullOrEmpty(categories) && categories != "All")
			{
				sta_data = sta_data.Where(p => p.CategoryName.Equals(categories)).Select(p => p);
			}

			if (!searchText.IsNullOrEmpty())
			{
				sta_data = sta_data.Where(p => p.FoodName.Contains(searchText)).Select(p => p);
			}
			switch (arrange)
			{
				case "name":
					sta_data = isDescending ? sta_data.OrderByDescending(p => p.FoodName) : sta_data.OrderBy(p => p.FoodName);
					break;
				case "price":
					sta_data = isDescending ? sta_data.OrderByDescending(p => p.FoodInputPrice) : sta_data.OrderBy(p => p.FoodInputPrice);
					break;
			}
			if (!searchText.IsNullOrEmpty())
				return sta_data.ToList();
			else
				return sta_data.ToList().Where(p => p.isDeleted == false).ToList();
		}
        public int ConvertCategoryNametoCategoryId(string Name)
        {
            var category = context.Categories
                          .FirstOrDefault(p => p.CategoryName.Equals(Name));
            return category != null ? category.CategoryID : 0;
        }
        public void AddData(string Name, int cateID, float Price, string Describe, string fileupload)
        {
            var FoodName = context.Foods.Any(m => m.FoodName == Name);
            if (!FoodName)
            {
                var food = new Food
                {
                    FoodName = Name,
                    Price = Price,
                    Description = Describe,
                    ImageFood = fileupload,
                    CategoryID = cateID,
					originPrice = 0,
					Quantity = 0,
					IsDeleted = false,
                };
                context.Foods.Add(food);
                context.SaveChanges();
            }
        }
        public void DeleteData(int id)
        {
            var food = context.Foods.Find(id);
            if (food != null)
            {
				food.IsDeleted = true;
                context.SaveChanges();
            }
        }
        public dynamic FindFood(int id)
        {
            return context.Foods.Find(id);
        }
        public void UpdateData(int FoodID, string Name, int CategoryID, float Price, string Describe, string fileupload)
        {
            var food = context.Foods.Find(FoodID);
            food.FoodName = Name;
            food.CategoryID = CategoryID;
			food.Price = Price;
            food.Description = Describe;
			food.ImageFood = fileupload;
            context.SaveChanges();
        }

        public void RecycleData(int id)
        {
            var food = context.Foods.Find(id);
			if (food != null)
			{
				food.IsDeleted = false;
				context.SaveChanges();
			}
		}

		public void UpdatePrice(int foodID)
		{
			var food = context.Foods.Find(foodID);
			var recipes = context.Food_Ingredients.Where(p => p.FoodID == foodID)
				.Select(p => new {p.QuantityIG, p.Ingredients.IngredientsPrice})
				.ToList();
			food.originPrice = 0;
			foreach (var recipe in recipes)
			{
				food.originPrice += recipe.QuantityIG * recipe.IngredientsPrice;
			}
			context.SaveChanges();
		}
	}
}
