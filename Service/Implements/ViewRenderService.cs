using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using CheeseBurger.Pages;
using RazorLight;
using Microsoft.AspNetCore.Http.Extensions;

namespace CheeseBurger.Service.Implements
{
	public class ViewRenderService : IViewRenderService
	{
		private readonly ICompositeViewEngine _viewEngine;
		private readonly ITempDataProvider _tempDataProvider;
		private readonly IServiceProvider _serviceProvider;
		private readonly IWebHostEnvironment _hostingEnvironment;

		public ViewRenderService(ICompositeViewEngine viewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider, IWebHostEnvironment hostingEnvironment)
		{
			_viewEngine = viewEngine;
			_tempDataProvider = tempDataProvider;
			_serviceProvider = serviceProvider;
			_hostingEnvironment = hostingEnvironment;
		}

		public async Task<string> RenderViewToStringAsync(string viewName, object model)
		{
			var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };
			var actionContext = new ActionContext(httpContext, new Microsoft.AspNetCore.Routing.RouteData(), new ActionDescriptor());

			using (var sw = new StringWriter())
			{
				var viewResult = _viewEngine.GetView(_hostingEnvironment.ContentRootPath, viewName, false);

				if (viewResult.View == null)
				{
					throw new ArgumentNullException($"{viewName} does not exist");
				}

				var viewData = new ViewDataDictionary(new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(), new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
				{
					Model = model
				};

				var tempData = new TempDataDictionary(httpContext, _tempDataProvider);

				var viewContext = new ViewContext(
					actionContext,
					viewResult.View,
					viewData,
					tempData,
					sw,
					new HtmlHelperOptions()
				);

				await viewResult.View.RenderAsync(viewContext);

				return sw.ToString();
			}
		}

		public async Task<string> RenderEmailBody(string viewName, object model)
		{
			return await RenderViewToStringAsync(viewName, model);
		}
	}
}
