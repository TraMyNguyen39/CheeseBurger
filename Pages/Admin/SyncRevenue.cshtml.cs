using CheeseBurger.DTO;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages.Admin
{
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

		public DateTime fromDate { get; set; }
		public DateTime toDate { get; set; }

		public void OnGet()
		{
			if (DateTime.TryParse(Request.Query["fromDate"], out DateTime fromDateResult))
			{
				fromDate = fromDateResult;
			}

			if (DateTime.TryParse(Request.Query["toDate"], out DateTime toDateResult))
			{
				toDate = toDateResult;
			}
		    NumberIOrder = revenueService.NumberIOrder(fromDate, toDate);
			NumberOrder = revenueService.NumberOrder(fromDate, toDate);
			TotalFund = revenueService.TotalFund(fromDate, toDate);
			TotalIncome = revenueService.TotalIncome(fromDate, toDate);
		}
	}
}
