using CheeseBurger.DTO;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
	public class ManageExportOrderModel : PageModel
	{
		private readonly IOrderService orderService;
		public List<OrderItemDTO> items { get; set; }
		[BindProperty(SupportsGet = true)]
		public int status { get; set; }
		public int[] orderCount { get; set; }
		public ManageExportOrderModel(IOrderService orderService)
		{
			this.orderService = orderService;
		}

		public IActionResult OnGet()
		{
			items = orderService.GetAllOrder(status);
			orderCount = orderService.GetOrderCount(0);
			return Page();
		}
	}
}
