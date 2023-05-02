using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class PaymenteModel : PageModel
    {
		private readonly IAddressService addressService;
		private readonly IWardService wardService;
		private readonly IDistrictService districtService;
		private readonly IOrderService orderService;
        //private readonly IOrder_FoodService orderFoodService;
        private readonly ICartService cartService;
        [BindProperty]
        public string name { get; set; }
        [BindProperty]
        public string phoneNumber { get; set; }


        public List<CartDTO> carts { get; set; }
		public PaymenteModel(IAddressService addressService, IWardService wardService, IOrderService orderService, 
            IDistrictService districtService, ICartService cartService)
        {
            this.addressService = addressService;
            this.wardService = wardService;
            this.districtService = districtService;
            this.orderService = orderService;
            this.cartService = cartService;
            //this.orderFoodService = orderFoodService;
        }
        public IActionResult OnGet()
        {
            var customerId = HttpContext.Session.GetInt32("customerID");
            if (customerId != null)
            {
				carts = cartService.GetAllCarts((int)customerId);
                return Page();
			}
			return RedirectToPage("/Login/LoginRegister");
        }
        public IActionResult OnPost()
        {
            return Page();
        }
    }
}