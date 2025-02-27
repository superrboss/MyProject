using First.Core.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using First.Core.DTO;

namespace First.Filters
{
    // To can Use Authorize as attribute on controller 'Classes' or on 'Methods'
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public bool IgnoreFilter { get; }
        // to make attribute take paramter (bool)
        public AuthorizeAttribute(bool ignore = false)
        {
            IgnoreFilter = ignore;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //search of all methods are used Authorize attribute
            var hasIgnoreFilter = context.ActionDescriptor.FilterDescriptors
                .Any(f => f.Filter is AuthorizeAttribute auth && auth.IgnoreFilter);
            
            if (hasIgnoreFilter) return;

            if ((context.HttpContext.Items["User"] as User) == null)
            {
                context.Result = new JsonResult(new ResponseDto
                {
                    StatusCode = (int) HttpStatusCode.Unauthorized,
                    StatusMessage = HttpStatusCode.Unauthorized.ToString(),
                    Data = null
                })

                { StatusCode = (int) HttpStatusCode.Unauthorized };
                return;
            }
        }
    }
}
