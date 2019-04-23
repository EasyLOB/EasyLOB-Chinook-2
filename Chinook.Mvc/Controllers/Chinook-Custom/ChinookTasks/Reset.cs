using Chinook.Application.Resources;
using Chinook.Persistence;
using EasyLOB;
using EasyLOB.Mvc;
using System;
using System.Web.Mvc;

namespace Chinook.Mvc
{
    public partial class ChinookTasksController
    {
        // GET: Tasks/Reset
        [HttpGet]
        public ActionResult Reset()
        {
            try
            {
                if (IsTask("Reset", OperationResult))
                {
                    TaskModel taskModel =
                        new TaskModel("ChinookTasks", "Reset", ChinookApplicationResources.TaskReset);

                    return View("Task", taskModel);
                }
            }
            catch (Exception exception)
            {
                OperationResult.ParseException(exception);
            }

            return View("OperationResult", new OperationResultModel(OperationResult));
        }

        // POST: Tasks/Reset
        [HttpPost]
        public ActionResult Reset(TaskModel taskModel)
        {
            taskModel.OperationResult.Clear();

            try
            {
                if (IsTask("Reset", taskModel.OperationResult))
                {
                    if (IsValid(taskModel.OperationResult, ""))
                    {
                        IChinookUnitOfWork unitOfWork = DependencyResolver.Current.GetService<IChinookUnitOfWork>();
                        Application.Reset(taskModel.OperationResult, unitOfWork);

                        taskModel.OperationResult.InformationMessage = ChinookApplicationResources.TaskReset + " Ok";
                    }
                }
            }
            catch (Exception exception)
            {
                taskModel.OperationResult.ParseException(exception);
            }

            return View("Task", taskModel);
        }
    }
}