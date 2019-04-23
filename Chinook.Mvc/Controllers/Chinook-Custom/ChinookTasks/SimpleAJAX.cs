using Chinook.Mvc.Resources;
using EasyLOB;
using System;
using System.Web.Mvc;

namespace Chinook.Mvc
{
    public partial class ChinookTasksController
    {
        // GET: Tasks/SimpleAJAX
        [HttpGet]
        public ActionResult SimpleAJAX()
        {
            try
            {
                if (IsTask("SimpleAJAX", OperationResult))
                {
                    TaskSimpleModel simpleModel =
                        new TaskSimpleModel("ChinookTasks", "SimpleAJAX", ChinookPresentationResources.TaskSimpleAJAX,
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

        // POST: Tasks/SimpleAJAX
        [HttpPost]
        public ActionResult SimpleAJAX(TaskSimpleModel taskSimpleModel)
        {
            taskSimpleModel.OperationResult.Clear();

            try
            {
                if (IsTask("SimpleAJAX", taskSimpleModel.OperationResult))
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

            return JsonResultOperationResult(taskSimpleModel.OperationResult);
        }
    }
}