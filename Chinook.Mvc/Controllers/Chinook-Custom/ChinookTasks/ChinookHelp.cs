using System.Web.Mvc;

namespace Chinook.Mvc
{
    public partial class ChinookTasksController
    {
        #region Methods

        // GET: ChinookTasks/ChinookHelp
        [HttpGet]
        public ActionResult ChinookHelp()
        {
            return View();
        }

        #endregion Methods
    }
}