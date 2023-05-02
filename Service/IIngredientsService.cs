using CheeseBurger.DTO;
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
		void AddData(string Name, int measureId, float Price);
		void DeleteData(int id);
		dynamic FindIngredient(int id);
		void UpdateData(int id, string Name, int measureId, float Price);
		public IngredientDTO getEachIngredients(int IngreID);
		List<IngredientDTO> GetListIngredients(string arrange, bool isDescending, string searchText);
	}
}
