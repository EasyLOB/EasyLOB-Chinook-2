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
    public partial class GenreController : BaseMvcControllerSCRUDApplication<GenreDTO, Genre>
    {
        #region Methods

        public GenreController(IChinookGenericApplicationDTO<GenreDTO, Genre> application)
        {
            Application = application;            
        }

        #endregion Methods

        #region Methods SCRUD

        // GET: Genre
        // GET: Genre/Index
        [HttpGet]
        public ActionResult Index()
        {
            GenreCollectionModel genreCollectionModel = new GenreCollectionModel(ActivityOperations, "Index", null);

            try
            {
                IsOperation(genreCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                genreCollectionModel.OperationResult.ParseException(exception);
            }

            return View(genreCollectionModel);
        }        

        // GET & POST: Genre/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterControllerAction = null)
        {
            GenreCollectionModel genreCollectionModel = new GenreCollectionModel(ActivityOperations, "Search", masterControllerAction);

            try
            {
                if (IsOperation(genreCollectionModel.OperationResult))
                {
                    return PartialView(genreCollectionModel);
                }
            }
            catch (Exception exception)
            {
                genreCollectionModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(genreCollectionModel.OperationResult);
        }

        // GET & POST: Genre/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, List<LookupModelElement> elements = null, string query = null)
        {
            LookupModel lookupModel = new LookupModel(ActivityOperations, text, valueId, elements, query);

            try
            {
                if (IsSearch(lookupModel.OperationResult))
                {
                    return PartialView("_GenreLookup", lookupModel);
                }
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return null;
        }

        // GET: Genre/Create
        [HttpGet]
        public ActionResult Create()
        {
            GenreItemModel genreItemModel = new GenreItemModel(ActivityOperations, "Create");

            try
            {
                if (IsCreate(genreItemModel.OperationResult))
                {
                    return PartialView("CRUD", genreItemModel);
                }            
            }
            catch (Exception exception)
            {
                genreItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(genreItemModel.OperationResult);
        }

        // POST: Genre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreItemModel genreItemModel)
        {
            try
            {
                if (IsCreate(genreItemModel.OperationResult))
                {
                    if (IsValid(genreItemModel.OperationResult, genreItemModel.Genre))
                    {
                        GenreDTO genreDTO = (GenreDTO)genreItemModel.Genre.ToDTO();
                        if (Application.Create(genreItemModel.OperationResult, genreDTO))
                        {
                            if (genreItemModel.IsSave)
                            {
                                genreItemModel.OperationResult.StatusMessage =
                                    EasyLOB.Resources.PresentationResources.CreateToUpdate;
                                return JsonResultSuccess(genreItemModel.OperationResult,
                                    Url.Action("Update", "Genre", new { GenreId = genreDTO.GenreId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(genreItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                genreItemModel.OperationResult.ParseException(exception);
            }

            genreItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(genreItemModel.OperationResult);
        }

        // GET: Genre/Read/1
        [HttpGet]
        public ActionResult Read(int genreId)
        {
            GenreItemModel genreItemModel = new GenreItemModel(ActivityOperations, "Read");
            
            try
            {
                if (IsRead(genreItemModel.OperationResult))
                {
                    GenreDTO genreDTO = Application.GetById(genreItemModel.OperationResult, new object[] { genreId });
                    if (genreDTO != null)
                    {
                        genreItemModel.Genre = new GenreViewModel(genreDTO);                    

                        return PartialView("CRUD", genreItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                genreItemModel.OperationResult.ParseException(exception);
            }            

            return JsonResultOperationResult(genreItemModel.OperationResult);
        }

        // GET: Genre/Update/1
        [HttpGet]
        public ActionResult Update(int genreId)
        {
            GenreItemModel genreItemModel = new GenreItemModel(ActivityOperations, "Update");
            
            try
            {
                if (IsUpdate(genreItemModel.OperationResult))
                {            
                    GenreDTO genreDTO = Application.GetById(genreItemModel.OperationResult, new object[] { genreId });
                    if (genreDTO != null)
                    {
                        genreItemModel.Genre = new GenreViewModel(genreDTO);

                        return PartialView("CRUD", genreItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                genreItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(genreItemModel.OperationResult);
        }

        // POST: Genre/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GenreItemModel genreItemModel)
        {
            try
            {
                if (IsUpdate(genreItemModel.OperationResult))
                {
                    if (IsValid(genreItemModel.OperationResult, genreItemModel.Genre))
                    {
                        GenreDTO genreDTO = (GenreDTO)genreItemModel.Genre.ToDTO();
                        if (Application.Update(genreItemModel.OperationResult, genreDTO))
                        {
                            if (genreItemModel.IsSave)
                            {
                                return JsonResultSuccess(genreItemModel.OperationResult,
                                    Url.Action("Update", "Genre", new { GenreId = genreDTO.GenreId }, Request.Url.Scheme));
                            }
                            else
                            {
                                return JsonResultSuccess(genreItemModel.OperationResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                genreItemModel.OperationResult.ParseException(exception);
            }

            genreItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(genreItemModel.OperationResult);
        }

        // GET: Genre/Delete/1
        [HttpGet]
        public ActionResult Delete(int genreId)
        {
            GenreItemModel genreItemModel = new GenreItemModel(ActivityOperations, "Delete");
            
            try
            {
                if (IsDelete(genreItemModel.OperationResult))
                {            
                    GenreDTO genreDTO = Application.GetById(genreItemModel.OperationResult, new object[] { genreId });
                    if (genreDTO != null)
                    {
                        genreItemModel.Genre = new GenreViewModel(genreDTO);

                        return PartialView("CRUD", genreItemModel);
                    }
                }
            }
            catch (Exception exception)
            {
                genreItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(genreItemModel.OperationResult);
        }

        // POST: Genre/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(GenreItemModel genreItemModel)
        {
            try
            {
                if (IsDelete(genreItemModel.OperationResult))
                {
                    if (Application.Delete(genreItemModel.OperationResult, (GenreDTO)genreItemModel.Genre.ToDTO()))
                    {
                        return JsonResultSuccess(genreItemModel.OperationResult);
                    }
                }
            }
            catch (Exception exception)
            {
                genreItemModel.OperationResult.ParseException(exception);
            }

            genreItemModel.ActivityOperations = ActivityOperations;

            return JsonResultOperationResult(genreItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Genre/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            IEnumerable data = new List<GenreViewModel>();
            int countAll = 0;
            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch())
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Genre), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    data = ZViewHelper<GenreViewModel, GenreDTO, Genre>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
                    if (dataManager.RequiresCounts)
                    {
                        countAll = Application.Count(where, args.ToArray());
                    }
                }
                catch (Exception exception)
                {
                    operationResult.ParseException(exception);
                }

                if (!operationResult.Ok)
                {
                    throw new InvalidOperationException(operationResult.Text);
                }
            }

            return Json(JsonConvert.SerializeObject(new { result = data, count = countAll }), JsonRequestBehavior.AllowGet);
        } 

        // POST: Genre/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            if (IsExport())
            {
                ExportToExcel(gridModel, GenreResources.EntitySingular + ".xlsx");
            }
        }

        // POST: Genre/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            if (IsExport())
            {
                ExportToPdf(gridModel, GenreResources.EntitySingular + ".pdf");
            }
        }

        // POST: Genre/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            if (IsExport())
            {
                ExportToWord(gridModel, GenreResources.EntitySingular + ".docx");
            }
        }
        
        #endregion Methods Syncfusion
    }
}