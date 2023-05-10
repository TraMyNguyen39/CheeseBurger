﻿using CheeseBurger.DTO;
using CheeseBurger.Enums;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
	public class PaymenteModel : PageModel
	{
		private readonly IWardService wardService;
		private readonly IDistrictService districtService;
		private readonly IOrderService orderService;
		private readonly IOrder_FoodService orderFoodService;
		private readonly ICartService cartService;
		public List<District> List_Districts { get; set; }
		public List<Ward> List_Wards { get; set; }
		public List<CartDTO> Carts { get; set; }
		[BindProperty]
		public string Name { get; set; }
		[BindProperty]
		public string PhoneNumber { get; set; }
		[BindProperty]
		public int WardId { get; set; }
		[BindProperty]
		public string HouseNumber { get; set; }
		[BindProperty]
		public string Note { get; set; }
		[BindProperty]
		public float tempMoney { get; set; }
		[BindProperty]
		public float shippingMoney { get; set; }
		public PaymenteModel(IWardService wardService, IOrderService orderService, 
			IDistrictService districtService, ICartService cartService, IOrder_FoodService orderFoodService)
		{
			this.wardService = wardService;
			this.districtService = districtService;
			this.orderService = orderService;
			this.cartService = cartService;
			this.orderFoodService = orderFoodService;
			this.orderFoodService = orderFoodService;
		}
		public IActionResult OnGet()
		{
			var customerId = HttpContext.Session.GetInt32("customerID");
			if (customerId != null)
			{
				Carts = cartService.GetAllCarts((int)customerId);
				// Tinh tong tien cua cac san pham trong gio hang
				tempMoney = (float)cartService.GetCartTotal(Carts);
				shippingMoney = 13000;

				List_Districts = districtService.GetListDistricts();
				List_Wards = wardService.GetListWards();
				return Page();
			}
			return RedirectToPage("/Login/LoginRegister");
		}
		public IActionResult OnPost()
		{
			var customerId = (int)HttpContext.Session.GetInt32("customerID");
			// Lay danh sach san pham trong gio hang
			Carts = cartService.GetAllCarts(customerId);
			// Tao don hang tong quat moi
			var order = new Orders
			{
				CustomerID = customerId,
				CustomerName = Name,
				PhoneNumber = PhoneNumber,
				HourseNumber = HouseNumber,
				WardID = WardId,
				Note = Note,
				SaleDate = DateTime.Now,
				TempMoney = tempMoney,
				ShippingMoney = shippingMoney,
				StatusOdr = (int)OrderStatus.waiting
			};
			orderService.CreateOrder(order);
			// Tao chi tietdon hang
			foreach (var cart in Carts)
			{
				var orderLine = new Order_Food
				{
					FoodID = cart.FoodId,
					OrderID = order.OrderID,
					QuantityOF = cart.Quantity,
					PriceOF = cart.Price
				};
				orderFoodService.CreateOrderDetail(orderLine);
				cartService.DeleteCart(customerId, cart.FoodId); // Tao don hon chi tiet, dong thoi xoa gio hang
			}
			return RedirectToPage("/User/MyOrder");
		}
	}
}