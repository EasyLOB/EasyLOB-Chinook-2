using Chinook.Data;
using Chinook.Mvc;
using EasyLOB;
using EasyLOB.Extensions.Edm;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Chinook.Mvc
{
    public partial class CustomerDocumentController
    {
        #region Methods SCRUD

        // POST: CustomerDocument/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerDocumentItemModel CustomerDocumentItemModel) // !!! EDM
        {
            try
            {
                if (IsCreate(CustomerDocumentItemModel.OperationResult))
                {
                    if (IsValid(CustomerDocumentItemModel.OperationResult, CustomerDocumentItemModel.CustomerDocument))
                    {
                        ZFileTypes fileType = LibraryHelper.GetFileType(Path.GetExtension(CustomerDocumentItemModel.CustomerDocument.FileName));
                        string acronym = LibraryHelper.GetAcronym(fileType);
                        CustomerDocumentItemModel.CustomerDocument.FileAcronym = acronym;

                        CustomerDocumentDTO CustomerDocumentDTO = (CustomerDocumentDTO)CustomerDocumentItemModel.CustomerDocument.ToDTO();
                        if (Application.Create(CustomerDocumentItemModel.OperationResult, CustomerDocumentDTO))
                        {
                            string file = Path.GetFileName(CustomerDocumentItemModel.CustomerDocument.FileName);
                            string path = Path.Combine(Server.MapPath(ConfigurationHelper.AppSettings<string>("Directory.Import")), file);

                            IEdmManager edmManager = DependencyResolver.Current.GetService<IEdmManager>();
                            edmManager.WriteFile("CustomerDocument", CustomerDocumentDTO.CustomerDocumentId, fileType, path);

                            if (System.IO.File.Exists(path))
                            {
                                System.IO.File.Delete(path);
                            }

                            if (CustomerDocumentItemModel.IsSave)
                            {
                                CustomerDocumentItemModel.OperationResult.StatusMessage =
                                    EasyLOB.Resources.PresentationResources.CreateToUpdate;
                                return JsonResultSuccess(CustomerDocumentItemModel.OperationResult,
                                    Url.Action("Update", "CustomerDocument", new { Id = CustomerDocumentDTO.CustomerDocumentId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(CustomerDocumentItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                CustomerDocumentItemModel.OperationResult.ParseException(exception);
            }

            CustomerDocumentItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(CustomerDocumentItemModel.OperationResult);
        }

        // POST: CustomerDocument/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomerDocumentItemModel CustomerDocumentItemModel) // !!! EDM
        {
            try
            {
                if (IsDelete(CustomerDocumentItemModel.OperationResult))
                {
                    if (Application.Delete(CustomerDocumentItemModel.OperationResult, (CustomerDocumentDTO)CustomerDocumentItemModel.CustomerDocument.ToDTO()))
                    {
                        IEdmManager edmManager = DependencyResolver.Current.GetService<IEdmManager>();
                        int id = CustomerDocumentItemModel.CustomerDocument.CustomerDocumentId;
                        ZFileTypes fileType = LibraryHelper.GetFileType(CustomerDocumentItemModel.CustomerDocument.FileAcronym);
                        edmManager.DeleteFile("CustomerDocument", id, fileType);

                        return JsonResultSuccess(CustomerDocumentItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                CustomerDocumentItemModel.OperationResult.ParseException(exception);
            }

            CustomerDocumentItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(CustomerDocumentItemModel.OperationResult);
        }

        #endregion Methods SCRUD

        #region Methods EDM

        public ActionResult WriteFile(IEnumerable<HttpPostedFileBase> UploadBox_CustomerDocument) // !!! EDM
        {
            foreach (var postedFile in UploadBox_CustomerDocument)
            {
                string file = Path.GetFileName(postedFile.FileName);
                string path = Path.Combine(Server.MapPath(ConfigurationHelper.AppSettings<string>("Directory.Import")), file);
                postedFile.SaveAs(path);
            }

            return Content("");
        }

        public ActionResult DeleteFile(string[] fileNames) // !!! EDM
        {
            foreach (var fileName in fileNames)
            {
                string file = Path.GetFileName(fileName);
                var path = Path.Combine(Server.MapPath(ConfigurationHelper.AppSettings<string>("Directory.Import")), file);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }

            return Content("");
        }

        #endregion Methods EDM
    }
}