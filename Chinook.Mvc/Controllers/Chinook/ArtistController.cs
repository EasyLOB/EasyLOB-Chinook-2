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
    public partial class ArtistController : BaseMvcControllerSCRUDApplication<ArtistDTO, Artist>
    {
        #region Methods

        public ArtistController(IChinookGenericApplicationDTO<ArtistDTO, Artist> application)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Artist
        // GET: Artist/Index
        [HttpGet]
        public ActionResult Index()
        {
            ArtistCollectionModel artistCollectionModel = new ArtistCollectionModel(ActivityOperations, "Index", null);

            try
            {
                IsOperation(artistCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                artistCollectionModel.OperationResult.ParseException(exception);
            }

            return View(artistCollectionModel);
        }        

        // GET & POST: Artist/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null)
        {
            ArtistCollectionModel artistCollectionModel = new ArtistCollectionModel(ActivityOperations, "Search", masterControllerAction);

            try
            {
                if (IsOperation(artistCollectionModel.OperationResult))
                {
                    return PartialView(artistCollectionModel);
                }
            }
            catch (Exception exception)
            {
                artistCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(artistCollectionModel.OperationResult);
        }

        // GET & POST: Artist/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return PartialView("_ArtistLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Artist/Create
        [HttpGet]
        public ActionResult Create()
        {
            ArtistItemModel artistItemModel = new ArtistItemModel(ActivityOperations, "Create");

            try
            {
                if (IsCreate(artistItemModel.OperationResult))
                {
                    return PartialView("CRUD", artistItemModel);
                }            
            }
            catch (Exception exception)
            {
                artistItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(artistItemModel.OperationResult);
        }

        // POST: Artist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtistItemModel artistItemModel)
        {
            try
            {
                if (IsCreate(artistItemModel.OperationResult))
                {
                    if (IsValid(artistItemModel.OperationResult, artistItemModel.Artist))
                    {
                        ArtistDTO artistDTO = (ArtistDTO)artistItemModel.Artist.ToDTO();
                        if (Application.Create(artistItemModel.OperationResult, artistDTO))
                        {
                            if (artistItemModel.IsSave)
                            {
                                artistItemModel.OperationResult.StatusMessage =
                                    EasyLOB.Resources.PresentationResources.CreateToUpdate;
                                return JsonResultSuccess(artistItemModel.OperationResult,
                                    Url.Action("Update", "Artist", new { ArtistId = artistDTO.ArtistId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(artistItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                artistItemModel.OperationResult.ParseException(exception);
            }

            artistItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(artistItemModel.OperationResult);
        }

        // GET: Artist/Read/1
        [HttpGet]
        public ActionResult Read(int artistId)
        {
            ArtistItemModel artistItemModel = new ArtistItemModel(ActivityOperations, "Read");
            
            try
            {
                if (IsRead(artistItemModel.OperationResult))
                {
                    ArtistDTO artistDTO = Application.GetById(artistItemModel.OperationResult, new object[] { artistId });
                    if (artistDTO != null)
                    {
                        artistItemModel.Artist = new ArtistViewModel(artistDTO);                    

                        return PartialView("CRUD", artistItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                artistItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(artistItemModel.OperationResult);
        }

        // GET: Artist/Update/1
        [HttpGet]
        public ActionResult Update(int artistId)
        {
            ArtistItemModel artistItemModel = new ArtistItemModel(ActivityOperations, "Update");
            
            try
            {
                if (IsUpdate(artistItemModel.OperationResult))
                {            
                    ArtistDTO artistDTO = Application.GetById(artistItemModel.OperationResult, new object[] { artistId });
                    if (artistDTO != null)
                    {
                        artistItemModel.Artist = new ArtistViewModel(artistDTO);

                        return PartialView("CRUD", artistItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                artistItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(artistItemModel.OperationResult);
        }

        // POST: Artist/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ArtistItemModel artistItemModel)
        {
            try
            {
                if (IsUpdate(artistItemModel.OperationResult))
                {
                    if (IsValid(artistItemModel.OperationResult, artistItemModel.Artist))
                    {
                        ArtistDTO artistDTO = (ArtistDTO)artistItemModel.Artist.ToDTO();
                        if (Application.Update(artistItemModel.OperationResult, artistDTO))
                        {
                            if (artistItemModel.IsSave)
                            {
                                return JsonResultSuccess(artistItemModel.OperationResult,
                                    Url.Action("Update", "Artist", new { ArtistId = artistDTO.ArtistId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(artistItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                artistItemModel.OperationResult.ParseException(exception);
            }

            artistItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(artistItemModel.OperationResult);
        }

        // GET: Artist/Delete/1
        [HttpGet]
        public ActionResult Delete(int artistId)
        {
            ArtistItemModel artistItemModel = new ArtistItemModel(ActivityOperations, "Delete");
            
            try
            {
                if (IsDelete(artistItemModel.OperationResult))
                {            
                    ArtistDTO artistDTO = Application.GetById(artistItemModel.OperationResult, new object[] { artistId });
                    if (artistDTO != null)
                    {
                        artistItemModel.Artist = new ArtistViewModel(artistDTO);

                        return PartialView("CRUD", artistItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                artistItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(artistItemModel.OperationResult);
        }

        // POST: Artist/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ArtistItemModel artistItemModel)
        {
            try
            {
                if (IsDelete(artistItemModel.OperationResult))
                {
                    if (Application.Delete(artistItemModel.OperationResult, (ArtistDTO)artistItemModel.Artist.ToDTO()))
                    {
                        return JsonResultSuccess(artistItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                artistItemModel.OperationResult.ParseException(exception);
            }

            artistItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(artistItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Artist/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            IEnumerable data = new List<ArtistViewModel>();
            int countAll = 0;
            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch(operationResult))
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Artist), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    data = ZViewHelper<ArtistViewModel, ArtistDTO, Artist>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Artist/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, ArtistResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Artist/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, ArtistResources.EntitySingular + ".pdf");
            }
        }

        // POST: Artist/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, ArtistResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}