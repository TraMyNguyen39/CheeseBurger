﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheeseBurger.Model.Entities
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }
        [StringLength(100)]
        public string StaffName { get; set; }
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public bool? Gender { get; set; }
        public int AccountID { get; set; }
        [ForeignKey("AccountID")]
        public Account Account { get; set; }
        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Role Role { get; set; }

		public string HouseNumber { get; set; }
		public int? WardID { get; set; }
		[ForeignKey("WardID")]
		public Ward Ward { get; set; }
	}
}
