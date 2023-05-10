using CheeseBurger.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CheeseBurger.DTO
{
	public class ImportOrderDTO
	{
		public int ImportOrderID { get; set; }
		public DateTime DateIO { get; set; }
		public float TMoneyIO { get; set; }
		public string PartnerName { get; set; }
		public int StaffID { get; set;}
	}
}
