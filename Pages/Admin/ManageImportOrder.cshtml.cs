using CheeseBurger.DTO;
using CheeseBurger.Middleware;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
    [Authorize("Quản trị viên","Nhân viên đầu bếp")]
    public class ManageImportOrderModel : PageModel
	{
		private readonly IImportOrderService importOrderService;
		[BindProperty(SupportsGet = true, Name = "p")]
		public int currentPage { get; set; }
		public List<ImportOrderDTO> imports { get; set; }
		public ManageImportOrderModel(IImportOrderService importOrderService)
		{
			this.importOrderService = importOrderService;
		}

		public IActionResult OnGet()
		{
			imports = importOrderService.GetAllImport();
			return Page();
		}
	}
}
