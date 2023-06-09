using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Dynamic;

namespace CheeseBurger.Pages.User.Email
{
    public class EmailModel : PageModel
    {
        private readonly IOrder_FoodService order_FoodService;
        public string MaDH { get; set; } 
        public string TenNguoiNhan { get; set; } 
        public string TienShip { get; set; }
        public string TongTien { get; set; }  
        public string NgayDatHang { get; set; } 
        public string DiaChiGiaoHang { get; set; } 

        public List<LineItemDTO> List_LineItems { get; set; }
        public string LineItemsHtml { get; set; } 
        public EmailModel(IOrder_FoodService order_FoodService)
        {
            this.order_FoodService = order_FoodService;
        }
        public void OnGet()
        {
            int idord = Convert.ToInt32(MaDH);
            List_LineItems = order_FoodService.GetAllLine(idord);
        }
    }
}
