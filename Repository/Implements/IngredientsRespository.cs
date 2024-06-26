﻿using Azure.Messaging;
using CheeseBurger.DTO;
using CheeseBurger.Model;
using CheeseBurger.Model.Entities;
using CheeseBurger.Pages;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;

namespace CheeseBurger.Repository.Implements
{
	public class IngredientsRespository : IIngredientsRespository
	{
		private readonly CheeseBurgerContext context;

		public IngredientsRespository(CheeseBurgerContext context)
		{
			this.context = context;
		}

		public List<IngredientDTO> GetIngredients(string ingredientName)
		{
			if (ingredientName != null)
			{
				return context.Ingredients.Where(p => p.IngredientsName.Contains(ingredientName))
							  .Select(p => new IngredientDTO
							  {
								  IngredientID = p.IngredientsId,
								  IngredientName = p.IngredientsName,
								  IngredientInputPrice = p.IngredientsPrice,
								  MeasureName = p.Measure.MeasureName,
								  IngreQty = p.IngredientsQty
							  }).ToList();
			}
			else
			{
				return context.Ingredients.Select(p => new IngredientDTO
				{
					IngredientID = p.IngredientsId,
					IngredientName = p.IngredientsName,
					IngredientInputPrice = p.IngredientsPrice,
					MeasureName = p.Measure.MeasureName,
					IngreQty = p.IngredientsQty
				}).ToList();
			}
		}
		public IngredientDTO getEachIngredients(int IngreID)
		{
			var cus_data = from c in context.Ingredients
						   join a in context.Measures on c.MeasureID equals a.MeasureID
						   select new IngredientDTO
						   {
							   IngredientID = c.IngredientsId,
							   IngredientName = c.IngredientsName,
							   IngredientInputPrice = c.IngredientsPrice,
							   MeasureName = a.MeasureName,
							   IngreQty = c.IngredientsQty
						   };
			return cus_data.Where(p => p.IngredientID == IngreID).FirstOrDefault();
		}

		public List<IngredientDTO> GetListIngredients(string arrange, bool isDescending, string searchText)
		{
			var cus_data = from c in context.Ingredients
						   join a in context.Measures on c.MeasureID equals a.MeasureID
						   join p in context.Partners on c.PartnerID equals p.PartnerID
						   select new IngredientDTO
						   {
							   IngredientID = c.IngredientsId,
							   IngredientName = c.IngredientsName,
							   IngredientInputPrice = c.IngredientsPrice,
							   MeasureName = a.MeasureName,
							   isDeleted = c.IsDeleted,
							   PartnerName = p.PartnerName,
							   IngreQty = c.IngredientsQty
						   };

			if (!searchText.IsNullOrEmpty())
			{
				cus_data = cus_data.Where(p => p.IngredientName.Contains(searchText) || p.PartnerName.Contains(searchText)).Select(p => p);
			}
			switch (arrange)
			{
				case "name":
					cus_data = isDescending ? cus_data.OrderByDescending(p => p.IngredientName) : cus_data.OrderBy(p => p.IngredientName);
					break;
				case "price":
					cus_data = isDescending ? cus_data.OrderByDescending(p => p.IngredientInputPrice) : cus_data.OrderBy(p => p.IngredientInputPrice);
					break;
			}
			if (!searchText.IsNullOrEmpty())
				return cus_data.ToList();
			else
				return cus_data.ToList().Where(p => p.isDeleted == false).ToList();
		}
		public IngredientDTO getEachIngredient(int ingredientID)
		{
			return context.Ingredients.Where(p => p.IngredientsId.Equals(ingredientID))
				.Select(p => new IngredientDTO
				{
					IngredientID = p.IngredientsId,
					IngredientName = p.IngredientsName,
					IngredientInputPrice = p.IngredientsPrice,
					MeasureName = p.Measure.MeasureName,
					PartnerName = p.Partner.PartnerName,
					IngreQty = p.IngredientsQty,
				})
				.FirstOrDefault();
		}

		public List<string> getIngredientName()
		{
			return context.Measures.Select(p => p.MeasureName).Distinct().ToList();
		}

