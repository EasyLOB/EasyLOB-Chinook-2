using Chinook.Application.Resources;
using EasyLOB;
using EasyLOB.Library;
using EasyLOB.Mvc;
using System;
using System.Web.Mvc;

namespace Chinook.Mvc
{
    public partial class ChinookTasksController
    {
        // GET: Tasks/ExportAlbumByArtist
        [HttpGet]
        public ActionResult ExportAlbumByArtist()
        {
            try
            {
                if (IsTask("ExportAlbumByArtist", OperationResult))
                {
                    TaskModel taskModel =
                        new TaskModel("ChinookTasks", "ExportAlbumByArtist", ChinookApplicationResources.TaskExportAlbumByArtist);

                    return View("ExportAlbumByArtist", taskModel);
                }
            }
            catch (Exception exception)
            {
                OperationResult.ParseException(exception);
            }

            return View("OperationResult", new OperationResultModel(OperationResult));
        }

        // POST: Tasks/ExportAlbumByArtist
        [HttpPost]
        public ActionResult ExportAlbumByArtist(TaskModel taskModel)
        {
            taskModel.OperationResult.Clear();

            try
            {
                if (IsTask("ExportAlbumByArtist", taskModel.OperationResult))
                {
                    if (IsValid(taskModel.OperationResult, taskModel))
                    {
                        string templateDirectory = Server.MapPath(ConfigurationHelper.AppSettings<string>("Directory.Template"));
                        string fileDirectory = Server.MapPath(ConfigurationHelper.AppSettings<string>("Directory.Export"));
                        string filePath;

                        if (Application.ExportAlbumByArtistXLSX(taskModel.OperationResult, templateDirectory, fileDirectory, out filePath))
                        {
                            return JsonResultSuccess(filePath);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                taskModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(taskModel.OperationResult);
        }
    }
}