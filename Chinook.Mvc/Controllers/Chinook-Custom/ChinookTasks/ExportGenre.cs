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
                    TaskViewModel viewModel =
                        new TaskViewModel("ChinookTasks", "ExportGenre", ChinookApplicationResources.TaskExportGenre);

                    return View("Task", viewModel);
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
        public ActionResult ExportGenre(TaskViewModel viewModel)
        {
            viewModel.OperationResult.Clear();

            try
            {
                if (IsTask("ExportGenre", viewModel.OperationResult))
                {
                    if (IsValid(viewModel.OperationResult, viewModel))
                    {
                        string fileDirectory = Server.MapPath(ConfigurationHelper.AppSettings<string>("Directory.Export"));
                        string filePath;

                        if (Application.ExportGenreXLSX(viewModel.OperationResult, fileDirectory, out filePath))
                        {
                            byte[] file = System.IO.File.ReadAllBytes(filePath);
                            return File(file, LibraryHelper.GetContentType(ZFileTypes.ftXLSX), Path.GetFileName(filePath));
                        }
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