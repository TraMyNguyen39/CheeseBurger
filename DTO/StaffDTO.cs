using CheeseBurger.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheeseBurger.DTO
{
	public class StaffDTO
	{
		public int StaID { get; set; }
        public string StaName { get; set; }
		public bool StaGender { get; set; }
        public string StaPhone { get; set; }
        public string StaEmail { get; set; }
        public bool StaIsStaff { get; set; }
        public bool StaIsDeleted { get; set; }
        public string StaRoleName { get; set; }
        public int StaAccID { get; set; }
		public string HouseNumber { get; set; }
		public int WardID { get; set; }
	}
}
