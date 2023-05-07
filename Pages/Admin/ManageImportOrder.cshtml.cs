using CheeseBurger.DTO;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages
{
	public class ManageImportOrderModel : PageModel
	{
		private readonly IImportOrderService importOrderService;
		public List<ImportOrder> imports { get; set; }
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
