using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zi.Entity;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Zi.Server
{
    public class BaseController : Controller
    {
        protected new User User { get; set; }
        protected string Token { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = Request.Headers["Token"];

            var descriptor = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
            var tokenAttr = descriptor.MethodInfo.CustomAttributes.FirstOrDefault(f => f.AttributeType.FullName == "Zi.Server.TokenRequired");
            if (tokenAttr != null)
            {
                if (token.Count == 0)
                    context.Result = StatusCode((int)HttpStatusCode.Unauthorized);
                var login = HttpContext.Session.GetString(token);
                if (login != null)
                {
                    Token = token;
                    User = new User { Login = login };
                    base.OnActionExecuting(context);
                }
                else
                    context.Result = StatusCode((int)HttpStatusCode.Forbidden);
            }
            else
                base.OnActionExecuting(context);
        }
    }
}
