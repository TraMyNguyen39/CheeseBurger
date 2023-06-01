using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;

namespace CheeseBurger.Repository
{
    public interface IIngredientsRespository
    {
		List<IngredientDTO> GetIngredients(string ingredientName);
		IngredientDTO getEachIngredient(int ingredientID);
		int getRowIngredient();
		List<string> getIngredientName();
		int ConvertMeasureNametoMeasureId(string Name);
		void AddData(string Name, int measureId, float Price, int partner);
		void DeleteData(int id);
		dynamic FindIngredient(int id);
		void UpdateData(int id, string Name, int measureId, float Price, int partner, float nlHong = 0);
		IngredientDTO getEachIngredients(int IngreID);
		List<IngredientDTO> GetListIngredients(string arrange, bool isDescending, string searchText);
		List<String> GetNameIngredient();
		List<CBBIngredientDTO> GetIngredientsByPartner(int partnerID);
		float GetPrice(int ingre);
		void UpdateQty(int ingredientID, float qty, bool isIncre);

    }
}
