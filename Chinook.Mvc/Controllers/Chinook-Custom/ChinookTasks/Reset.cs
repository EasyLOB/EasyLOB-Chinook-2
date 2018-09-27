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
                if (IsTask(OperationResult, "Reset"))
                {
                    TaskViewModel viewModel =
                        new TaskViewModel("ChinookTasks", "Reset", ChinookApplicationResources.TaskReset);

                    return View("Task", viewModel);
                }
            }
            catch (Exception exception)
            {
                OperationResult.ParseException(exception);
            }

            return View("OperationResult", new OperationResultViewModel(OperationResult));
        }

        // POST: Tasks/Reset
        [HttpPost]
        public ActionResult Reset(TaskViewModel viewModel)
        {
            viewModel.OperationResult.Clear();

            try
            {
                if (IsTask(viewModel.OperationResult, "Reset"))
                {
                    if (IsValid(viewModel.OperationResult, ""))
                    {
                        IChinookUnitOfWork unitOfWork = DependencyResolver.Current.GetService<IChinookUnitOfWork>();
                        Application.Reset(viewModel.OperationResult, unitOfWork);

                        viewModel.OperationResult.StatusMessage = ChinookApplicationResources.TaskReset + " Ok";
                    }
                }
            }
            catch (Exception exception)
            {
                viewModel.OperationResult.ParseException(exception);
            }

            return View("Task", viewModel);
        }
    }
}