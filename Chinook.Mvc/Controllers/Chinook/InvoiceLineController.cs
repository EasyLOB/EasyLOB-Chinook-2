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
    public partial class InvoiceLineController : BaseMvcControllerSCRUDApplication<InvoiceLineDTO, InvoiceLine>
    {
        #region Methods

        public InvoiceLineController(IChinookGenericApplicationDTO<InvoiceLineDTO, InvoiceLine> application)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: InvoiceLine
        // GET: InvoiceLine/Index
        [HttpGet]
        public ActionResult Index(int? masterInvoiceId = null, int? masterTrackId = null)
        {
            InvoiceLineCollectionModel invoiceLineCollectionModel = new InvoiceLineCollectionModel(ActivityOperations, "Index", null, masterInvoiceId, masterTrackId);

            try
            {
                IsOperation(invoiceLineCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                invoiceLineCollectionModel.OperationResult.ParseException(exception);
            }

            return View(invoiceLineCollectionModel);
        }        

        // GET & POST: InvoiceLine/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, int? masterInvoiceId = null, int? masterTrackId = null)
        {
            InvoiceLineCollectionModel invoiceLineCollectionModel = new InvoiceLineCollectionModel(ActivityOperations, "Search", masterControllerAction, masterInvoiceId, masterTrackId);

            try
            {
                if (IsOperation(invoiceLineCollectionModel.OperationResult))
                {
                    return PartialView(invoiceLineCollectionModel);
                }
            }
            catch (Exception exception)
            {
                invoiceLineCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(invoiceLineCollectionModel.OperationResult);
        }

        // GET & POST: InvoiceLine/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return PartialView("_InvoiceLineLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: InvoiceLine/Create
        [HttpGet]
        public ActionResult Create(int? masterInvoiceId = null, int? masterTrackId = null)
        {
            InvoiceLineItemModel invoiceLineItemModel = new InvoiceLineItemModel(ActivityOperations, "Create", masterInvoiceId, masterTrackId);

            try
            {
                if (IsCreate(invoiceLineItemModel.OperationResult))
                {
                    return PartialView("CRUD", invoiceLineItemModel);
                }            
            }
            catch (Exception exception)
            {
                invoiceLineItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(invoiceLineItemModel.OperationResult);
        }

        // POST: InvoiceLine/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceLineItemModel invoiceLineItemModel)
        {
            try
            {
                if (IsCreate(invoiceLineItemModel.OperationResult))
                {
                    if (IsValid(invoiceLineItemModel.OperationResult, invoiceLineItemModel.InvoiceLine))
                    {
                        InvoiceLineDTO invoiceLineDTO = (InvoiceLineDTO)invoiceLineItemModel.InvoiceLine.ToDTO();
                        if (Application.Create(invoiceLineItemModel.OperationResult, invoiceLineDTO))
                        {
                            if (invoiceLineItemModel.IsSave)
                            {
                                invoiceLineItemModel.OperationResult.StatusMessage =
                                    EasyLOB.Resources.PresentationResources.CreateToUpdate;
                                return JsonResultSuccess(invoiceLineItemModel.OperationResult,
                                    Url.Action("Update", "InvoiceLine", new { InvoiceLineId = invoiceLineDTO.InvoiceLineId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(invoiceLineItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                invoiceLineItemModel.OperationResult.ParseException(exception);
            }

            invoiceLineItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(invoiceLineItemModel.OperationResult);
        }

        // GET: InvoiceLine/Read/1
        [HttpGet]
        public ActionResult Read(int invoiceLineId, int? masterInvoiceId = null, int? masterTrackId = null)
        {
            InvoiceLineItemModel invoiceLineItemModel = new InvoiceLineItemModel(ActivityOperations, "Read", masterInvoiceId, masterTrackId);
            
            try
            {
                if (IsRead(invoiceLineItemModel.OperationResult))
                {
                    InvoiceLineDTO invoiceLineDTO = Application.GetById(invoiceLineItemModel.OperationResult, new object[] { invoiceLineId });
                    if (invoiceLineDTO != null)
                    {
                        invoiceLineItemModel.InvoiceLine = new InvoiceLineViewModel(invoiceLineDTO);                    

                        return PartialView("CRUD", invoiceLineItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                invoiceLineItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(invoiceLineItemModel.OperationResult);
        }

        // GET: InvoiceLine/Update/1
        [HttpGet]
        public ActionResult Update(int invoiceLineId, int? masterInvoiceId = null, int? masterTrackId = null)
        {
            InvoiceLineItemModel invoiceLineItemModel = new InvoiceLineItemModel(ActivityOperations, "Update", masterInvoiceId, masterTrackId);
            
            try
            {
                if (IsUpdate(invoiceLineItemModel.OperationResult))
                {            
                    InvoiceLineDTO invoiceLineDTO = Application.GetById(invoiceLineItemModel.OperationResult, new object[] { invoiceLineId });
                    if (invoiceLineDTO != null)
                    {
                        invoiceLineItemModel.InvoiceLine = new InvoiceLineViewModel(invoiceLineDTO);

                        return PartialView("CRUD", invoiceLineItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                invoiceLineItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(invoiceLineItemModel.OperationResult);
        }

        // POST: InvoiceLine/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(InvoiceLineItemModel invoiceLineItemModel)
        {
            try
            {
                if (IsUpdate(invoiceLineItemModel.OperationResult))
                {
                    if (IsValid(invoiceLineItemModel.OperationResult, invoiceLineItemModel.InvoiceLine))
                    {
                        InvoiceLineDTO invoiceLineDTO = (InvoiceLineDTO)invoiceLineItemModel.InvoiceLine.ToDTO();
                        if (Application.Update(invoiceLineItemModel.OperationResult, invoiceLineDTO))
                        {
                            if (invoiceLineItemModel.IsSave)
                            {
                                return JsonResultSuccess(invoiceLineItemModel.OperationResult,
                                    Url.Action("Update", "InvoiceLine", new { InvoiceLineId = invoiceLineDTO.InvoiceLineId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(invoiceLineItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                invoiceLineItemModel.OperationResult.ParseException(exception);
            }

            invoiceLineItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(invoiceLineItemModel.OperationResult);
        }

        // GET: InvoiceLine/Delete/1
        [HttpGet]
        public ActionResult Delete(int invoiceLineId, int? masterInvoiceId = null, int? masterTrackId = null)
        {
            InvoiceLineItemModel invoiceLineItemModel = new InvoiceLineItemModel(ActivityOperations, "Delete", masterInvoiceId, masterTrackId);
            
            try
            {
                if (IsDelete(invoiceLineItemModel.OperationResult))
                {            
                    InvoiceLineDTO invoiceLineDTO = Application.GetById(invoiceLineItemModel.OperationResult, new object[] { invoiceLineId });
                    if (invoiceLineDTO != null)
                    {
                        invoiceLineItemModel.InvoiceLine = new InvoiceLineViewModel(invoiceLineDTO);

                        return PartialView("CRUD", invoiceLineItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                invoiceLineItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(invoiceLineItemModel.OperationResult);
        }

        // POST: InvoiceLine/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(InvoiceLineItemModel invoiceLineItemModel)
        {
            try
            {
                if (IsDelete(invoiceLineItemModel.OperationResult))
                {
                    if (Application.Delete(invoiceLineItemModel.OperationResult, (InvoiceLineDTO)invoiceLineItemModel.InvoiceLine.ToDTO()))
                    {
                        return JsonResultSuccess(invoiceLineItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                invoiceLineItemModel.OperationResult.ParseException(exception);
            }

            invoiceLineItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(invoiceLineItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: InvoiceLine/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult();
            dataResult.result = new List<InvoiceLineViewModel>();

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(InvoiceLine), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewHelper<InvoiceLineViewModel, InvoiceLineDTO, InvoiceLine>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: InvoiceLine/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, InvoiceLineResources.EntitySingular + ".xlsx");
            }
        }

        // POST: InvoiceLine/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, InvoiceLineResources.EntitySingular + ".pdf");
            }
        }

        // POST: InvoiceLine/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, InvoiceLineResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}