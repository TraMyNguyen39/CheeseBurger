using CheeseBurger.DTO;
using CheeseBurger.Middleware;
using CheeseBurger.Model.Entities;
using CheeseBurger.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Pages.Admin.ManageImport
{
    [Authorize("Quản trị viên", "Nhân viên đầu bếp")]
    public class ManageImportOrderModel : PageModel
    {
        private readonly IImportOrderService importOrderService;
        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }
        public string searchText { get; set; }
        public DateTime timeStart { get; set; } = default;
        public DateTime timeEnd { get; set; } = default;      
        public List<ImportOrderDTO> imports { get; set; }
        public ManageImportOrderModel(IImportOrderService importOrderService)
        {
            this.importOrderService = importOrderService;
        }

        public IActionResult OnGet()
        {
            searchText = Request.Query["search"];
            string fDate = Request.Query["fromDate"];
            if (searchText != null) searchText = searchText.Trim();

            if (DateTime.TryParse(fDate, out DateTime fromDateResult))
            {
                timeStart = fromDateResult;
            } else 
            {
				timeStart = default(DateTime);
			}

            string tDate = Request.Query["toDate"];
            string type = Request.Query["t"];
            if (type != "1")
            {
				if (DateTime.TryParse(tDate, out DateTime toDateResult))
				{
					TimeSpan timeSpan = new TimeSpan(23, 59, 59);
					timeEnd = toDateResult + timeSpan;
				}
				else
				{
					timeEnd = default(DateTime);
				}
			}
            else
            {
				if (DateTime.TryParse(tDate, out DateTime toDateResult))
				{
                    timeEnd = toDateResult;
				}
				else
				{
					timeEnd = default(DateTime);
				}
			}
            imports = importOrderService.GetAllImport(timeStart, timeEnd, searchText);
            return Page();
        }
    }
}
