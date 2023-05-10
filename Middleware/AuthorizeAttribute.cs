using CheeseBurger.Model.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheeseBurger.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<string> _roles;

        public AuthorizeAttribute(params string[] roles)
        {
            _roles = roles ?? new string[] { };
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var role = context.HttpContext.Session.GetString("Role");
                if (_roles.Any() && !_roles.Contains(role))
                    context.HttpContext.Response.Redirect("/Error");
            }
            catch (Exception)
            {
                context.Result = new JsonResult(new { message = "Unauthorized, Not Sign Up" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
