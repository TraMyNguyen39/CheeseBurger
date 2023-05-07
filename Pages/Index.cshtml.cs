using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService categoryService;
        public int HamburgerId { get; set; }
        public int GaId { get; set; }
        public int ThucUongId { get; set; }
        public int TrangMiengId { get; set; }
        public IndexModel(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public void OnGet()
        {
            HamburgerId = categoryService.GetCategoryIdByName("Hamburger");
            GaId = categoryService.GetCategoryIdByName("Gà quay - Gà rán");
            ThucUongId = categoryService.GetCategoryIdByName("Thức uống");
            TrangMiengId = categoryService.GetCategoryIdByName("Tráng miệng");
        }
    }
}