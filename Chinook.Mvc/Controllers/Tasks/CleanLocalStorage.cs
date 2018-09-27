using EasyLOB.Resources;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class TasksController
    {
        // GET: Tasks/CleanLocalStorage
        [HttpGet]
        public ActionResult CleanLocalStorage()
        {
            //if (IsTask(OperationResult, "CleanLocalStorage"))
            //{
                TaskViewModel viewModel = new TaskViewModel("Tasks", "CleanLocalStorage", PresentationResources.TaskCleanLocalStorage);

                return View(viewModel);
            //}

            //return View("OperationResult", new OperationResultModel(OperationResult));
        }
    }
}