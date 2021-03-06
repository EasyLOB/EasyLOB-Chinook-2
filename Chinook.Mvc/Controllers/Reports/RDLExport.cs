﻿using EasyLOB.Library;
using System.Collections.Generic;
using System;
using System.IO;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class ReportsController : BaseMvcControllerReport
    {
        [HttpGet]
        public ActionResult RDLExport(string exportFormat, string reportDirectory, string reportName)
        {
            OperationResultModel operationResultModel = new OperationResultModel();

            string exportPath = Path.Combine(Server.MapPath(ConfigurationHelper.AppSettings<string>("Directory.Export")),
                reportName + String.Format(".{0:yyyyMMdd.HHmmss.fff}", DateTime.Now));

            IDictionary<string, string> reportParameters = new Dictionary<string, string>();
            if (System.Web.HttpContext.Current.Request.QueryString.Count > 3)
            {
                for (int q = 3; q < System.Web.HttpContext.Current.Request.QueryString.Count; q++)
                {
                    reportParameters.Add(System.Web.HttpContext.Current.Request.QueryString.AllKeys[q],
                        System.Web.HttpContext.Current.Request.QueryString[q]);
                }
            }

            if (SyncfusionHelper.ExportRDL(operationResultModel.OperationResult, ref exportPath, exportFormat,
                reportDirectory, reportName, reportParameters))
            {
                byte[] file = System.IO.File.ReadAllBytes(exportPath);
                return File(file,
                    LibraryHelper.GetContentType(LibraryHelper.GetFileType(Path.GetExtension(exportPath))),
                    Path.GetFileName(exportPath));
            }

            return View("OperationResult", operationResultModel);
        }
    }
}