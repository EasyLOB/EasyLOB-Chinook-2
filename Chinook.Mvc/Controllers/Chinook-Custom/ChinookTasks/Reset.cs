﻿using Chinook.Application.Resources;
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
                    TaskViewModel viewModel =
                        new TaskViewModel("ChinookTasks", "Reset", ChinookApplicationResources.TaskReset);

                    return View("Task", viewModel);
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
        public ActionResult Reset(TaskViewModel viewModel)
        {
            viewModel.OperationResult.Clear();

            try
            {
                if (IsTask("Reset", viewModel.OperationResult))
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