		public int getRowIngredient()
		{
			return context.Ingredients.Count();
		}

		public int ConvertMeasureNametoMeasureId(string Name)
		{
			var measure = context.Measures
						  .FirstOrDefault(p => p.MeasureName.Equals(Name));
			if (measure == null)
			{
				throw new ArgumentException($"Measure with name '{Name}' not found.");
			}

			return measure.MeasureID;
		}

        public int ConvertParnerNametoParnerId(string Name)
        {
			var partner = context.Partners.FirstOrDefault(p => p.PartnerName.Equals(Name));
            if (partner == null)
            {
                throw new ArgumentException($"Parner with name '{Name}' not found.");
            }

			return partner.PartnerID;
        }
        public void AddData(string Name, int measureId, float Price, int partner)
		{
			var measureExists = context.Measures.Any(m => m.MeasureID == measureId);
			var ingredientName = context.Ingredients.Any(m => m.IngredientsName == Name);

			if (!ingredientName)
			{
				var ingredient = new Ingredients
				{
					IngredientsName = Name,
					IngredientsPrice = Price,
					MeasureID = measureId,
					IsDeleted = false,
					PartnerID = partner
				};
				context.Ingredients.Add(ingredient);
				context.SaveChanges();
			}
		}

		public void DeleteData(int id)
		{
			var ingredient = context.Ingredients.Find(id);
			if (ingredient != null)
			{
				ingredient.IsDeleted = true;
				ingredient.IngredientsPrice = 0;
				ingredient.IngredientsQty = 0;
				context.SaveChanges();
			}
		}
		public dynamic FindIngredient(int id)
		{
			return context.Ingredients.Find(id);
		}
		public void UpdateData(int id, string Name, int measureId, float Price, int partner, float nlHong = 0)
		{
			var ingredient = context.Ingredients.Find(id);
			if (ingredient.IngredientsPrice != Price)
			{
				var foods = from p in context.Foods
							join f in context.Food_Ingredients on p.FoodID equals f.FoodID
							where f.IngredientsId == id
							select new { p, f };
				foreach (var i in foods)
				{
					i.p.originPrice += (Price - ingredient.IngredientsPrice) * i.f.QuantityIG;	
				}
			}	
			ingredient.IngredientsName = Name;
			ingredient.IngredientsPrice = Price;
			ingredient.MeasureID = measureId;
			ingredient.PartnerID = partner;
			if (nlHong != 0)
				ingredient.IngredientsQty -= nlHong;
			// bỏ qua trường IsDeleted
			context.Entry(ingredient).Property(x => x.IsDeleted).IsModified = false;
			context.SaveChanges();
		}

		public List<String> GetNameIngredient()
		{
			return context.Ingredients.Select(p => p.IngredientsName).ToList();
		}

		public List<CBBIngredientDTO> GetIngredientsByPartner(int partnerID)
		{
			var list = from c in context.Ingredients
					   where c.PartnerID == partnerID
					   join a in context.Measures on c.MeasureID equals a.MeasureID
					   select new CBBIngredientDTO
					   {
						   IngredientID = c.IngredientsId,
						   IngredientName = c.IngredientsName,
						   IngredientsPrice = c.IngredientsPrice,
						   UnitName = a.MeasureName
					   };
			return list.ToList();
		}

		public float GetPrice(int ingre)
		{
			var ingredient = context.ImportOrders_Ingredients.Find(ingre);
			return (ingredient != null) ? ingredient.PriceIO : 0;
		}

		public void UpdateQty(int ingredientID, float qty, bool isIncre)
		{
			var ingre = context.Ingredients.Find(ingredientID);
			if (ingre != null)
			{
				if (isIncre)
					ingre.IngredientsQty += qty;
				else
					ingre.IngredientsQty -= qty;
				context.SaveChanges();
			}
		}

		public void RecycleData(int id)
		{
			var ingredient = context.Ingredients.Find(id);
			ingredient.IsDeleted = false;
			context.SaveChanges();
		}
	}
}
