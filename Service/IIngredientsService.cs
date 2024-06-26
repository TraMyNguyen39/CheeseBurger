﻿using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Service
{
    public interface IIngredientsService
    {
		List<IngredientDTO> GetIngredients(string ingredientName);
		IngredientDTO getEachIngredient(int ingredientID);
		int getRowIngredient();
		List<string> getIngredientName();
		int ConvertMeasureNametoMeasureId(string Name);
		void AddData(string Name, int measureId, float Price, int partner);
		void DeleteData(int id);
		void RecycleData(int id);
		dynamic FindIngredient(int id);
		void UpdateData(int id, string Name, int measureId, float Price, int partner, float nlHong = 0);
		public IngredientDTO getEachIngredients(int IngreID);
		List<IngredientDTO> GetListIngredients(string arrange, bool isDescending, string searchText);
		List<String> GetNameIngredient();
		List<CBBIngredientDTO> GetIngredientsByPartner(int partnerID);
		float GetPrice(int ingre);
		void UpdateQty(int ingredientID, float qty, bool isIncre);
        int ConvertParnerNametoParnerId(string Name);
    }
}
