using CheeseBurger.DTO;
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
				List_Districts = districtService.GetListDistricts();
				List_Wards = wardService.GetListWards();
				return Page();
			}
			return RedirectToPage("/Login/LoginRegister");
		}
		public IActionResult OnPost()
		{
			var customerId = HttpContext.Session.GetInt32("customerID");
			Carts = cartService.GetAllCarts((int)customerId);
			float totalMoney = 0;
			// Tinh tong tien
			foreach (var cart in Carts)
			{
				totalMoney += cart.Price * cart.Quantity;
			}
			totalMoney += 3 / 100 * totalMoney + 13000;
			// Tao don hang tong quat moi
			var order = new Orders
			{
				CustomerID = (int)HttpContext.Session.GetInt32("customerID"),
				CustomerName = Name,
				PhoneNumber = PhoneNumber,
				HourseNumber = HouseNumber,
				WardID = WardId,
				Note = Note,
				SaleDate = DateTime.Now,
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
			}
			return RedirectToPage("/Index");
		}
	}
}