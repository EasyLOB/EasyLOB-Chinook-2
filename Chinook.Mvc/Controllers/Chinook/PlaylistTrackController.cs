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
    public partial class PlaylistTrackController : BaseMvcControllerSCRUDApplication<PlaylistTrackDTO, PlaylistTrack>
    {
        #region Methods

        public PlaylistTrackController(IChinookGenericApplicationDTO<PlaylistTrackDTO, PlaylistTrack> application)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: PlaylistTrack
        // GET: PlaylistTrack/Index
        [HttpGet]
        public ActionResult Index(int? masterPlaylistId = null, int? masterTrackId = null)
        {
            PlaylistTrackCollectionModel playlistTrackCollectionModel = new PlaylistTrackCollectionModel(ActivityOperations, "Index", null, masterPlaylistId, masterTrackId);

            try
            {
                if (IsIndex(playlistTrackCollectionModel.OperationResult))
                {
                    return View(playlistTrackCollectionModel);
                }
            }
            catch (Exception exception)
            {
                playlistTrackCollectionModel.OperationResult.ParseException(exception);
            }

            return View("OperationResult", new OperationResultViewModel(playlistTrackCollectionModel.OperationResult));
        }        

        // GET & POST: PlaylistTrack/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, int? masterPlaylistId = null, int? masterTrackId = null)
        {
            PlaylistTrackCollectionModel playlistTrackCollectionModel = new PlaylistTrackCollectionModel(ActivityOperations, "Search", masterControllerAction, masterPlaylistId, masterTrackId);

            try
            {
                if (IsOperation(playlistTrackCollectionModel.OperationResult))
                {
                    return PartialView(playlistTrackCollectionModel);
                }
            }
            catch (Exception exception)
            {
                playlistTrackCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(playlistTrackCollectionModel.OperationResult);
        }

        // GET & POST: PlaylistTrack/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return PartialView("_PlaylistTrackLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: PlaylistTrack/Create
        [HttpGet]
        public ActionResult Create(int? masterPlaylistId = null, int? masterTrackId = null)
        {
            PlaylistTrackItemModel playlistTrackItemModel = new PlaylistTrackItemModel(ActivityOperations, "Create", masterPlaylistId, masterTrackId);

            try
            {
                if (IsCreate(playlistTrackItemModel.OperationResult))
                {
                    return PartialView("CRUD", playlistTrackItemModel);
                }            
            }
            catch (Exception exception)
            {
                playlistTrackItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(playlistTrackItemModel.OperationResult);
        }

        // POST: PlaylistTrack/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaylistTrackItemModel playlistTrackItemModel)
        {
            try
            {
                if (IsCreate(playlistTrackItemModel.OperationResult))
                {
                    if (IsValid(playlistTrackItemModel.OperationResult, playlistTrackItemModel.PlaylistTrack))
                    {
                        PlaylistTrackDTO playlistTrackDTO = (PlaylistTrackDTO)playlistTrackItemModel.PlaylistTrack.ToDTO();
                        if (Application.Create(playlistTrackItemModel.OperationResult, playlistTrackDTO))
                        {
                            if (playlistTrackItemModel.IsSave)
                            {
                                playlistTrackItemModel.OperationResult.StatusMessage =
                                    EasyLOB.Resources.PresentationResources.CreateToUpdate;
                                return JsonResultSuccess(playlistTrackItemModel.OperationResult,
                                    Url.Action("Update", "PlaylistTrack", new { PlaylistId = playlistTrackDTO.PlaylistId, TrackId = playlistTrackDTO.TrackId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(playlistTrackItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                playlistTrackItemModel.OperationResult.ParseException(exception);
            }

            playlistTrackItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(playlistTrackItemModel.OperationResult);
        }

        // GET: PlaylistTrack/Read/1
        [HttpGet]
        public ActionResult Read(int playlistId, int trackId, int? masterPlaylistId = null, int? masterTrackId = null)
        {
            PlaylistTrackItemModel playlistTrackItemModel = new PlaylistTrackItemModel(ActivityOperations, "Read", masterPlaylistId, masterTrackId);
            
            try
            {
                if (IsRead(playlistTrackItemModel.OperationResult))
                {
                    PlaylistTrackDTO playlistTrackDTO = Application.GetById(playlistTrackItemModel.OperationResult, new object[] { playlistId, trackId });
                    if (playlistTrackDTO != null)
                    {
                        playlistTrackItemModel.PlaylistTrack = new PlaylistTrackViewModel(playlistTrackDTO);                    

                        return PartialView("CRUD", playlistTrackItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                playlistTrackItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(playlistTrackItemModel.OperationResult);
        }

        // GET: PlaylistTrack/Update/1
        [HttpGet]
        public ActionResult Update(int playlistId, int trackId, int? masterPlaylistId = null, int? masterTrackId = null)
        {
            PlaylistTrackItemModel playlistTrackItemModel = new PlaylistTrackItemModel(ActivityOperations, "Update", masterPlaylistId, masterTrackId);
            
            try
            {
                if (IsUpdate(playlistTrackItemModel.OperationResult))
                {            
                    PlaylistTrackDTO playlistTrackDTO = Application.GetById(playlistTrackItemModel.OperationResult, new object[] { playlistId, trackId });
                    if (playlistTrackDTO != null)
                    {
                        playlistTrackItemModel.PlaylistTrack = new PlaylistTrackViewModel(playlistTrackDTO);

                        return PartialView("CRUD", playlistTrackItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                playlistTrackItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(playlistTrackItemModel.OperationResult);
        }

        // POST: PlaylistTrack/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PlaylistTrackItemModel playlistTrackItemModel)
        {
            try
            {
                if (IsUpdate(playlistTrackItemModel.OperationResult))
                {
                    if (IsValid(playlistTrackItemModel.OperationResult, playlistTrackItemModel.PlaylistTrack))
                    {
                        PlaylistTrackDTO playlistTrackDTO = (PlaylistTrackDTO)playlistTrackItemModel.PlaylistTrack.ToDTO();
                        if (Application.Update(playlistTrackItemModel.OperationResult, playlistTrackDTO))
                        {
                            if (playlistTrackItemModel.IsSave)
                            {
                                return JsonResultSuccess(playlistTrackItemModel.OperationResult,
                                    Url.Action("Update", "PlaylistTrack", new { PlaylistId = playlistTrackDTO.PlaylistId, TrackId = playlistTrackDTO.TrackId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(playlistTrackItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                playlistTrackItemModel.OperationResult.ParseException(exception);
            }

            playlistTrackItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(playlistTrackItemModel.OperationResult);
        }

        // GET: PlaylistTrack/Delete/1
        [HttpGet]
        public ActionResult Delete(int playlistId, int trackId, int? masterPlaylistId = null, int? masterTrackId = null)
        {
            PlaylistTrackItemModel playlistTrackItemModel = new PlaylistTrackItemModel(ActivityOperations, "Delete", masterPlaylistId, masterTrackId);
            
            try
            {
                if (IsDelete(playlistTrackItemModel.OperationResult))
                {            
                    PlaylistTrackDTO playlistTrackDTO = Application.GetById(playlistTrackItemModel.OperationResult, new object[] { playlistId, trackId });
                    if (playlistTrackDTO != null)
                    {
                        playlistTrackItemModel.PlaylistTrack = new PlaylistTrackViewModel(playlistTrackDTO);

                        return PartialView("CRUD", playlistTrackItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                playlistTrackItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(playlistTrackItemModel.OperationResult);
        }

        // POST: PlaylistTrack/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PlaylistTrackItemModel playlistTrackItemModel)
        {
            try
            {
                if (IsDelete(playlistTrackItemModel.OperationResult))
                {
                    if (Application.Delete(playlistTrackItemModel.OperationResult, (PlaylistTrackDTO)playlistTrackItemModel.PlaylistTrack.ToDTO()))
                    {
                        return JsonResultSuccess(playlistTrackItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                playlistTrackItemModel.OperationResult.ParseException(exception);
            }

            playlistTrackItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(playlistTrackItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: PlaylistTrack/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult();
            dataResult.result = new List<PlaylistTrackViewModel>();

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(PlaylistTrack), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewHelper<PlaylistTrackViewModel, PlaylistTrackDTO, PlaylistTrack>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: PlaylistTrack/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, PlaylistTrackResources.EntitySingular + ".xlsx");
            }
        }

        // POST: PlaylistTrack/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, PlaylistTrackResources.EntitySingular + ".pdf");
            }
        }

        // POST: PlaylistTrack/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, PlaylistTrackResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}