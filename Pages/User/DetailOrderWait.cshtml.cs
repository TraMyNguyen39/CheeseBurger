using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting.Internal;
using System.Net;

namespace CheeseBurger.Pages
{
    public class DetailOrderWaitModel : PageModel
    {
        private readonly IOrderService orderService;
        private readonly IOrder_FoodService order_FoodService;
        private readonly IWardService wardService;
        private readonly IDistrictService districtService;
        private readonly IStaffService staffService;
        private readonly ICartService cartService;
        private readonly IFoodService foodService;
        private readonly IReviewService reviewService;
		private IWebHostEnvironment hostingEnvironment;
		public Orders order { get; set; }
        public string address { get; set; }
        public StaffOrderDTO chef { get; set; }
        public StaffOrderDTO shipper { get; set; }
        public List<LineItemDTO> lineItems { get; set; }
        public List<Review> reviewOrder { get; set; }
        [BindProperty (SupportsGet = true)]
        public int orderId { get; set; }
        public DetailOrderWaitModel(IOrderService orderService, IOrder_FoodService order_FoodService, ICartService cartService,
            IWardService wardService, IDistrictService districtService, IStaffService staffService, IFoodService foodService, 
            IReviewService reviewService, IWebHostEnvironment hostingEnvironment)
        {
            this.orderService = orderService;
            this.order_FoodService = order_FoodService;
            this.cartService = cartService;
            this.wardService = wardService;
            this.districtService = districtService;
            this.staffService = staffService;
            this.foodService = foodService;
            this.reviewService = reviewService;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult OnGet()
        {
            var customerID = HttpContext.Session.GetInt32("customerID");
            if (customerID != null)
            {
                order = orderService.GetOrderDetail((int)customerID, orderId);
                if (order != null)
                {
                    var wrd = wardService.GetWard(order.WardID);
                    var dis = districtService.GetDistrict(wrd.DistrictID);
                    address = order.HourseNumber + ", " + wrd.WardName + ", " + dis.DistrictName + ", Đà Nẵng";

                    chef = order.ChefID != null ? staffService.GetStaffOrder((int)order.ChefID) : null;
                    shipper = order.ShipperID != null ? staffService.GetStaffOrder((int)order.ShipperID) : null;
                    lineItems = order_FoodService.GetAllLine(orderId);
                    reviewOrder = reviewService.GetReviewByOrderID(orderId);
                    return Page();
                }
            }
            return RedirectToPage("/Error");
        }
		public IActionResult OnPostCancel()
		{
			orderService.ChangeStatus(orderId, (int)Enums.OrderStatus.canceled);
            return RedirectToPage("/User/DetailOrderWait", new { orderId = orderId});
		}
        public IActionResult OnPostReOrder()
        {
			var customerID = HttpContext.Session.GetInt32("customerID");
			var orderLines = order_FoodService.ReOrder(orderId);
            foreach (var orderLine in orderLines)
            {
                cartService.AddCart((int)customerID, orderLine.FoodID, orderLine.QuantityOF);
            }
			return RedirectToPage("/User/Cart");
		}
		public IActionResult OnGetFind(int id)
		{
            var food = foodService.GetFoodbyId(id);
			var result = new
			{
				foodID = food.FoodID,
				foodName = food.FoodName,
				imageFood = food.ImageFood,
                star = 5
			};
			return new JsonResult(result);			
		}
		public async Task<IActionResult> OnPostReviewAsync(int FoodID, int StarReview, string content_review, IFormFile fileupload, int _OrderID)
		{                
			var customerID = HttpContext.Session.GetInt32("customerID");
			DateTime tmp = DateTime.Now;
			if (fileupload != null && fileupload.Length > 0)
			{
				var fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileupload.FileName);
				var filePath = Path.Combine(hostingEnvironment.WebRootPath, "img", fileName);

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await fileupload.CopyToAsync(stream);
				}                
                reviewService.AddNewReview(FoodID, StarReview, content_review, fileName, tmp, (int)customerID, _OrderID);
			}
			else
			{
				reviewService.AddNewReview(FoodID, StarReview, content_review, null, tmp, (int)customerID, _OrderID);
			}

			return RedirectToPage("/User/DetailOrderWait", new { orderId = _OrderID });
		}
	}
}