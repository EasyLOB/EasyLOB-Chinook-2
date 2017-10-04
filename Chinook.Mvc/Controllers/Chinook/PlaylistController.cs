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
    public partial class PlaylistController : BaseMvcControllerSCRUDApplication<PlaylistDTO, Playlist>
    {
        #region Methods

        public PlaylistController(IChinookGenericApplicationDTO<PlaylistDTO, Playlist> application)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Playlist
        // GET: Playlist/Index
        [HttpGet]
        public ActionResult Index()
        {
            PlaylistCollectionModel playlistCollectionModel = new PlaylistCollectionModel(ActivityOperations, "Index", null);

            try
            {
                IsOperation(playlistCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                playlistCollectionModel.OperationResult.ParseException(exception);
            }

            return View(playlistCollectionModel);
        }        

        // GET & POST: Playlist/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null)
        {
            PlaylistCollectionModel playlistCollectionModel = new PlaylistCollectionModel(ActivityOperations, "Search", masterControllerAction);

            try
            {
                if (IsOperation(playlistCollectionModel.OperationResult))
                {
                    return PartialView(playlistCollectionModel);
                }
            }
            catch (Exception exception)
            {
                playlistCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(playlistCollectionModel.OperationResult);
        }

        // GET & POST: Playlist/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return PartialView("_PlaylistLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Playlist/Create
        [HttpGet]
        public ActionResult Create()
        {
            PlaylistItemModel playlistItemModel = new PlaylistItemModel(ActivityOperations, "Create");

            try
            {
                if (IsCreate(playlistItemModel.OperationResult))
                {
                    return PartialView("CRUD", playlistItemModel);
                }            
            }
            catch (Exception exception)
            {
                playlistItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(playlistItemModel.OperationResult);
        }

        // POST: Playlist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaylistItemModel playlistItemModel)
        {
            try
            {
                if (IsCreate(playlistItemModel.OperationResult))
                {
                    if (IsValid(playlistItemModel.OperationResult, playlistItemModel.Playlist))
                    {
                        PlaylistDTO playlistDTO = (PlaylistDTO)playlistItemModel.Playlist.ToDTO();
                        if (Application.Create(playlistItemModel.OperationResult, playlistDTO))
                        {
                            if (playlistItemModel.IsSave)
                            {
                                playlistItemModel.OperationResult.StatusMessage =
                                    EasyLOB.Resources.PresentationResources.CreateToUpdate;
                                return JsonResultSuccess(playlistItemModel.OperationResult,
                                    Url.Action("Update", "Playlist", new { PlaylistId = playlistDTO.PlaylistId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(playlistItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                playlistItemModel.OperationResult.ParseException(exception);
            }

            playlistItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(playlistItemModel.OperationResult);
        }

        // GET: Playlist/Read/1
        [HttpGet]
        public ActionResult Read(int playlistId)
        {
            PlaylistItemModel playlistItemModel = new PlaylistItemModel(ActivityOperations, "Read");
            
            try
            {
                if (IsRead(playlistItemModel.OperationResult))
                {
                    PlaylistDTO playlistDTO = Application.GetById(playlistItemModel.OperationResult, new object[] { playlistId });
                    if (playlistDTO != null)
                    {
                        playlistItemModel.Playlist = new PlaylistViewModel(playlistDTO);                    

                        return PartialView("CRUD", playlistItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                playlistItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(playlistItemModel.OperationResult);
        }

        // GET: Playlist/Update/1
        [HttpGet]
        public ActionResult Update(int playlistId)
        {
            PlaylistItemModel playlistItemModel = new PlaylistItemModel(ActivityOperations, "Update");
            
            try
            {
                if (IsUpdate(playlistItemModel.OperationResult))
                {            
                    PlaylistDTO playlistDTO = Application.GetById(playlistItemModel.OperationResult, new object[] { playlistId });
                    if (playlistDTO != null)
                    {
                        playlistItemModel.Playlist = new PlaylistViewModel(playlistDTO);

                        return PartialView("CRUD", playlistItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                playlistItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(playlistItemModel.OperationResult);
        }

        // POST: Playlist/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PlaylistItemModel playlistItemModel)
        {
            try
            {
                if (IsUpdate(playlistItemModel.OperationResult))
                {
                    if (IsValid(playlistItemModel.OperationResult, playlistItemModel.Playlist))
                    {
                        PlaylistDTO playlistDTO = (PlaylistDTO)playlistItemModel.Playlist.ToDTO();
                        if (Application.Update(playlistItemModel.OperationResult, playlistDTO))
                        {
                            if (playlistItemModel.IsSave)
                            {
                                return JsonResultSuccess(playlistItemModel.OperationResult,
                                    Url.Action("Update", "Playlist", new { PlaylistId = playlistDTO.PlaylistId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(playlistItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                playlistItemModel.OperationResult.ParseException(exception);
            }

            playlistItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(playlistItemModel.OperationResult);
        }

        // GET: Playlist/Delete/1
        [HttpGet]
        public ActionResult Delete(int playlistId)
        {
            PlaylistItemModel playlistItemModel = new PlaylistItemModel(ActivityOperations, "Delete");
            
            try
            {
                if (IsDelete(playlistItemModel.OperationResult))
                {            
                    PlaylistDTO playlistDTO = Application.GetById(playlistItemModel.OperationResult, new object[] { playlistId });
                    if (playlistDTO != null)
                    {
                        playlistItemModel.Playlist = new PlaylistViewModel(playlistDTO);

                        return PartialView("CRUD", playlistItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                playlistItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(playlistItemModel.OperationResult);
        }

        // POST: Playlist/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PlaylistItemModel playlistItemModel)
        {
            try
            {
                if (IsDelete(playlistItemModel.OperationResult))
                {
                    if (Application.Delete(playlistItemModel.OperationResult, (PlaylistDTO)playlistItemModel.Playlist.ToDTO()))
                    {
                        return JsonResultSuccess(playlistItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                playlistItemModel.OperationResult.ParseException(exception);
            }

            playlistItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(playlistItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Playlist/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            IEnumerable data = new List<PlaylistViewModel>();
            int countAll = 0;
            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Playlist), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    data = ZViewHelper<PlaylistViewModel, PlaylistDTO, Playlist>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
                    if (dataManager.RequiresCounts)
                    {
                        countAll = Application.Count(where, args.ToArray());
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

            return Json(JsonConvert.SerializeObject(new { result = data, count = countAll }), JsonRequestBehavior.AllowGet);
        } 

        // POST: Playlist/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, PlaylistResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Playlist/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, PlaylistResources.EntitySingular + ".pdf");
            }
        }

        // POST: Playlist/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, PlaylistResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}