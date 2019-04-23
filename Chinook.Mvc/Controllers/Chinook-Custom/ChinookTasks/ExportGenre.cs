using Chinook.Application.Resources;
using EasyLOB;
using EasyLOB.Library;
using EasyLOB.Mvc;
using System;
using System.IO;
using System.Web.Mvc;

namespace Chinook.Mvc
{
    public partial class ChinookTasksController
    {
        // GET: Tasks/ExportGenre
        [HttpGet]
        public ActionResult ExportGenre()
        {
            try
            {
                if (IsTask("ExportGenre", OperationResult))
                {
                    TaskModel taskModel =
                        new TaskModel("ChinookTasks", "ExportGenre", ChinookApplicationResources.TaskExportGenre);

                    return View("Task", taskModel);
                }
            }
            catch (Exception exception)
            {
                OperationResult.ParseException(exception);
            }

            return View("OperationResult", new OperationResultViewModel(OperationResult));
        }

        // POST: Tasks/ExportGenre
        [HttpPost]
        public ActionResult ExportGenre(TaskModel taskModel)
        {
            taskModel.OperationResult.Clear();

            try
            {
                if (IsTask("ExportGenre", taskModel.OperationResult))
                {
                    if (IsValid(taskModel.OperationResult, taskModel))
                    {
                        string fileDirectory = Server.MapPath(ConfigurationHelper.AppSettings<string>("Directory.Export"));
                        string filePath;

                        if (Application.ExportGenreXLSX(taskModel.OperationResult, fileDirectory, out filePath))
                        {
                            byte[] file = System.IO.File.ReadAllBytes(filePath);
                            return File(file, LibraryHelper.GetContentType(ZFileTypes.ftXLSX), Path.GetFileName(filePath));
                        }
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