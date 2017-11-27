using Chinook.Application;
using Chinook.Data;
using Chinook.Data.Resources;
using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library.Syncfusion;
using EasyLOB.Mvc;
using Newtonsoft.Json;
using Syncfusion.JavaScript;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Chinook.Mvc
{
    public partial class InvoiceController : BaseMvcControllerSCRUDApplication<InvoiceDTO, Invoice>
    {
        #region Methods

        public InvoiceController(IChinookGenericApplicationDTO<InvoiceDTO, Invoice> application)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Invoice
        // GET: Invoice/Index
        [HttpGet]
        public ActionResult Index(int? masterCustomerId = null)
        {
            InvoiceCollectionModel invoiceCollectionModel = new InvoiceCollectionModel(ActivityOperations, "Index", null, masterCustomerId);

            try
            {
                if (IsIndex(invoiceCollectionModel.OperationResult))
                {
                    return View(invoiceCollectionModel);
                }
            }
            catch (Exception exception)
            {
                invoiceCollectionModel.OperationResult.ParseException(exception);
            }

            return View("OperationResult", new OperationResultViewModel(invoiceCollectionModel.OperationResult));
        }        

        // GET & POST: Invoice/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, int? masterCustomerId = null)
        {
            InvoiceCollectionModel invoiceCollectionModel = new InvoiceCollectionModel(ActivityOperations, "Search", masterControllerAction, masterCustomerId);

            try
            {
                if (IsOperation(invoiceCollectionModel.OperationResult))
                {
                    return PartialView(invoiceCollectionModel);
                }
            }
            catch (Exception exception)
            {
                invoiceCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(invoiceCollectionModel.OperationResult);
        }

        // GET & POST: Invoice/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return PartialView("_InvoiceLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Invoice/Create
        [HttpGet]
        public ActionResult Create(int? masterCustomerId = null)
        {
            InvoiceItemModel invoiceItemModel = new InvoiceItemModel(ActivityOperations, "Create", masterCustomerId);

            try
            {
                if (IsCreate(invoiceItemModel.OperationResult))
                {
                    return PartialView("CRUD", invoiceItemModel);
                }            
            }
            catch (Exception exception)
            {
                invoiceItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(invoiceItemModel.OperationResult);
        }

        // POST: Invoice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceItemModel invoiceItemModel)
        {
            try
            {
                if (IsCreate(invoiceItemModel.OperationResult))
                {
                    if (IsValid(invoiceItemModel.OperationResult, invoiceItemModel.Invoice))
                    {
                        InvoiceDTO invoiceDTO = (InvoiceDTO)invoiceItemModel.Invoice.ToDTO();
                        if (Application.Create(invoiceItemModel.OperationResult, invoiceDTO))
                        {
                            if (invoiceItemModel.IsSave)
                            {
                                invoiceItemModel.OperationResult.StatusMessage =
                                    EasyLOB.Resources.PresentationResources.CreateToUpdate;
                                return JsonResultSuccess(invoiceItemModel.OperationResult,
                                    Url.Action("Update", "Invoice", new { InvoiceId = invoiceDTO.InvoiceId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(invoiceItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                invoiceItemModel.OperationResult.ParseException(exception);
            }

            invoiceItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(invoiceItemModel.OperationResult);
        }

        // GET: Invoice/Read/1
        [HttpGet]
        public ActionResult Read(int invoiceId, int? masterCustomerId = null)
        {
            InvoiceItemModel invoiceItemModel = new InvoiceItemModel(ActivityOperations, "Read", masterCustomerId);
            
            try
            {
                if (IsRead(invoiceItemModel.OperationResult))
                {
                    InvoiceDTO invoiceDTO = Application.GetById(invoiceItemModel.OperationResult, new object[] { invoiceId });
                    if (invoiceDTO != null)
                    {
                        invoiceItemModel.Invoice = new InvoiceViewModel(invoiceDTO);                    

                        return PartialView("CRUD", invoiceItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                invoiceItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(invoiceItemModel.OperationResult);
        }

        // GET: Invoice/Update/1
        [HttpGet]
        public ActionResult Update(int invoiceId, int? masterCustomerId = null)
        {
            InvoiceItemModel invoiceItemModel = new InvoiceItemModel(ActivityOperations, "Update", masterCustomerId);
            
            try
            {
                if (IsUpdate(invoiceItemModel.OperationResult))
                {            
                    InvoiceDTO invoiceDTO = Application.GetById(invoiceItemModel.OperationResult, new object[] { invoiceId });
                    if (invoiceDTO != null)
                    {
                        invoiceItemModel.Invoice = new InvoiceViewModel(invoiceDTO);

                        return PartialView("CRUD", invoiceItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                invoiceItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(invoiceItemModel.OperationResult);
        }

        // POST: Invoice/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(InvoiceItemModel invoiceItemModel)
        {
            try
            {
                if (IsUpdate(invoiceItemModel.OperationResult))
                {
                    if (IsValid(invoiceItemModel.OperationResult, invoiceItemModel.Invoice))
                    {
                        InvoiceDTO invoiceDTO = (InvoiceDTO)invoiceItemModel.Invoice.ToDTO();
                        if (Application.Update(invoiceItemModel.OperationResult, invoiceDTO))
                        {
                            if (invoiceItemModel.IsSave)
                            {
                                return JsonResultSuccess(invoiceItemModel.OperationResult,
                                    Url.Action("Update", "Invoice", new { InvoiceId = invoiceDTO.InvoiceId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(invoiceItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                invoiceItemModel.OperationResult.ParseException(exception);
            }

            invoiceItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(invoiceItemModel.OperationResult);
        }

        // GET: Invoice/Delete/1
        [HttpGet]
        public ActionResult Delete(int invoiceId, int? masterCustomerId = null)
        {
            InvoiceItemModel invoiceItemModel = new InvoiceItemModel(ActivityOperations, "Delete", masterCustomerId);
            
            try
            {
                if (IsDelete(invoiceItemModel.OperationResult))
                {            
                    InvoiceDTO invoiceDTO = Application.GetById(invoiceItemModel.OperationResult, new object[] { invoiceId });
                    if (invoiceDTO != null)
                    {
                        invoiceItemModel.Invoice = new InvoiceViewModel(invoiceDTO);

                        return PartialView("CRUD", invoiceItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                invoiceItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(invoiceItemModel.OperationResult);
        }

        // POST: Invoice/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(InvoiceItemModel invoiceItemModel)
        {
            try
            {
                if (IsDelete(invoiceItemModel.OperationResult))
                {
                    if (Application.Delete(invoiceItemModel.OperationResult, (InvoiceDTO)invoiceItemModel.Invoice.ToDTO()))
                    {
                        return JsonResultSuccess(invoiceItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                invoiceItemModel.OperationResult.ParseException(exception);
            }

            invoiceItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(invoiceItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Invoice/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult();
            dataResult.result = new List<InvoiceViewModel>();

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Invoice), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewHelper<InvoiceViewModel, InvoiceDTO, Invoice>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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
                throw new InvalidOperationException(operationResult.Text);
            }

            return Json(JsonConvert.SerializeObject(dataResult), JsonRequestBehavior.AllowGet);
        } 

        // POST: Invoice/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, InvoiceResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Invoice/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, InvoiceResources.EntitySingular + ".pdf");
            }
        }

        // POST: Invoice/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, InvoiceResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}