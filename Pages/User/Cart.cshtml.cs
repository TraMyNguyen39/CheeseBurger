using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class CartModel : PageModel
    {
        private readonly ICartService cartService;
        public List<CartDTO> carts { get; set; }
        [BindProperty]
        public int foodId { get; set; }
        [BindProperty]
        public int quantity { get; set; }
        public double totalMoney { get; set; }
        public string message { get; set; }
        public CartModel(ICartService cartService)
        {
            this.cartService = cartService;
        }
        public IActionResult OnGet()
        {
            var customerID = HttpContext.Session.GetInt32("customerID");
            if (customerID == null)
                return RedirectToPage("/Login/LoginRegister", new { Message = "* Bạn phải đăng nhập/ đăng ký trước khi tương tác với giỏ hàng" });
            //DateTime now = DateTime.Now;
            //DateTime fixedTimeStart = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);
            //DateTime fixedTimeClosed = new DateTime(now.Year, now.Month, now.Day, 18, 0, 0);
            //if (now < fixedTimeStart || now > fixedTimeClosed)
            //{
            //    return RedirectToPage("/Error", new { Message = "Cửa hàng chưa mở cửa, vui lòng quay lại sau!" });
            //}
            // Trường hợp có có tài khoản trong giờ hành chính
            carts = cartService.GetAllCarts((int)customerID);
            if (carts.Count == 0)
                return RedirectToPage("/User/EmptyCart");
            else
            {
                totalMoney = cartService.GetCartTotal(carts);
                return Page();
            }
        }
        public IActionResult OnPost([FromForm] int foodId, [FromForm] int quantity)
        {
            var customerID = HttpContext.Session.GetInt32("customerID");
            cartService.UpdateCart((int)customerID, foodId, quantity);
            return RedirectToPage("/User/Cart");
        }
        public IActionResult OnPostRemovecart([FromForm] int foodId)
        {
            var customerID = HttpContext.Session.GetInt32("customerID");
            cartService.DeleteCart((int)customerID, foodId);
            return RedirectToPage("/User/Cart");
        }
    }
}