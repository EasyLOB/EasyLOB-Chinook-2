using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace EasyLOB.Mvc
{
    public class ChinookProfileAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}