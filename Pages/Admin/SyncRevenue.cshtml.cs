using CheeseBurger.Model.Entities;
using CheeseBurger.Repository;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger
{
    public class SyncRevenueModel : PageModel
    {
        private readonly IRevenueService revenueService;
        public List<Revenue> List_Revenue { get; set; }
        public SyncRevenueModel(IRevenueService revenueService)
        {
            this.revenueService = revenueService;
        }
        public void OnGet()
        {
            List_Revenue = revenueService.GetAllRevenues();
        }
    }
}
