using CheeseBurger.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheeseBurger.DTO
{
	public class CustomerRevenueDTO
	{
		public int CusRevenueID { get; set; }
        public string CusRevenueName { get; set; }
		public double CusRevenueTMoney { get; set; }
	}
}
