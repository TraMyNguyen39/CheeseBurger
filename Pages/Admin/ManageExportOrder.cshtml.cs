﻿using CheeseBurger.DTO;
using CheeseBurger.Middleware;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
			string fDate = Request.Query["fromDate"];
			if (DateTime.TryParse(fDate, out DateTime fromDateResult))
			{
				timeStart = fromDateResult;
			}

			string tDate = Request.Query["toDate"];
			if (DateTime.TryParse(tDate, out DateTime toDateResult))
			{
				timeEnd = toDateResult;
			}
			var role = HttpContext.Session.GetString("Role");
			if (role == "Nhân viên giao hàng")
			{
				items = orderService.GetAllOrderAdmin((int)Enums.OrderStatus.prepareDone, timeStart, timeEnd, searchText);
				orderCount = orderService.GetOrderCount(0);
				return Page();
            }
			items = orderService.GetAllOrderAdmin(0, timeStart, timeEnd, searchText);
			orderCount = orderService.GetOrderCount(0);
			return Page();
		}
	}
}
