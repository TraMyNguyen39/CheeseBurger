using CheeseBurger.DTO;
using CheeseBurger.Middleware;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace CheeseBurger.Pages.Admin
{
    [Authorize("Quản trị viên","Nhân viên đầu bếp","Nhân viên giao hàng")]
    public class ImportOrderDetailModel : PageModel
    {
        private readonly IImportOrderService importOrderService;
        private readonly IImportOrders_IngredientsService importOrders_IngredientsService;
        private readonly IIngredientsService ingredientsService;
		private readonly IStaffService staffService;
		public ImportOrderDTO order { get; set; }
		public StaffDTO staff { get; set; }
		public List<ImportLineDTO> lineItems { get; set; }
		[BindProperty(SupportsGet = true)]
		public int orderId { get; set; }
		public ImportOrderDetailModel(IImportOrderService importOrderService,
            IImportOrders_IngredientsService importOrders_IngredientsService,
            IStaffService staffService, IIngredientsService ingredientsService)
        {
            this.importOrderService = importOrderService;
            this.importOrders_IngredientsService= importOrders_IngredientsService;
            this.ingredientsService = ingredientsService;
            this.staffService = staffService;
        }

        public IActionResult OnGet()
        {
            order = importOrderService.GetImportOrder(orderId);
			if (order != null)
			{
                staff = staffService.GetStaff(order.StaffID);
				lineItems = importOrders_IngredientsService.GetAllLines(orderId);
				return Page();
			}
			return RedirectToPage("/Error");
		}
        public IActionResult OnPostDelete(int orderId)
        {
			lineItems = importOrders_IngredientsService.GetAllLines(orderId);
            foreach (var i in lineItems)
            {
                ingredientsService.UpdateQty(i.IngreID, i.QuantityIO, false);
            }
			importOrders_IngredientsService.DeleteOrderDetail(orderId);
            importOrderService.RemoveOrder(orderId);
            return RedirectToPage("/Admin/ManageImportOrder");
        }
    }
}
