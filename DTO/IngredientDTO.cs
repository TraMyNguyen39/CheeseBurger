using CheeseBurger.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CheeseBurger.DTO
{
    public class IngredientDTO
    {
        public int IngredientID { get; set; }
        public String IngredientName { get; set; }
        public float IngredientInputPrice { get; set; }
        public string MeasureName { get; set; }
        public bool isDeleted { get; set; }
        public string PartnerName { get; set; }
    }
}
