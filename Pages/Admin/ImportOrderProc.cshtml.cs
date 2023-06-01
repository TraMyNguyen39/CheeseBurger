using CheeseBurger.DTO;
using CheeseBurger.Enums;
using CheeseBurger.Middleware;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System;

namespace CheeseBurger.Pages.Admin
{
    [Authorize("Quản trị viên","Nhân viên đầu bếp")]
    public class ImportOrderProcModel : PageModel
    {
        private readonly IImportOrderService importOrderService;
        private readonly IPartnerService partnerService;
        private readonly IIngredientsService ingredientsService;
		private readonly IImportOrders_IngredientsService importOrders_IngredientsService;
		[BindProperty(SupportsGet = true)]
		public List<CBBPartnerDTO> partners { get; set; }
		public List<CBBIngredientDTO> ingres { get; set; }
        [BindProperty(SupportsGet = true)]
        public int partner { get; set; }
		[BindProperty(SupportsGet = true)]
		public int ingredient_0 { get; set; }
		[BindProperty(SupportsGet = true)]
		public int ingredient_1 { get; set; }
		[BindProperty(SupportsGet = true)]
		public int ingredient_2 { get; set; }
		[BindProperty(SupportsGet = true)]
		public int ingredient_3 { get; set; }
		[BindProperty(SupportsGet = true)]
		public int ingredient_4 { get; set; }
		[BindProperty(SupportsGet = true)]
		public int ingredient_5 { get; set; }
		[BindProperty(SupportsGet = true)]
		public float? qty_0 { get; set; }
		[BindProperty(SupportsGet = true)]
		public float? qty_1 { get; set; }
		[BindProperty(SupportsGet = true)]
		public float? qty_2 { get; set; }
		[BindProperty(SupportsGet = true)]
		public float? qty_3 { get; set; }
		[BindProperty(SupportsGet = true)]
		public float? qty_4 { get; set; }
		[BindProperty(SupportsGet = true)]
		public float? qty_5 { get; set; }

		public ImportOrderProcModel (IImportOrderService importOrderService, IPartnerService partnerService, IIngredientsService ingredientsService, IImportOrders_IngredientsService importOrders_IngredientsService)
        {
            this.importOrderService = importOrderService;
            this.partnerService = partnerService;
            this.ingredientsService = ingredientsService;
			this.importOrders_IngredientsService = importOrders_IngredientsService;
        }
        public void OnGet()
        {
            partners = partnerService.GetListPartner();
        }
		public IActionResult OnGetIngredient(int partnerID)
		{
            ingres = ingredientsService.GetIngredientsByPartner(partnerID);
            return new JsonResult(ingres);
		}
		public IActionResult OnPost()
		{
			var staffID = (int)HttpContext.Session.GetInt32("staffID");
			// Tao don hang tong quat moi
			var order = new ImportOrder
			{
				DateIO = DateTime.Now,
				PartnerID = partner,
				StaffID = staffID,
				TMoneyIO = 0,
			};
			importOrderService.CreateOrder(order);
			if (ingredient_0 != 0 && qty_0 != null)
			{
				importOrders_IngredientsService.CreateOrderDetail(order.ImportOrderID, ingredient_0, (float)qty_0);
				ingredientsService.UpdateQty(ingredient_0, (float)qty_0, true);
			}

			if (ingredient_1 != 0 && qty_1 != null)
			{
				importOrders_IngredientsService.CreateOrderDetail(order.ImportOrderID, ingredient_1, (float)qty_1);
				ingredientsService.UpdateQty(ingredient_1, (float)qty_1, true);
			}

			if (ingredient_2 != 0 && qty_2 != null)
			{
				importOrders_IngredientsService.CreateOrderDetail(order.ImportOrderID, ingredient_2, (float)qty_2);
				ingredientsService.UpdateQty(ingredient_2, (float)qty_2, true);
			}

			if (ingredient_3 != 0 && qty_3 != null)
			{
				importOrders_IngredientsService.CreateOrderDetail(order.ImportOrderID, ingredient_3, (float)qty_3);
				ingredientsService.UpdateQty(ingredient_3, (float)qty_3, true);
			}

			if (ingredient_4 != 0 && qty_4 != null)
			{
				importOrders_IngredientsService.CreateOrderDetail(order.ImportOrderID, ingredient_4, (float)qty_4);
				ingredientsService.UpdateQty(ingredient_4, (float)qty_4, true);
			}

			if (ingredient_5 != 0 && qty_5 != null)
			{
				importOrders_IngredientsService.CreateOrderDetail(order.ImportOrderID, ingredient_5, (float)qty_5);
				ingredientsService.UpdateQty(ingredient_5, (float)qty_5, true);
			}
			importOrderService.CalculateMoney(order.ImportOrderID);
			return RedirectToPage("/Admin/ManageImportOrder");
		}
	}
}
