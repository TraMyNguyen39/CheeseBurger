using CheeseBurger.DTO;
using CheeseBurger.Middleware;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    [Authorize("Quản trị viên","Nhân viên đầu bếp","Nhân viên giao hàng")]
    public class ManageExportOrderModel : PageModel
	{
		private readonly IOrderService orderService;
		public List<OrderItemDTO> items { get; set; }
		[BindProperty(SupportsGet = true)]
		public int status { get; set; }
		public int[] orderCount { get; set; }
		[BindProperty(SupportsGet = true, Name = "p")]
		public int currentPage { get; set; }
		public ManageExportOrderModel(IOrderService orderService)
		{
			this.orderService = orderService;
		}

		public IActionResult OnGet()
		{
			items = orderService.GetAllOrder(status);
			var role = HttpContext.Session.GetString("Role");
			if (role == "Nhân viên giao hàng")
			{
                orderCount = orderService.GetOrderCount((int)Enums.OrderStatus.prepareDone);
				return Page();
            }
            orderCount = orderService.GetOrderCount(0);
			return Page();
		}
	}
}
