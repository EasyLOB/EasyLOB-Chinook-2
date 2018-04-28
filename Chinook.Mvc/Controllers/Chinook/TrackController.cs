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
    public partial class TrackController : BaseMvcControllerSCRUDApplication<TrackDTO, Track>
    {
        #region Methods

        public TrackController(IChinookGenericApplicationDTO<TrackDTO, Track> application)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Track
        // GET: Track/Index
        [HttpGet]
        public ActionResult Index(int? masterAlbumId = null, int? masterGenreId = null, int? masterMediaTypeId = null)
        {
            TrackCollectionModel trackCollectionModel = new TrackCollectionModel(ActivityOperations, "Index", null, masterAlbumId, masterGenreId, masterMediaTypeId);

            try
            {
                if (IsIndex(trackCollectionModel.OperationResult))
                {
                    return View(trackCollectionModel);
                }
            }
            catch (Exception exception)
            {
                trackCollectionModel.OperationResult.ParseException(exception);
            }

            return View("OperationResult", new OperationResultViewModel(trackCollectionModel.OperationResult));
        }        

        // GET & POST: Track/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, int? masterAlbumId = null, int? masterGenreId = null, int? masterMediaTypeId = null)
        {
            TrackCollectionModel trackCollectionModel = new TrackCollectionModel(ActivityOperations, "Search", masterControllerAction, masterAlbumId, masterGenreId, masterMediaTypeId);

            try
            {
                if (IsOperation(trackCollectionModel.OperationResult))
                {
                    return PartialView(trackCollectionModel);
                }
            }
            catch (Exception exception)
            {
                trackCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(trackCollectionModel.OperationResult);
        }

        // GET & POST: Track/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return PartialView("_TrackLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Track/Create
        [HttpGet]
        public ActionResult Create(int? masterAlbumId = null, int? masterGenreId = null, int? masterMediaTypeId = null)
        {
            TrackItemModel trackItemModel = new TrackItemModel(ActivityOperations, "Create", masterAlbumId, masterGenreId, masterMediaTypeId);

            try
            {
                if (IsCreate(trackItemModel.OperationResult))
                {
                    return PartialView("CRUD", trackItemModel);
                }            
            }
            catch (Exception exception)
            {
                trackItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(trackItemModel.OperationResult);
        }

        // POST: Track/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrackItemModel trackItemModel)
        {
            try
            {
                if (IsCreate(trackItemModel.OperationResult))
                {
                    if (IsValid(trackItemModel.OperationResult, trackItemModel.Track))
                    {
                        TrackDTO trackDTO = (TrackDTO)trackItemModel.Track.ToDTO();
                        if (Application.Create(trackItemModel.OperationResult, trackDTO))
                        {
                            if (trackItemModel.IsSave)
                            {
                                trackItemModel.OperationResult.StatusMessage =
                                    EasyLOB.Resources.PresentationResources.CreateToUpdate;
                                return JsonResultSuccess(trackItemModel.OperationResult,
                                    Url.Action("Update", "Track", new { TrackId = trackDTO.TrackId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(trackItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                trackItemModel.OperationResult.ParseException(exception);
            }

            trackItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(trackItemModel.OperationResult);
        }

        // GET: Track/Read/1
        [HttpGet]
        public ActionResult Read(int trackId, int? masterAlbumId = null, int? masterGenreId = null, int? masterMediaTypeId = null)
        {
            TrackItemModel trackItemModel = new TrackItemModel(ActivityOperations, "Read", masterAlbumId, masterGenreId, masterMediaTypeId);
            
            try
            {
                if (IsRead(trackItemModel.OperationResult))
                {
                    TrackDTO trackDTO = Application.GetById(trackItemModel.OperationResult, new object[] { trackId });
                    if (trackDTO != null)
                    {
                        trackItemModel.Track = new TrackViewModel(trackDTO);                    

                        return PartialView("CRUD", trackItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                trackItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(trackItemModel.OperationResult);
        }

        // GET: Track/Update/1
        [HttpGet]
        public ActionResult Update(int trackId, int? masterAlbumId = null, int? masterGenreId = null, int? masterMediaTypeId = null)
        {
            TrackItemModel trackItemModel = new TrackItemModel(ActivityOperations, "Update", masterAlbumId, masterGenreId, masterMediaTypeId);
            
            try
            {
                if (IsUpdate(trackItemModel.OperationResult))
                {            
                    TrackDTO trackDTO = Application.GetById(trackItemModel.OperationResult, new object[] { trackId });
                    if (trackDTO != null)
                    {
                        trackItemModel.Track = new TrackViewModel(trackDTO);

                        return PartialView("CRUD", trackItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                trackItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(trackItemModel.OperationResult);
        }

        // POST: Track/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(TrackItemModel trackItemModel)
        {
            try
            {
                if (IsUpdate(trackItemModel.OperationResult))
                {
                    if (IsValid(trackItemModel.OperationResult, trackItemModel.Track))
                    {
                        TrackDTO trackDTO = (TrackDTO)trackItemModel.Track.ToDTO();
                        if (Application.Update(trackItemModel.OperationResult, trackDTO))
                        {
                            if (trackItemModel.IsSave)
                            {
                                return JsonResultSuccess(trackItemModel.OperationResult,
                                    Url.Action("Update", "Track", new { TrackId = trackDTO.TrackId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(trackItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                trackItemModel.OperationResult.ParseException(exception);
            }

            trackItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(trackItemModel.OperationResult);
        }

        // GET: Track/Delete/1
        [HttpGet]
        public ActionResult Delete(int trackId, int? masterAlbumId = null, int? masterGenreId = null, int? masterMediaTypeId = null)
        {
            TrackItemModel trackItemModel = new TrackItemModel(ActivityOperations, "Delete", masterAlbumId, masterGenreId, masterMediaTypeId);
            
            try
            {
                if (IsDelete(trackItemModel.OperationResult))
                {            
                    TrackDTO trackDTO = Application.GetById(trackItemModel.OperationResult, new object[] { trackId });
                    if (trackDTO != null)
                    {
                        trackItemModel.Track = new TrackViewModel(trackDTO);

                        return PartialView("CRUD", trackItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                trackItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(trackItemModel.OperationResult);
        }

        // POST: Track/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TrackItemModel trackItemModel)
        {
            try
            {
                if (IsDelete(trackItemModel.OperationResult))
                {
                    if (Application.Delete(trackItemModel.OperationResult, (TrackDTO)trackItemModel.Track.ToDTO()))
                    {
                        return JsonResultSuccess(trackItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                trackItemModel.OperationResult.ParseException(exception);
            }

            trackItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(trackItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Track/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult();
            dataResult.result = new List<TrackViewModel>();

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Track), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewHelper<TrackViewModel, TrackDTO, Track>.ToViewList(Application.Search(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Track/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, TrackResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Track/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, TrackResources.EntitySingular + ".pdf");
            }
        }

        // POST: Track/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, TrackResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}