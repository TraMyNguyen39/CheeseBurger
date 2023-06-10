using CheeseBurger.DTO;
using CheeseBurger.Middleware;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CheeseBurger.Pages.Admin
{
    [Authorize("Quản trị viên")]
    public class SyncRevenueModel : PageModel
	{
        private readonly IRevenueService revenueService;
		public SyncRevenueModel(IRevenueService revenueService)
        {
            this.revenueService = revenueService;
        }

		[BindProperty(SupportsGet = true)]
		public int NumberOrder { get; set; }
		[BindProperty(SupportsGet = true)]
		public int NumberIOrder { get; set; }
		[BindProperty(SupportsGet = true)]
		public float TotalFund { get; set; }
		[BindProperty(SupportsGet = true)]
		public float TotalIncome { get; set; }

		public float TotalProfit { get; set; }        
        public DateTime fromDate { get; set; }
		public DateTime toDate { get; set; }
		public List<Orders> List_Ord { get; set; }
		public List<ImportOrder> List_IO { get; set; }
		public List<FoodRevenueDTO> List_Food { get; set; }
		public List<CustomerRevenueDTO> List_CusRevenue { get; set; }

		public void OnGet()
		{
			string seleOption = Request.Query["selectOption"];
			string fDate = Request.Query["fromDate"];
			string tDate = Request.Query["toDate"];
			if (DateTime.TryParse(fDate, out DateTime fromDateResult))
			{
				fromDate = fromDateResult;
			}
			if (DateTime.TryParse(tDate, out DateTime toDateResult))
			{
				if (seleOption == "day")
				{
					TimeSpan timeSpan = new TimeSpan(23, 59, 59);
					toDate = toDateResult + timeSpan;
				} else if(seleOption == "month")
				{
					toDate = toDateResult.AddMonths(1);
				} else
				{
					toDate = toDateResult.AddYears(1);
				}
			} 
			
		    NumberIOrder = revenueService.NumberIOrder(fromDate, toDate);
			NumberOrder = revenueService.NumberOrder(fromDate, toDate);
			TotalFund = revenueService.TotalFund(fromDate, toDate);
			TotalIncome = revenueService.TotalIncome(fromDate, toDate);
			TotalProfit = TotalIncome - TotalFund;
			List_Ord = revenueService.GetOrdersRangeTime(fromDate, toDate);
			List_IO = revenueService.GetIOrdersRangeTime(fromDate, toDate);
			List_Food = revenueService.GetFoodRangeTime(fromDate, toDate);
			List_CusRevenue = revenueService.GetCustomerRangeTime(fromDate, toDate);
		}
	}
}
