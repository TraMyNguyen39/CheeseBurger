using CheeseBurger.DTO;
using CheeseBurger.Middleware;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CheeseBurger.Pages
{
	[Authorize("Quản trị viên", "Nhân viên đầu bếp", "Nhân viên giao hàng")]
	public class ManageExportOrderModel : PageModel
	{
		private readonly IOrderService orderService;
		public List<OrderItemDTO> items { get; set; }
		public int status { get; set; }
		public int type { get; set; }
		public int[] orderCount { get; set; }
		[BindProperty(SupportsGet = true, Name = "p")]
		public int currentPage { get; set; }
		public string searchText { get; set; }
		public DateTime timeStart { get; set; } = default(DateTime);
		public DateTime timeEnd { get; set; } = default(DateTime);
		public ManageExportOrderModel(IOrderService orderService)
		{
			this.orderService = orderService;
		}

		public IActionResult OnGet()
		{
			searchText = Request.Query["search"];
			if (searchText != null) searchText = searchText.Trim();
			string fDate = Request.Query["fromDate"];
			if (DateTime.TryParse(fDate, out DateTime fromDateResult))
			{
				timeStart = fromDateResult;
			} else
			{
				timeStart = default(DateTime);
			}

			string tDate = Request.Query["toDate"];
			string _type = Request.Query["t"];
			if (_type == null)
			{
				type = 0;
			}
			if (_type != null) {
				if (_type == "")
				{
					type = 0;
				} else
				{
					type = Convert.ToInt32(_type);
				}
			}
			if (type > 0)
			{
				if (DateTime.TryParse(tDate, out DateTime toDateResult))
				{
					timeEnd = toDateResult;
				}
				else
				{
					timeEnd = default(DateTime);
				}
			}
			else
			{
				if (DateTime.TryParse(tDate, out DateTime toDateResult))
				{
					TimeSpan timeSpan = new TimeSpan(23, 59, 59);
					timeEnd = toDateResult + timeSpan;
				}
				else
				{
					timeEnd = default(DateTime);
				}
			}
			string statusUrl = Request.Query["status"];
			if (statusUrl != null)
			{
				status = Convert.ToInt32(statusUrl);
			} else
			{
				status = 0;
			}
			var role = HttpContext.Session.GetString("Role");
			if (role == "Nhân viên giao hàng")
			{
				if (status == 0)
				{
					items = orderService.GetAllOrderShip1(1, 2, timeStart, timeEnd, searchText);
					orderCount = orderService.GetManageOrderCountShip(1, 2, timeStart, timeEnd, searchText);
					return Page();
				} else if (status == (int) Enums.OrderStatus.prepareDone)
				{
					items = orderService.GetAllOrderShip2(0, 3, timeStart, timeEnd, searchText);
					orderCount = orderService.GetManageOrderCountShip(1, 2, timeStart, timeEnd, searchText);
					return Page();
				} else if (status == (int) Enums.OrderStatus.shipping)
				{
					items = orderService.GetAllOrderShip2(0, 4, timeStart, timeEnd, searchText);
					orderCount = orderService.GetManageOrderCountShip(1, 2, timeStart, timeEnd, searchText);
					return Page();
				} else if (status == (int) Enums.OrderStatus.completed)
				{
					items = orderService.GetAllOrderShip2(0, 5, timeStart, timeEnd, searchText);
					orderCount = orderService.GetManageOrderCountShip(1, 2, timeStart, timeEnd, searchText);
					return Page();
				} else if (status == (int)Enums.OrderStatus.canceled)
				{
					items = orderService.GetAllOrderShip2(0, 7, timeStart, timeEnd, searchText);
					orderCount = orderService.GetManageOrderCountShip(1, 2, timeStart, timeEnd, searchText);
					return Page();
				} else if (status == (int)Enums.OrderStatus.closed)
				{
					items = orderService.GetAllOrderShip2(0, 6, timeStart, timeEnd, searchText);
					orderCount = orderService.GetManageOrderCountShip(1, 2, timeStart, timeEnd, searchText);
					return Page();
				}
				items = orderService.GetAllOrderShip2(0, 0, timeStart, timeEnd, searchText);
				orderCount = orderService.GetManageOrderCountShip(1, 2, timeStart, timeEnd, searchText);
				return Page();
			}
			if (role == "Nhân viên đầu bếp")
			{
				if (status == 0)
				{
					items = orderService.GetAllOrderChef(1, 2, timeStart, timeEnd, searchText);
					orderCount = orderService.GetManageOrderCountChef(1, 2, timeStart, timeEnd, searchText);
					return Page();
				} 
				else if (status == (int) Enums.OrderStatus.waiting)
				{
					items = orderService.GetAllOrderChef(0, 1, timeStart, timeEnd, searchText);
					orderCount = orderService.GetManageOrderCountChef(1, 2, timeStart, timeEnd, searchText);
					return Page();
				} else if (status == (int) Enums.OrderStatus.preparing)
				{
					items = orderService.GetAllOrderChef(0, 2, timeStart, timeEnd, searchText);
					orderCount = orderService.GetManageOrderCountChef(1, 2, timeStart, timeEnd, searchText);
					return Page();
				}
				items = orderService.GetAllOrderChef(0, 0, timeStart, timeEnd, searchText);
				orderCount = orderService.GetManageOrderCountChef(1, 2, timeStart, timeEnd, searchText);
				return Page();				
			}
			items = orderService.GetAllOrderAdmin(status, timeStart, timeEnd, searchText);
			orderCount = orderService.GetManageOrderCount(timeStart, timeEnd, searchText);
			return Page();
		}
	}
}
