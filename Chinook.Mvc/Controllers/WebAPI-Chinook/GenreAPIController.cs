using Chinook;
using Chinook.Application;
using Chinook.Data;
using EasyLOB;
using EasyLOB.Library.WebApi;
using EasyLOB.Mvc;
using EasyLOB.WebApi;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Chinook.WebApi
{
    public class GenreAPIController : BaseApiControllerApplication<GenreDTO, Genre>
    {
        #region Methods

        public GenreAPIController(IChinookGenericApplicationDTO<GenreDTO, Genre> application)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        // DELETE: api/genreapi/1
        [Route("api/genreapi/{genreId}")]
        public IHttpActionResult DeleteGenre(int genreId)
        {
            ZOperationResult operationResult = new ZOperationResult();
            
            try
            {
                GenreDTO genreDTO = Application.GetById(operationResult, new object[] { genreId });    
                if (genreDTO != null)
                {
                    if (Application.Delete(operationResult, genreDTO))
                    {
                        return Ok();
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // GET: api/genreapi
        public IHttpActionResult GetGenres()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                return Ok<IEnumerable<GenreDTO>>(Application.Search(operationResult,
                    null, null, (null as int?), AppDefaults.SyncfusionRecordsBySearch));
                //return Ok<IEnumerable<GenreDTO>>(Application.SelectAll(operationResult));
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // GET: api/genreapi/1
        [Route("api/genreapi/{genreId}")]
        public IHttpActionResult GetGenre(int genreId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                GenreDTO genreDTO = Application.GetById(operationResult, new object[] { genreId });   
                if (genreDTO != null)
                {
                    return Ok(genreDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // POST: api/genreapi
        public IHttpActionResult PostGenre(GenreDTO genreDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (Application.Create(operationResult, genreDTO))
                {
                    return CreatedAtRoute("DefaultApi", new { genreDTO.GenreId }, genreDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // PUT: api/genreapi/1
        [Route("api/genreapi/{genreId}")]
        public IHttpActionResult PutGenre(int genreId, GenreDTO genreDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (Application.Create(operationResult, genreDTO))
                {
                    return Ok(genreDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        #endregion Methods REST
    }
}
