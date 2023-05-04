﻿using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IFoodRepository
    {
		List<FoodDTO> GetFoodsMenu(int category, int priceRange, string arrange, bool isDescending, string searchText);
		Food GetFoodbyId(int foodId);
	}
}
