using System.Web.Mvc;

namespace Chinook.Mvc
{
    public partial class ChinookTasksController
    {
        #region Methods

        // GET: ChinookTasks/ChinookAPIIndex
        [HttpGet]
        public ActionResult ChinookAPIIndex()
        {
            return View();
        }

        #endregion Methods
    }
}