using CheeseBurger.Pages;
using Microsoft.AspNetCore.Mvc;

namespace CheeseBurger.Service
{
    public interface IViewRenderService
    {
		Task<string> RenderViewToStringAsync(string viewName, object model);

		Task<string> RenderEmailBody(string viewName, object model);

	}
}
