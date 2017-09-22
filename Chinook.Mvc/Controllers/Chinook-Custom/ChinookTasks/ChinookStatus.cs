using EasyLOB.Library.Web;
using EasyLOB.Mvc;
using Chinook.Mvc.Resources;
using System.Text;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Chinook.Mvc
{
    public partial class ChinookTasksController
    {
        #region Methods

        // GET: ChinookTasks/ChinookStatus
        [HttpGet]
        public ActionResult ChinookStatus()
        {
            StringBuilder result = new StringBuilder();

            ChinookTenant tenant = ChinookMultiTenantHelper.Tenant;
            result.Append("<br /><b>Multi-Tenant Chinook</b>");
            result.Append("<br />:: URL: " + tenant.URL);

            HttpSessionState session = SessionHelper.Session;
            result.Append("<br />");
            result.Append("<br /><b>Session</b>");
            result.Append("<br />:: SessionID: " + Session.SessionID);
            result.Append("<br />:: SessionHelper.Session.SessionID: " + session.SessionID);
            result.Append("<br />:: Key(s)");
            for (int i = 0; i < session.Contents.Count; i++)
            {
                string value = session[i].ToString();
                switch (session.Keys[i])
                {
                    case "EasyLOB.ChinookMultiTenant":
                        //value = JsonConvert.SerializeObject((List<ChinookTenant>)session[i]);
                        break;
                }

                result.Append("<br />&nbsp;&nbsp;&nbsp;" + session.Keys[i] + ": " + value);
            }

            ViewBag.Status = result.ToString();

            TaskViewModel viewModel = new TaskViewModel("ChinookTasks", "ChinookStatus", ChinookPresentationResources.TaskChinookStatus);

            return View(viewModel);
        }

        #endregion Methods
    }
}