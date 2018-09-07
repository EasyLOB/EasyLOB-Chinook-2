using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace EasyLOB
{
    public class EasyLOBMyLOBProfileAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}