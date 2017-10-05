using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zi.Entity;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Zi.Server
{
    public class BaseController : Controller
    {
        protected User User { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = Request.Headers["Token"];

            //var filters = new List<FilterAttribute>();
            //filters.AddRange(filterContext.ActionDescriptor.GetFilterAttributes(false));
            //filters.AddRange(filterContext.ActionDescriptor.ControllerDescriptor.GetFilterAttributes(false));
            //var roles = filters.OfType<AuthorizeAttribute>().Select(f => f.Roles);

           var ttt = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
            var ee = ttt.MethodInfo.CustomAttributes;
            var yyy = ee.ToArray()[0].AttributeType.FullName;
            var yyy2 = ee.ToArray()[1].AttributeType.FullName;


            if (string.IsNullOrEmpty(token))
                context.Result = StatusCode((int)HttpStatusCode.Unauthorized);

            base.OnActionExecuting(context);
        }
    }
}
