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
                    TaskSimpleModel simpleModel =
                        new TaskSimpleModel("ChinookTasks", "Simple", ChinookPresentationResources.TaskSimple,
                            false, null, 123.45, null, "ABC");

                    return View(simpleModel);
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
        public ActionResult Simple(TaskSimpleModel taskSimpleModel)
        {
            taskSimpleModel.OperationResult.Clear();

            try
            {
                if (IsTask("Simple", taskSimpleModel.OperationResult))
                {
                    if (IsValid(taskSimpleModel.OperationResult, ""))
                    {
                        if (taskSimpleModel.XBoolean)
                        {
                            throw new Exception("My exception");
                        }

                        taskSimpleModel.OperationResult.InformationCode = "0";
                        taskSimpleModel.OperationResult.InformationMessage = "My status message";
                    }
                }
            }
            catch (Exception exception)
            {
                taskSimpleModel.OperationResult.ErrorCode = "0";
                taskSimpleModel.OperationResult.ErrorMessage = "My error message";

                taskSimpleModel.OperationResult.ParseException(exception);
            }
            finally
            {
            }

            return View(taskSimpleModel);
        }
    }
}