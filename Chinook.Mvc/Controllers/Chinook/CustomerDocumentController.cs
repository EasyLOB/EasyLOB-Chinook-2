using Chinook.Application;
using Chinook.Data;
using Chinook.Data.Resources;
using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Mvc;
using Newtonsoft.Json;
using Syncfusion.JavaScript;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Chinook.Mvc
{
    public partial class CustomerDocumentController : BaseMvcControllerSCRUDApplication<CustomerDocumentDTO, CustomerDocument>
    {
        #region Methods

        public CustomerDocumentController(IChinookGenericApplicationDTO<CustomerDocumentDTO, CustomerDocument> application)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: CustomerDocument
        // GET: CustomerDocument/Index
        [HttpGet]
        public ActionResult Index(int? masterCustomerId = null)
        {
            CustomerDocumentCollectionModel customerDocumentCollectionModel = new CustomerDocumentCollectionModel(ActivityOperations, "Index", null, masterCustomerId);

            try
            {
                if (IsIndex(customerDocumentCollectionModel.OperationResult))
                {
                    return View(customerDocumentCollectionModel);
                }
            }
            catch (Exception exception)
            {
                customerDocumentCollectionModel.OperationResult.ParseException(exception);
            }

            return View("OperationResult", new OperationResultModel(customerDocumentCollectionModel.OperationResult));
        }        

        // GET & POST: CustomerDocument/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, int? masterCustomerId = null)
        {
            CustomerDocumentCollectionModel customerDocumentCollectionModel = new CustomerDocumentCollectionModel(ActivityOperations, "Search", masterControllerAction, masterCustomerId);

            try
            {
                if (IsOperation(customerDocumentCollectionModel.OperationResult))
                {
                    return PartialView(customerDocumentCollectionModel);
                }
            }
            catch (Exception exception)
            {
                customerDocumentCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerDocumentCollectionModel.OperationResult);
        }

        // GET & POST: CustomerDocument/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return PartialView("_CustomerDocumentLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: CustomerDocument/Create
        [HttpGet]
        public ActionResult Create(int? masterCustomerId = null)
        {
            CustomerDocumentItemModel customerDocumentItemModel = new CustomerDocumentItemModel(ActivityOperations, "Create", masterCustomerId);

            try
            {
                if (IsCreate(customerDocumentItemModel.OperationResult))
                {
                    return PartialView("CRUD", customerDocumentItemModel);
                }            
            }
            catch (Exception exception)
            {
                customerDocumentItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerDocumentItemModel.OperationResult);
        }

        // POST: CustomerDocument/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(CustomerDocumentItemModel customerDocumentItemModel)
        //{
        //    try
        //    {
        //        if (IsCreate(customerDocumentItemModel.OperationResult))
        //        {
        //            if (IsValid(customerDocumentItemModel.OperationResult, customerDocumentItemModel.CustomerDocument))
        //            {
        //                CustomerDocumentDTO customerDocumentDTO = (CustomerDocumentDTO)customerDocumentItemModel.CustomerDocument.ToDTO();
        //                if (Application.Create(customerDocumentItemModel.OperationResult, customerDocumentDTO))
        //                {
        //                    if (customerDocumentItemModel.IsSave)
        //                    {
        //                        customerDocumentItemModel.OperationResult.StatusMessage =
        //                            EasyLOB.Resources.PresentationResources.CreateToUpdate;
        //                        return JsonResultSuccess(customerDocumentItemModel.OperationResult,
        //                            Url.Action("Update", "CustomerDocument", new { CustomerDocumentId = customerDocumentDTO.CustomerDocumentId }, Request.Url.Scheme));
        //                    }
        //                    else
        //                    {
        //                        return JsonResultSuccess(customerDocumentItemModel.OperationResult);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        customerDocumentItemModel.OperationResult.ParseException(exception);
        //    }

        //    customerDocumentItemModel.ActivityOperations = ActivityOperations;

        //    return JsonResultOperationResult(customerDocumentItemModel.OperationResult);
        //}

        // GET: CustomerDocument/Read/1
        [HttpGet]
        public ActionResult Read(int customerDocumentId, int? masterCustomerId = null)
        {
            CustomerDocumentItemModel customerDocumentItemModel = new CustomerDocumentItemModel(ActivityOperations, "Read", masterCustomerId);
            
            try
            {
                if (IsRead(customerDocumentItemModel.OperationResult))
                {
                    CustomerDocumentDTO customerDocumentDTO = Application.GetById(customerDocumentItemModel.OperationResult, new object[] { customerDocumentId });
                    if (customerDocumentDTO != null)
                    {
                        customerDocumentItemModel.CustomerDocument = new CustomerDocumentViewModel(customerDocumentDTO);                    

                        return PartialView("CRUD", customerDocumentItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                customerDocumentItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(customerDocumentItemModel.OperationResult);
        }

        // GET: CustomerDocument/Update/1
        [HttpGet]
        public ActionResult Update(int customerDocumentId, int? masterCustomerId = null)
        {
            CustomerDocumentItemModel customerDocumentItemModel = new CustomerDocumentItemModel(ActivityOperations, "Update", masterCustomerId);
            
            try
            {
                if (IsUpdate(customerDocumentItemModel.OperationResult))
                {            
                    CustomerDocumentDTO customerDocumentDTO = Application.GetById(customerDocumentItemModel.OperationResult, new object[] { customerDocumentId });
                    if (customerDocumentDTO != null)
                    {
                        customerDocumentItemModel.CustomerDocument = new CustomerDocumentViewModel(customerDocumentDTO);

                        return PartialView("CRUD", customerDocumentItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                customerDocumentItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerDocumentItemModel.OperationResult);
        }

        // POST: CustomerDocument/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CustomerDocumentItemModel customerDocumentItemModel)
        {
            try
            {
                if (IsUpdate(customerDocumentItemModel.OperationResult))
                {
                    if (IsValid(customerDocumentItemModel.OperationResult, customerDocumentItemModel.CustomerDocument))
                    {
                        CustomerDocumentDTO customerDocumentDTO = (CustomerDocumentDTO)customerDocumentItemModel.CustomerDocument.ToDTO();
                        if (Application.Update(customerDocumentItemModel.OperationResult, customerDocumentDTO))
                        {
                            if (customerDocumentItemModel.IsSave)
                            {
                                return JsonResultSuccess(customerDocumentItemModel.OperationResult,
                                    Url.Action("Update", "CustomerDocument", new { CustomerDocumentId = customerDocumentDTO.CustomerDocumentId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(customerDocumentItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                customerDocumentItemModel.OperationResult.ParseException(exception);
            }

            customerDocumentItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(customerDocumentItemModel.OperationResult);
        }

        // GET: CustomerDocument/Delete/1
        [HttpGet]
        public ActionResult Delete(int customerDocumentId, int? masterCustomerId = null)
        {
            CustomerDocumentItemModel customerDocumentItemModel = new CustomerDocumentItemModel(ActivityOperations, "Delete", masterCustomerId);
            
            try
            {
                if (IsDelete(customerDocumentItemModel.OperationResult))
                {            
                    CustomerDocumentDTO customerDocumentDTO = Application.GetById(customerDocumentItemModel.OperationResult, new object[] { customerDocumentId });
                    if (customerDocumentDTO != null)
                    {
                        customerDocumentItemModel.CustomerDocument = new CustomerDocumentViewModel(customerDocumentDTO);

                        return PartialView("CRUD", customerDocumentItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                customerDocumentItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerDocumentItemModel.OperationResult);
        }

        // POST: CustomerDocument/Delete
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(CustomerDocumentItemModel customerDocumentItemModel)
        //{
        //    try
        //    {
        //        if (IsDelete(customerDocumentItemModel.OperationResult))
        //        {
        //            if (Application.Delete(customerDocumentItemModel.OperationResult, (CustomerDocumentDTO)customerDocumentItemModel.CustomerDocument.ToDTO()))
        //            {
        //                return JsonResultSuccess(customerDocumentItemModel.OperationResult);
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        customerDocumentItemModel.OperationResult.ParseException(exception);
        //    }

        //    customerDocumentItemModel.ActivityOperations = ActivityOperations;

        //    return JsonResultOperationResult(customerDocumentItemModel.OperationResult);
        //}
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: CustomerDocument/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult();
            dataResult.result = new List<CustomerDocumentViewModel>();

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(CustomerDocument), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewHelper<CustomerDocumentViewModel, CustomerDocumentDTO, CustomerDocument>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
                    if (dataManager.RequiresCounts)
                    {
                        dataResult.count = Application.Count(where, args.ToArray());
                    }
                }
                catch (Exception exception)
                {
                    operationResult.ParseException(exception);
                }
            }

            if (!operationResult.Ok)
            {
                throw operationResult.Exception;
            }

            return Json(JsonConvert.SerializeObject(dataResult), JsonRequestBehavior.AllowGet);
        } 

        // POST: CustomerDocument/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, CustomerDocumentResources.EntitySingular + ".xlsx");
            }
        }

        // POST: CustomerDocument/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, CustomerDocumentResources.EntitySingular + ".pdf");
            }
        }

        // POST: CustomerDocument/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, CustomerDocumentResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}