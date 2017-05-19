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

namespace Chinook.Mvc
{
    public class ArtistAPIController : BaseApiControllerApplication<ArtistDTO, Artist>
    {
        #region Methods

        public ArtistAPIController(IChinookGenericApplicationDTO<ArtistDTO, Artist> application)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        // DELETE: api/artistapi/1
        [Route("api/artistapi/{artistId}")]
        public IHttpActionResult DeleteArtist(int artistId)
        {
            ZOperationResult operationResult = new ZOperationResult();
            
            try
            {
                ArtistDTO artistDTO = Application.GetById(operationResult, new object[] { artistId });    
                if (artistDTO != null)
                {
                    if (Application.Delete(operationResult, artistDTO))
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

        // GET: api/artistapi
        public IHttpActionResult GetArtists()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                return Ok<IEnumerable<ArtistDTO>>(Application.Select(operationResult,
                    null, null, (null as int?), AppDefaults.SyncfusionRecordsBySearch));
                //return Ok<IEnumerable<ArtistDTO>>(Application.SelectAll(operationResult));
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // GET: api/artistapi/1
        [Route("api/artistapi/{artistId}")]
        public IHttpActionResult GetArtist(int artistId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                ArtistDTO artistDTO = Application.GetById(operationResult, new object[] { artistId });   
                if (artistDTO != null)
                {
                    return Ok(artistDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // POST: api/artistapi
        public IHttpActionResult PostArtist(ArtistDTO artistDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsValid(operationResult, artistDTO))
                {
                    if (Application.Create(operationResult, artistDTO))
                    {
                        return CreatedAtRoute("DefaultApi", new { artistDTO.ArtistId }, artistDTO);
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // PUT: api/artistapi/1
        [Route("api/artistapi/{artistId}")]
        public IHttpActionResult PutArtist(int artistId, ArtistDTO artistDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsValid(operationResult, artistDTO))
                {
                    if (Application.Create(operationResult, artistDTO))
                    {
                        return Ok(artistDTO);
                    }
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
