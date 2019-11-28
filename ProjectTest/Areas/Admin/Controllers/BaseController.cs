using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace ProjectTest.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public bool needToRedirect = true;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (needToRedirect)
            {

                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
                return;
            }
           
        }
    }
}