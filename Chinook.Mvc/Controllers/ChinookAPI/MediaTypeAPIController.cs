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
    public class MediaTypeAPIController : BaseApiControllerApplication<MediaTypeDTO, MediaType>
    {
        #region Methods

        public MediaTypeAPIController(IChinookGenericApplicationDTO<MediaTypeDTO, MediaType> application)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        // DELETE: api/mediaTypeapi/1
        [Route("api/mediaTypeapi/{mediaTypeId}")]
        public IHttpActionResult DeleteMediaType(int mediaTypeId)
        {
            ZOperationResult operationResult = new ZOperationResult();
            
            try
            {
                MediaTypeDTO mediaTypeDTO = Application.GetById(operationResult, new object[] { mediaTypeId });    
                if (mediaTypeDTO != null)
                {
                    if (Application.Delete(operationResult, mediaTypeDTO))
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

        // GET: api/mediaTypeapi
        public IHttpActionResult GetMediaTypes()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                return Ok<IEnumerable<MediaTypeDTO>>(Application.Select(operationResult,
                    null, null, (null as int?), AppDefaults.SyncfusionRecordsBySearch));
                //return Ok<IEnumerable<MediaTypeDTO>>(Application.SelectAll(operationResult));
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // GET: api/mediaTypeapi/1
        [Route("api/mediaTypeapi/{mediaTypeId}")]
        public IHttpActionResult GetMediaType(int mediaTypeId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                MediaTypeDTO mediaTypeDTO = Application.GetById(operationResult, new object[] { mediaTypeId });   
                if (mediaTypeDTO != null)
                {
                    return Ok(mediaTypeDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // POST: api/mediaTypeapi
        public IHttpActionResult PostMediaType(MediaTypeDTO mediaTypeDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsValid(operationResult, mediaTypeDTO))
                {
                    if (Application.Create(operationResult, mediaTypeDTO))
                    {
                        return CreatedAtRoute("DefaultApi", new { mediaTypeDTO.MediaTypeId }, mediaTypeDTO);
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // PUT: api/mediaTypeapi/1
        [Route("api/mediaTypeapi/{mediaTypeId}")]
        public IHttpActionResult PutMediaType(int mediaTypeId, MediaTypeDTO mediaTypeDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsValid(operationResult, mediaTypeDTO))
                {
                    if (Application.Create(operationResult, mediaTypeDTO))
                    {
                        return Ok(mediaTypeDTO);
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
