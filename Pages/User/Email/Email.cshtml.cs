using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace CheeseBurger.Pages.User.Email
{
    public class EmailModel : PageModel
    {
        public string MaDH { get; set; }
        public string TenNguoiNhan { get; set; }
        public string TongTien { get; set; }
        public string NgayDatHang { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public List<CartDTO> Carts { get; set; }
        public EmailModel()
        {

        }
    }
}
