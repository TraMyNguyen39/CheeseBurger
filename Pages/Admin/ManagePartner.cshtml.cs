using CheeseBurger.DTO;
using CheeseBurger.Middleware;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Globalization;

namespace CheeseBurger.Pages.Admin
{
    [Authorize("Quản trị viên")]
    public class ManagePartnerModel : PageModel
	{
        private readonly IPartnerService partnerService;

		[BindProperty(SupportsGet = true)]
		public List<Partner> partners { get; set; }

		[BindProperty(SupportsGet = true)]
		public int measureId { get; set; }
		public ManagePartnerModel(IPartnerService partnerService)
		{
			this.partnerService = partnerService;
		}

		[BindProperty(SupportsGet = true, Name = "p")]
		public int currentPage { get; set; }
		[BindProperty(SupportsGet = true)]
		public string sortBy { get; set; }
		[BindProperty(SupportsGet = true)]
		public string searchText { get; set; }
		[BindProperty(SupportsGet = true)]
		public bool isDescending { get; set; }
		[BindProperty(SupportsGet = true)]
		public int partnerID { get; set; }
		[BindProperty(SupportsGet = true)]
		public bool isDelete { get; set; } = false;
		[BindProperty]
		public string email { get; set; }
		[BindProperty]
		public string partnerName { get; set; }

		public string ExistError { get; set; }

		public void OnGet()
		{
			this.searchText = Request.Query["search"];
			this.sortBy = Request.Query["sortBy"];
			if (!(sortBy.IsNullOrEmpty()) || sortBy == "all")
			{
				string[] values = sortBy.Split('-');
				string arrange = values[0];
				bool isDescending = (values[1] == "desc");
				partners = partnerService.GetListPartner(searchText, arrange, isDescending);
			}
			else
			{
				partners = partnerService.GetListPartner(searchText, null, true);
			}

			// paging
			int totalRow = partners.Count;
		}
		public IActionResult OnPostCreate(string partnerName, string email)
		{
			//if (string.IsNullOrEmpty(combobox_Item))
			//{
			//    ModelState.AddModelError("combobox_Item", "Please select a measure.");
			//}
			bool checkExist = false;
			partnerName = partnerName.Trim();
			foreach (var item in partners)
			{
				if (item.PartnerName.ToLower() == partnerName.ToLower())
					checkExist = true;
			}
			if (!checkExist)
			{
				partnerService.AddPartner(new Partner { PartnerName = partnerName, Email = email, isDeleted = false });
			}
			return RedirectToPage("ManagePartner");
		}

		public IActionResult OnPostDelete(int partnerID)
		{
			partnerService.DeletePartner(partnerID);
			return RedirectToPage("ManagePartner");
		}

		public IActionResult OnGetFind(int partnerID)
		{
			var partner = partnerService.GetPartner(partnerID);
			return new JsonResult(partner);
		}

		public IActionResult OnPostUpdate(int partnerID, string partnerName, string email)
		{
			partnerName = partnerName.Trim();
			var partnerUpdate = partnerService.GetPartner(partnerID);
			partnerUpdate.PartnerName = partnerName;
			partnerUpdate.Email = email;
			partnerService.UpdatePartner(partnerUpdate);
			return RedirectToPage("ManagePartner");
		}
		public IActionResult OnPostRecycle(int PartnerID)
		{
			partnerService.RecyclePartner(PartnerID);
			return RedirectToPage("ManagePartner");
		}
	}
}
