﻿using CheeseBurger.DTO;
using CheeseBurger.Enums;
using CheeseBurger.Model.Entities;
using CheeseBurger.Pages.User;
using CheeseBurger.Pages.User.Email;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CheeseBurger.Pages
{
	public class PaymenteModel : PageModel
	{
		private readonly IWardService wardService;
		private readonly IDistrictService districtService;
		private readonly IOrderService orderService;
		private readonly IOrder_FoodService orderFoodService;
		private readonly ICartService cartService;
		private readonly IAccountService accountService;
		private readonly IFeeAPIService feeService;
		private readonly IFood_IngredientsService foodIngreService;
		private readonly ICustomerService customerService;
		private readonly IConfiguration config;
		private readonly IStaffService staffService;
		private readonly IFoodService foodService;
		private readonly IReviewService reviewService;
		//private readonly HttpClient _httpClient;
		public List<District> List_Districts { get; set; }
		public List<Account> List_Account { get; set; }
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
		[BindProperty(SupportsGet = true)]
		public float shippingMoney { get; set; }
		[BindProperty]
		public float totalMoney { get; set; }
		public int orderId { get; set; }
		public string saleDate { get; set; }
		public CustomerDTO curCusPayment { get; set; }
		public int WId { get; set; }
		public int DId { get; set; }
		public PaymenteModel(IWardService wardService, IOrderService orderService, 
			IDistrictService districtService, ICartService cartService, IOrder_FoodService orderFoodService, 
			IFeeAPIService feeService, IConfiguration config, IAccountService accountService, IFood_IngredientsService foodIngreService, ICustomerService customerService,
			IStaffService staffService, IFoodService foodService,
			IReviewService reviewService)
		{
			this.wardService = wardService;
			this.districtService = districtService;
			this.orderService = orderService;
			this.cartService = cartService;
			this.orderFoodService = orderFoodService;
			this.foodIngreService= foodIngreService;
            this.config = config;
            this.feeService = feeService;
			this.accountService = accountService;
			this.customerService = customerService;
			this.staffService = staffService;
			this.foodService = foodService;
			this.reviewService = reviewService;
		}
		public async Task<IActionResult> OnPostCalculateAsync()
		{
			var customerId = HttpContext.Session.GetInt32("customerID");
			if (customerId != null)
			{
				int fromDistrictId = Convert.ToInt32(Request.Form["fromDistrictId"]);
				int serviceId = Convert.ToInt32(Request.Form["serviceId"]);
				int toDistrictId = Convert.ToInt32(Request.Form["toDistrictId"]);
				string toWardCode = Request.Form["toWardCode"];
				int height = Convert.ToInt32(Request.Form["height"]);
				int length = Convert.ToInt32(Request.Form["length"]);
				int weight = Convert.ToInt32(Request.Form["weight"]);
				int width = Convert.ToInt32(Request.Form["width"]);
				int insuranceValue = Convert.ToInt32(Request.Form["insuranceValue"]);

				var feeResults = await feeService.GetResult(fromDistrictId, serviceId, toDistrictId, toWardCode, height, length, weight, width, insuranceValue);
				foreach (var feeResult in feeResults.data)
				{
					shippingMoney = feeResult.Total;
				}
				Carts = cartService.GetAllCarts((int)customerId);
				// Tinh tong tien cua cac san pham trong gio hang
				tempMoney = (float)cartService.GetCartTotal(Carts);
				List_Districts = districtService.GetListDistricts();
				List_Wards = wardService.GetListWards();
				List_Account = accountService.GetListAccount();
			}

			string total = Request.Form["totalhidden"];
			total = total.Replace("₫", "");
			total = total.Replace(".", "");
			total = total.Trim();


			totalMoney = float.Parse(total);

			var customerID = (int)HttpContext.Session.GetInt32("customerID");
			// Lay danh sach san pham trong gio hang
			Carts = cartService.GetAllCarts(customerID);
			// Tao don hang tong quat moi
			var order = new Orders
			{
				CustomerID = customerID,
				CustomerName = Name,
				PhoneNumber = PhoneNumber,
				HourseNumber = HouseNumber,
				WardID = WardId,
				Note = Note,
				SaleDate = DateTime.Now,
				TempMoney = tempMoney,
				ShippingMoney = shippingMoney,
                TotalMoney = totalMoney,
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
				foodIngreService.DecreaseIngre(cart.FoodId, cart.Quantity);
				cartService.DeleteCart(customerID, cart.FoodId); // Tao don hon chi tiet, dong thoi xoa gio hang
			}
			string name = Request.Form["Name"]; // Retrieve the value of the 'Name' input			
			string wardId = Request.Form["WardId"];
			
			int wardIdInt = Convert.ToInt32(wardId);
			Ward temp = wardService.GetWard(wardIdInt);
			string wardName = null;
			if (temp != null)
			{
				wardName = temp.WardName;
			}
			string address = Request.Form["HouseNumber"] + ", " + wardName + ", " + Request.Form["combobox_Item_District"] + ", " + "Đà Nẵng";
			string dateTime = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
			string id = (orderService.NewestOrderID()).ToString();
			var model = new EmailModel(orderFoodService); // Create a new instance of the EmailModel
			model.TenNguoiNhan = name;
			model.TongTien = total;
			model.DiaChiGiaoHang = address;
			model.NgayDatHang = dateTime;
			model.MaDH = id;
			return RedirectToPage("/User/Email/MyAlternateOrder", new { id = id, name = name, total = total, address = address, dateTime = dateTime });
		}

		public IActionResult OnGet()
		{

			var customerId = HttpContext.Session.GetInt32("customerID");
			if (customerId != null)
			{

				Carts = cartService.GetAllCarts((int)customerId);
				// Tinh tong tien cua cac san pham trong gio hang
				tempMoney = (float)cartService.GetCartTotal(Carts);
				List_Districts = districtService.GetListDistricts();
				List_Wards = wardService.GetListWards();
				curCusPayment = customerService.GetCustomer((int)customerId);
				Ward tempWard = wardService.GetWard(curCusPayment.WardID);
				if (tempWard != null)
				{
					WId = tempWard.WardId;
					DId = tempWard.DistrictID;
				}
				else
				{
					WId = 1;
					DId = 1;
				}
				return Page();
			}
			List_Account = accountService.GetListAccount();
			orderId = orderService.NewestOrderID();
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
				TotalMoney = totalMoney,
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
				foodIngreService.DecreaseIngre(cart.FoodId, cart.Quantity);
				cartService.DeleteCart(customerId, cart.FoodId); // Tao don hon chi tiet, dong thoi xoa gio hang
			}
			string name = Request.Form["Name"]; // Retrieve the value of the 'Name' input
			string total = Request.Form["totalhidden"];
			string wardId = Request.Form["WardId"];
			int wardIdInt = Convert.ToInt32(wardId);
			Ward temp = wardService.GetWard(wardIdInt);
			string wardName = null;
			if (temp != null)
			{
				wardName = temp.WardName;
			}
			string address = Request.Form["HouseNumber"] + "," + wardName + "," + Request.Form["combobox_Item_District"] + "," + "Đà Nẵng";
			string dateTime = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
			string id = (orderService.NewestOrderID()).ToString();
			var model = new EmailModel(orderFoodService); // Create a new instance of the EmailModel
			model.TenNguoiNhan = name;
			model.TongTien = total;
			model.DiaChiGiaoHang = address;
			model.NgayDatHang = dateTime;
			model.MaDH = id;
			return RedirectToPage("/User/Email/MyAlternateOrder", new { id = id, name = name, total = total, address = address, dateTime = dateTime });
		}
	}
}