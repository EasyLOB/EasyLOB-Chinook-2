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
    public partial class MediaTypeController : BaseMvcControllerSCRUDApplication<MediaTypeDTO, MediaType>
    {
        #region Methods

        public MediaTypeController(IChinookGenericApplicationDTO<MediaTypeDTO, MediaType> application)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: MediaType
        // GET: MediaType/Index
        [HttpGet]
        public ActionResult Index()
        {
            MediaTypeCollectionModel mediaTypeCollectionModel = new MediaTypeCollectionModel(ActivityOperations, "Index", null);

            try
            {
                if (IsIndex(mediaTypeCollectionModel.OperationResult))
                {
                    return View(mediaTypeCollectionModel);
                }
            }
            catch (Exception exception)
            {
                mediaTypeCollectionModel.OperationResult.ParseException(exception);
            }

            return View("OperationResult", new OperationResultViewModel(mediaTypeCollectionModel.OperationResult));
        }        

        // GET & POST: MediaType/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null)
        {
            MediaTypeCollectionModel mediaTypeCollectionModel = new MediaTypeCollectionModel(ActivityOperations, "Search", masterControllerAction);

            try
            {
                if (IsOperation(mediaTypeCollectionModel.OperationResult))
                {
                    return PartialView(mediaTypeCollectionModel);
                }
            }
            catch (Exception exception)
            {
                mediaTypeCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(mediaTypeCollectionModel.OperationResult);
        }

        // GET & POST: MediaType/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return PartialView("_MediaTypeLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: MediaType/Create
        [HttpGet]
        public ActionResult Create()
        {
            MediaTypeItemModel mediaTypeItemModel = new MediaTypeItemModel(ActivityOperations, "Create");

            try
            {
                if (IsCreate(mediaTypeItemModel.OperationResult))
                {
                    return PartialView("CRUD", mediaTypeItemModel);
                }            
            }
            catch (Exception exception)
            {
                mediaTypeItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(mediaTypeItemModel.OperationResult);
        }

        // POST: MediaType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MediaTypeItemModel mediaTypeItemModel)
        {
            try
            {
                if (IsCreate(mediaTypeItemModel.OperationResult))
                {
                    if (IsValid(mediaTypeItemModel.OperationResult, mediaTypeItemModel.MediaType))
                    {
                        MediaTypeDTO mediaTypeDTO = (MediaTypeDTO)mediaTypeItemModel.MediaType.ToDTO();
                        if (Application.Create(mediaTypeItemModel.OperationResult, mediaTypeDTO))
                        {
                            if (mediaTypeItemModel.IsSave)
                            {
                                mediaTypeItemModel.OperationResult.StatusMessage =
                                    EasyLOB.Resources.PresentationResources.CreateToUpdate;
                                return JsonResultSuccess(mediaTypeItemModel.OperationResult,
                                    Url.Action("Update", "MediaType", new { MediaTypeId = mediaTypeDTO.MediaTypeId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(mediaTypeItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                mediaTypeItemModel.OperationResult.ParseException(exception);
            }

            mediaTypeItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(mediaTypeItemModel.OperationResult);
        }

        // GET: MediaType/Read/1
        [HttpGet]
        public ActionResult Read(int mediaTypeId)
        {
            MediaTypeItemModel mediaTypeItemModel = new MediaTypeItemModel(ActivityOperations, "Read");
            
            try
            {
                if (IsRead(mediaTypeItemModel.OperationResult))
                {
                    MediaTypeDTO mediaTypeDTO = Application.GetById(mediaTypeItemModel.OperationResult, new object[] { mediaTypeId });
                    if (mediaTypeDTO != null)
                    {
                        mediaTypeItemModel.MediaType = new MediaTypeViewModel(mediaTypeDTO);                    

                        return PartialView("CRUD", mediaTypeItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                mediaTypeItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(mediaTypeItemModel.OperationResult);
        }

        // GET: MediaType/Update/1
        [HttpGet]
        public ActionResult Update(int mediaTypeId)
        {
            MediaTypeItemModel mediaTypeItemModel = new MediaTypeItemModel(ActivityOperations, "Update");
            
            try
            {
                if (IsUpdate(mediaTypeItemModel.OperationResult))
                {            
                    MediaTypeDTO mediaTypeDTO = Application.GetById(mediaTypeItemModel.OperationResult, new object[] { mediaTypeId });
                    if (mediaTypeDTO != null)
                    {
                        mediaTypeItemModel.MediaType = new MediaTypeViewModel(mediaTypeDTO);

                        return PartialView("CRUD", mediaTypeItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                mediaTypeItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(mediaTypeItemModel.OperationResult);
        }

        // POST: MediaType/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MediaTypeItemModel mediaTypeItemModel)
        {
            try
            {
                if (IsUpdate(mediaTypeItemModel.OperationResult))
                {
                    if (IsValid(mediaTypeItemModel.OperationResult, mediaTypeItemModel.MediaType))
                    {
                        MediaTypeDTO mediaTypeDTO = (MediaTypeDTO)mediaTypeItemModel.MediaType.ToDTO();
                        if (Application.Update(mediaTypeItemModel.OperationResult, mediaTypeDTO))
                        {
                            if (mediaTypeItemModel.IsSave)
                            {
                                return JsonResultSuccess(mediaTypeItemModel.OperationResult,
                                    Url.Action("Update", "MediaType", new { MediaTypeId = mediaTypeDTO.MediaTypeId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(mediaTypeItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                mediaTypeItemModel.OperationResult.ParseException(exception);
            }

            mediaTypeItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(mediaTypeItemModel.OperationResult);
        }

        // GET: MediaType/Delete/1
        [HttpGet]
        public ActionResult Delete(int mediaTypeId)
        {
            MediaTypeItemModel mediaTypeItemModel = new MediaTypeItemModel(ActivityOperations, "Delete");
            
            try
            {
                if (IsDelete(mediaTypeItemModel.OperationResult))
                {            
                    MediaTypeDTO mediaTypeDTO = Application.GetById(mediaTypeItemModel.OperationResult, new object[] { mediaTypeId });
                    if (mediaTypeDTO != null)
                    {
                        mediaTypeItemModel.MediaType = new MediaTypeViewModel(mediaTypeDTO);

                        return PartialView("CRUD", mediaTypeItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                mediaTypeItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(mediaTypeItemModel.OperationResult);
        }

        // POST: MediaType/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MediaTypeItemModel mediaTypeItemModel)
        {
            try
            {
                if (IsDelete(mediaTypeItemModel.OperationResult))
                {
                    if (Application.Delete(mediaTypeItemModel.OperationResult, (MediaTypeDTO)mediaTypeItemModel.MediaType.ToDTO()))
                    {
                        return JsonResultSuccess(mediaTypeItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                mediaTypeItemModel.OperationResult.ParseException(exception);
            }

            mediaTypeItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(mediaTypeItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: MediaType/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult();
            dataResult.result = new List<MediaTypeViewModel>();

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(MediaType), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewHelper<MediaTypeViewModel, MediaTypeDTO, MediaType>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: MediaType/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, MediaTypeResources.EntitySingular + ".xlsx");
            }
        }

        // POST: MediaType/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, MediaTypeResources.EntitySingular + ".pdf");
            }
        }

        // POST: MediaType/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, MediaTypeResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}