using Chinook.Mvc.Resources;
using EasyLOB;
using System;
using System.Web.Mvc;

namespace Chinook.Mvc
{
    public partial class ChinookTasksController
    {
        // GET: Tasks/Simple
        [HttpGet]
        public ActionResult Simple()
        {
            try
            {
                if (IsTask("Simple", OperationResult))
                {
                    TaskSimpleViewModel viewModel =
                        new TaskSimpleViewModel("ChinookTasks", "Simple", ChinookPresentationResources.TaskSimple,
                            false, null, 123.45, null, "ABC");

                    return View(viewModel);
                }
            }
            catch (Exception exception)
            {
                OperationResult.ParseException(exception);
            }

            return View("OperationResult", new OperationResultViewModel(OperationResult));
        }

        // POST: Tasks/Simple
        [HttpPost]
        public ActionResult Simple(TaskSimpleViewModel viewModel)
        {
            viewModel.OperationResult.Clear();

            try
            {
                if (IsTask("Simple", viewModel.OperationResult))
                {
                    if (IsValid(viewModel.OperationResult, ""))
                    {
                        if (viewModel.XBoolean)
                        {
                            throw new Exception("My exception");
                        }

                        viewModel.OperationResult.StatusCode = "0";
                        viewModel.OperationResult.StatusMessage = "My status message";
                    }
                }
            }
            catch (Exception exception)
            {
                viewModel.OperationResult.ErrorCode = "0";
                viewModel.OperationResult.ErrorMessage = "My error message";

                viewModel.OperationResult.ParseException(exception);
            }
            finally
            {
            }

            return View(viewModel);
        }
    }
}