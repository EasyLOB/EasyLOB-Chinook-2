using EasyLOB.Library;
using EasyLOB.Library.Syncfusion;
using System;
using System.IO;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class DashboardsController : BaseMvcControllerDashboard
    {
        [HttpGet]
        public ActionResult Syncfusion(string dashboardDirectory, string dashboardName)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (String.IsNullOrEmpty(dashboardName))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (!String.IsNullOrEmpty(dashboardDirectory))
                    {
                        ViewBag.ReportPath = Path.Combine(Server.MapPath(ConfigurationHelper.AppSettings<string>("Dashboard.SyncfusionDirectory")), dashboardDirectory, dashboardName + ".sydx")
                            .Replace("\\", "\\\\");
                    }
                    else
                    {
                        ViewBag.ReportPath = Path.Combine(Server.MapPath(ConfigurationHelper.AppSettings<string>("Dashboard.SyncfusionDirectory")), dashboardName + ".sydx")
                            .Replace("\\", "\\\\");
                    }

                    DashboardViewer dashboardViewer = new DashboardViewer();
                    ViewBag.Errormessage = dashboardViewer.Errormessage;
                    string url = ConfigurationHelper.AppSettings<string>("Dashboard.SyncfusionUrl");
                    ViewBag.ServiceURL = String.IsNullOrEmpty(url) ? dashboardViewer.ServiceUrl : url;

                    return View("Syncfusion");
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
                return View("OperationResult", new OperationResultModel(operationResult));
            }
        }
    }
}