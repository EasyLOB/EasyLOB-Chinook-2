using Chinook.Application;
using Chinook.Data;
using EasyLOB;
using System;
using System.IO;
using System.Reflection;

namespace Chinook.Service
{
    public partial class ChinookServiceHelper
    {
        #region Methods

        public static string ExportGenreTXT()
        {
            LogManager.Trace(GetLog("Export Genre TXT", "Start"));

            string filePath = "";

            try
            {
                string exePath = Assembly.GetExecutingAssembly().Location;
                FileSystemInfo exeFileInfo = new FileInfo(exePath);
                string fileDirectory = Path.Combine(Path.GetDirectoryName(exePath), ConfigurationHelper.AppSettings<string>("DirectoryExport"));

                ZOperationResult operationResult = new ZOperationResult();
                IChinookApplication application = DIHelper.GetService<IChinookApplication>();
                IChinookGenericApplication<Genre> genreApplication = DIHelper.GetService<IChinookGenericApplication<Genre>>();

                // Clean Z-Export

                application.Clean(operationResult, fileDirectory);

                // Text File

                LogManager.Trace(GetLog("Export Genre", "Text File"));

                if (!application.ExportGenreTXT(operationResult, fileDirectory, genreApplication,
                    out filePath))
                {
                    LogManager.OperationResult(new ZOperationResultLog("", "", "", operationResult));
                }
            }
            catch (Exception exception)
            {
                LogManager.Exception(exception, "");
            }

            LogManager.Trace(GetLog("Export Genre", "Stop"));

            return filePath;
        }

        #endregion Methods
    }
}