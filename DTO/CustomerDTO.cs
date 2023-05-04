using CheeseBurger.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheeseBurger.DTO
{
	public class CustomerDTO
	{
		public int CusID { get; set; }
        public string CusName { get; set; }
		public bool CusGender { get; set; }
        public string CusPhone { get; set; }
        public string CusEmail { get; set; }
        public bool CusIsStaff { get; set; }
        public bool CusIsDeleted { get; set; }
        public int CusAccID { get; set; }
		public string HouseNumber { get; set; }
		public int WardID { get; set; }
	}
}
