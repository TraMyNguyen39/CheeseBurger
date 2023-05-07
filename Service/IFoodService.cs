﻿using CheeseBurger.DTO;

namespace CheeseBurger.Service
{
    public interface IFoodService
    {
        List<FoodDTO> GetFoodsMenu(int category, int priceRange , string arrange, bool isDescending, string searchText);
		List<AdminFoodDTO> GetFoodAdmin();
		int getRowFood();
		List<String> GetNameCategories();
		List<AdminFoodDTO> GetListFoods(string categories, string arrange, bool isDescending, string searchText);
        int ConvertCategoryNametoCategoryId(string Name);
        void AddData(string Name, int cateID, float Price, string Describe, string fileupload);
        void DeleteData(int id);
        dynamic FindFood(int id);
        void UpdateData(int FoodID, string Name, int CategoryID, float Price, string Describe, string fileupload);

    }
}
