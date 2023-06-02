using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;

namespace CheeseBurger.Service.ImplementsGetPrice
{
	public class IngredientsService : IIngredientsService
	{
		private readonly IIngredientsRespository ingredientsRespository;
		public IngredientsService(IIngredientsRespository ingredientsRespository)
		{
			this.ingredientsRespository = ingredientsRespository;
		}

		public List<IngredientDTO> GetIngredients(string ingredientName)
		{
			return ingredientsRespository.GetIngredients(ingredientName);
		}

		public IngredientDTO getEachIngredient(int ingredientID)
		{
			return ingredientsRespository.getEachIngredient(ingredientID);
		}

		public int getRowIngredient()
		{
			return ingredientsRespository.getRowIngredient();
		}

		public List<string> getIngredientName()
		{
			return ingredientsRespository.getIngredientName();
		}
		public int ConvertMeasureNametoMeasureId(string Name)
		{
			return ingredientsRespository.ConvertMeasureNametoMeasureId(Name);
		}
		public void AddData(string Name, int measureId, float Price, int partner)
		{
			ingredientsRespository.AddData(Name, measureId, Price, partner);
		}
		public void DeleteData(int id)
		{
			ingredientsRespository.DeleteData(id);
		}
		public dynamic FindIngredient(int id)
		{
			return ingredientsRespository.FindIngredient(id);
		}

		public void UpdateData(int id, string Name, int measureId, float Price, int partner, float nlHong = 0)
		{
			ingredientsRespository.UpdateData(id, Name, measureId, Price, partner, nlHong);
		}

		public IngredientDTO getEachIngredients(int IngreID)
		{
			return ingredientsRespository.getEachIngredients(IngreID);
		}

		public List<IngredientDTO> GetListIngredients(string arrange, bool isDescending, string searchText)
		{
			return ingredientsRespository.GetListIngredients(arrange, isDescending, searchText);
		}
		public List<String> GetNameIngredient()
		{
			return ingredientsRespository.GetNameIngredient();
		}

		public List<CBBIngredientDTO> GetIngredientsByPartner(int partnerID)
		{
			return ingredientsRespository.GetIngredientsByPartner(partnerID);
		}

		public float GetPrice(int ingre)
		{
			return ingredientsRespository.GetPrice(ingre);
		}

		public void UpdateQty(int ingredientID, float qty, bool isIncre)
		{
			ingredientsRespository.UpdateQty(ingredientID, qty, isIncre);
		}

		public int ConvertParnerNametoParnerId(string Name)
		{
			return ingredientsRespository.ConvertParnerNametoParnerId(Name);
		}
    }
}
