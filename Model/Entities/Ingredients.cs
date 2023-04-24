﻿using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CheeseBurger.Model.Entities
{
    public class Ingredients
    {
        [Key]
        public int IngredientsId { get; set; }

        [Required]
        [StringLength(200)]

        public String IngredientsName { get; set; } = String.Empty;
		[Required]
		public float IngredientsPrice { get; set; }
		[Required]
		public bool IsDeleted { get; set; }

        public int MeasureID { get; set; }
        [ForeignKey("MeasureID")]
        public Measure Measure { get; set; }

    }
}
