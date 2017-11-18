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
    public partial class AlbumController : BaseMvcControllerSCRUDApplication<AlbumDTO, Album>
    {
        #region Methods

        public AlbumController(IChinookGenericApplicationDTO<AlbumDTO, Album> application)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Album
        // GET: Album/Index
        [HttpGet]
        public ActionResult Index(int? masterArtistId = null)
        {
            AlbumCollectionModel albumCollectionModel = new AlbumCollectionModel(ActivityOperations, "Index", null, masterArtistId);

            try
            {
                IsOperation(albumCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                albumCollectionModel.OperationResult.ParseException(exception);
            }

            return View(albumCollectionModel);
        }        

        // GET & POST: Album/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null, int? masterArtistId = null)
        {
            AlbumCollectionModel albumCollectionModel = new AlbumCollectionModel(ActivityOperations, "Search", masterControllerAction, masterArtistId);

            try
            {
                if (IsOperation(albumCollectionModel.OperationResult))
                {
                    return PartialView(albumCollectionModel);
                }
            }
            catch (Exception exception)
            {
                albumCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(albumCollectionModel.OperationResult);
        }

        // GET & POST: Album/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return PartialView("_AlbumLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Album/Create
        [HttpGet]
        public ActionResult Create(int? masterArtistId = null)
        {
            AlbumItemModel albumItemModel = new AlbumItemModel(ActivityOperations, "Create", masterArtistId);

            try
            {
                if (IsCreate(albumItemModel.OperationResult))
                {
                    return PartialView("CRUD", albumItemModel);
                }            
            }
            catch (Exception exception)
            {
                albumItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(albumItemModel.OperationResult);
        }

        // POST: Album/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumItemModel albumItemModel)
        {
            try
            {
                if (IsCreate(albumItemModel.OperationResult))
                {
                    if (IsValid(albumItemModel.OperationResult, albumItemModel.Album))
                    {
                        AlbumDTO albumDTO = (AlbumDTO)albumItemModel.Album.ToDTO();
                        if (Application.Create(albumItemModel.OperationResult, albumDTO))
                        {
                            if (albumItemModel.IsSave)
                            {
                                albumItemModel.OperationResult.StatusMessage =
                                    EasyLOB.Resources.PresentationResources.CreateToUpdate;
                                return JsonResultSuccess(albumItemModel.OperationResult,
                                    Url.Action("Update", "Album", new { AlbumId = albumDTO.AlbumId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(albumItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                albumItemModel.OperationResult.ParseException(exception);
            }

            albumItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(albumItemModel.OperationResult);
        }

        // GET: Album/Read/1
        [HttpGet]
        public ActionResult Read(int albumId, int? masterArtistId = null)
        {
            AlbumItemModel albumItemModel = new AlbumItemModel(ActivityOperations, "Read", masterArtistId);
            
            try
            {
                if (IsRead(albumItemModel.OperationResult))
                {
                    AlbumDTO albumDTO = Application.GetById(albumItemModel.OperationResult, new object[] { albumId });
                    if (albumDTO != null)
                    {
                        albumItemModel.Album = new AlbumViewModel(albumDTO);                    

                        return PartialView("CRUD", albumItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                albumItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(albumItemModel.OperationResult);
        }

        // GET: Album/Update/1
        [HttpGet]
        public ActionResult Update(int albumId, int? masterArtistId = null)
        {
            AlbumItemModel albumItemModel = new AlbumItemModel(ActivityOperations, "Update", masterArtistId);
            
            try
            {
                if (IsUpdate(albumItemModel.OperationResult))
                {            
                    AlbumDTO albumDTO = Application.GetById(albumItemModel.OperationResult, new object[] { albumId });
                    if (albumDTO != null)
                    {
                        albumItemModel.Album = new AlbumViewModel(albumDTO);

                        return PartialView("CRUD", albumItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                albumItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(albumItemModel.OperationResult);
        }

        // POST: Album/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(AlbumItemModel albumItemModel)
        {
            try
            {
                if (IsUpdate(albumItemModel.OperationResult))
                {
                    if (IsValid(albumItemModel.OperationResult, albumItemModel.Album))
                    {
                        AlbumDTO albumDTO = (AlbumDTO)albumItemModel.Album.ToDTO();
                        if (Application.Update(albumItemModel.OperationResult, albumDTO))
                        {
                            if (albumItemModel.IsSave)
                            {
                                return JsonResultSuccess(albumItemModel.OperationResult,
                                    Url.Action("Update", "Album", new { AlbumId = albumDTO.AlbumId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(albumItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                albumItemModel.OperationResult.ParseException(exception);
            }

            albumItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(albumItemModel.OperationResult);
        }

        // GET: Album/Delete/1
        [HttpGet]
        public ActionResult Delete(int albumId, int? masterArtistId = null)
        {
            AlbumItemModel albumItemModel = new AlbumItemModel(ActivityOperations, "Delete", masterArtistId);
            
            try
            {
                if (IsDelete(albumItemModel.OperationResult))
                {            
                    AlbumDTO albumDTO = Application.GetById(albumItemModel.OperationResult, new object[] { albumId });
                    if (albumDTO != null)
                    {
                        albumItemModel.Album = new AlbumViewModel(albumDTO);

                        return PartialView("CRUD", albumItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                albumItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(albumItemModel.OperationResult);
        }

        // POST: Album/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AlbumItemModel albumItemModel)
        {
            try
            {
                if (IsDelete(albumItemModel.OperationResult))
                {
                    if (Application.Delete(albumItemModel.OperationResult, (AlbumDTO)albumItemModel.Album.ToDTO()))
                    {
                        return JsonResultSuccess(albumItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                albumItemModel.OperationResult.ParseException(exception);
            }

            albumItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(albumItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Album/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            SyncfusionDataResult dataResult = new SyncfusionDataResult();
            dataResult.result = new List<AlbumViewModel>();

            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Album), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    dataResult.result = ZViewHelper<AlbumViewModel, AlbumDTO, Album>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Album/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, AlbumResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Album/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, AlbumResources.EntitySingular + ".pdf");
            }
        }

        // POST: Album/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, AlbumResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}