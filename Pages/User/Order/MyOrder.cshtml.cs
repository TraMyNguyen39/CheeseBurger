using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages.User.Order
{
    public class MyOrderModel : PageModel
    {
        private readonly IOrderService orderService;
        public List<OrderItemDTO> items { get; set; }
        [BindProperty(SupportsGet = true)]
        public int status { get; set; }
        public int[] orderCount { get; set; }
        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }
        public MyOrderModel(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult OnGet()
        {
            var customerId = HttpContext.Session.GetInt32("customerID");
            if (customerId != null)
            {
                items = orderService.GetListOrderByUser((int)customerId, status);
                orderCount = orderService.GetOrderCount((int)customerId);
                return Page();
            }
            return RedirectToPage("/Login/LoginRegister");
        }
    }
}