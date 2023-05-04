using CheeseBurger.DTO;
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
		//private readonly IOrderService orderService;
        //private readonly IOrder_FoodService orderFoodService;
        private readonly ICartService cartService;
		public List<District> List_Districts { get; set; }
		public List<Ward> List_Wards { get; set; }
        public List<CartDTO> carts { get; set; }
		[BindProperty]
        public string name { get; set; }
        [BindProperty]
        public string phoneNumber { get; set; }
		[BindProperty]
		public int wardId { get; set; }
		[BindProperty]
		public int districtId { get; set; }
		[BindProperty]
		public string hourseNumber { get; set; }
		public PaymenteModel(IWardService wardService,
            IDistrictService districtService, ICartService cartService)
        {
            this.wardService = wardService;
            this.districtService = districtService;
            //this.orderService = orderService;
            this.cartService = cartService;
            //this.orderFoodService = orderFoodService;
        }
        public IActionResult OnGet()
        {
            var customerId = HttpContext.Session.GetInt32("customerID");
            if (customerId != null)
            {
				carts = cartService.GetAllCarts((int)customerId);
				List_Districts = districtService.GetListDistricts();
				List_Wards = wardService.GetListWards();
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