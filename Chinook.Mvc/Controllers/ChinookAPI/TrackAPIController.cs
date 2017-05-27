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
    public class TrackAPIController : BaseApiControllerApplication<TrackDTO, Track>
    {
        #region Methods

        public TrackAPIController(IChinookGenericApplicationDTO<TrackDTO, Track> application)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        // DELETE: api/trackapi/1
        [Route("api/trackapi/{trackId}")]
        public IHttpActionResult DeleteTrack(int trackId)
        {
            ZOperationResult operationResult = new ZOperationResult();
            
            try
            {
                TrackDTO trackDTO = Application.GetById(operationResult, new object[] { trackId });    
                if (trackDTO != null)
                {
                    if (Application.Delete(operationResult, trackDTO))
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

        // GET: api/trackapi
        public IHttpActionResult GetTracks()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                return Ok<IEnumerable<TrackDTO>>(Application.Select(operationResult,
                    null, null, (null as int?), AppDefaults.SyncfusionRecordsBySearch));
                //return Ok<IEnumerable<TrackDTO>>(Application.SelectAll(operationResult));
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // GET: api/trackapi/1
        [Route("api/trackapi/{trackId}")]
        public IHttpActionResult GetTrack(int trackId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                TrackDTO trackDTO = Application.GetById(operationResult, new object[] { trackId });   
                if (trackDTO != null)
                {
                    return Ok(trackDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // POST: api/trackapi
        public IHttpActionResult PostTrack(TrackDTO trackDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (Application.Create(operationResult, trackDTO))
                {
                    return CreatedAtRoute("DefaultApi", new { trackDTO.TrackId }, trackDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // PUT: api/trackapi/1
        [Route("api/trackapi/{trackId}")]
        public IHttpActionResult PutTrack(int trackId, TrackDTO trackDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (Application.Create(operationResult, trackDTO))
                {
                    return Ok(trackDTO);
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
