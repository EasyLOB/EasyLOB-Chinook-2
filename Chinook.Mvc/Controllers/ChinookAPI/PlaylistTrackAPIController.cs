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
    public class PlaylistTrackAPIController : BaseApiControllerApplication<PlaylistTrackDTO, PlaylistTrack>
    {
        #region Methods

        public PlaylistTrackAPIController(IChinookGenericApplicationDTO<PlaylistTrackDTO, PlaylistTrack> application)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        // DELETE: api/playlistTrackapi/1
        [Route("api/playlistTrackapi/{playlistId}/{trackId}")]
        public IHttpActionResult DeletePlaylistTrack(int playlistId, int trackId)
        {
            ZOperationResult operationResult = new ZOperationResult();
            
            try
            {
                PlaylistTrackDTO playlistTrackDTO = Application.GetById(operationResult, new object[] { playlistId, trackId });    
                if (playlistTrackDTO != null)
                {
                    if (Application.Delete(operationResult, playlistTrackDTO))
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

        // GET: api/playlistTrackapi
        public IHttpActionResult GetPlaylistTracks()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                return Ok<IEnumerable<PlaylistTrackDTO>>(Application.Select(operationResult,
                    null, null, (null as int?), AppDefaults.SyncfusionRecordsBySearch));
                //return Ok<IEnumerable<PlaylistTrackDTO>>(Application.SelectAll(operationResult));
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // GET: api/playlistTrackapi/1
        [Route("api/playlistTrackapi/{playlistId}/{trackId}")]
        public IHttpActionResult GetPlaylistTrack(int playlistId, int trackId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                PlaylistTrackDTO playlistTrackDTO = Application.GetById(operationResult, new object[] { playlistId, trackId });   
                if (playlistTrackDTO != null)
                {
                    return Ok(playlistTrackDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // POST: api/playlistTrackapi
        public IHttpActionResult PostPlaylistTrack(PlaylistTrackDTO playlistTrackDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsValid(operationResult, playlistTrackDTO))
                {
                    if (Application.Create(operationResult, playlistTrackDTO))
                    {
                        return CreatedAtRoute("DefaultApi", new { playlistTrackDTO.PlaylistId, playlistTrackDTO.TrackId }, playlistTrackDTO);
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // PUT: api/playlistTrackapi/1
        [Route("api/playlistTrackapi/{playlistId}/{trackId}")]
        public IHttpActionResult PutPlaylistTrack(int playlistId, int trackId, PlaylistTrackDTO playlistTrackDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsValid(operationResult, playlistTrackDTO))
                {
                    if (Application.Create(operationResult, playlistTrackDTO))
                    {
                        return Ok(playlistTrackDTO);
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
