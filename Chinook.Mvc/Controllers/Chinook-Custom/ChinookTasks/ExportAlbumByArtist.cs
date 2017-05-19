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
        // GET: Tasks/ExportAlbumByArtist
        [HttpGet]
        public ActionResult ExportAlbumByArtist()
        {
            try
            {
                if (IsTask("ExportAlbumByArtist", OperationResult))
                {
                    TaskViewModel viewModel =
                        new TaskViewModel("ChinookTasks", "ExportAlbumByArtist", ChinookApplicationResources.TaskExportAlbumByArtist);

                    return View("ExportAlbumByArtist", viewModel);
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
        public ActionResult ExportAlbumByArtist(TaskViewModel viewModel)
        {
            viewModel.OperationResult.Clear();

            try
            {
                if (IsTask("ExportAlbumByArtist", viewModel.OperationResult))
                {
                    if (IsValid(viewModel.OperationResult, viewModel))
                    {
                        string templateDirectory = Server.MapPath(ConfigurationHelper.AppSettings<string>("Directory.Template"));
                        string fileDirectory = Server.MapPath(ConfigurationHelper.AppSettings<string>("Directory.Export"));
                        string filePath;

                        if (Application.ExportAlbumByArtistXLSX(viewModel.OperationResult, templateDirectory, fileDirectory, out filePath))
                        {
                            return JsonResultSuccess(filePath);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                viewModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(viewModel.OperationResult);
        }
    }
}