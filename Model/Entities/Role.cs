﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheeseBurger.Model.Entities
{
    public class Role
    {
		[Key]
		public int RoleID { get; set; }
		[Required]
		[StringLength(50)]
		public string RoleName { get; set; }
	}
}
