using Chinook;
using Chinook.Application;
using Chinook.Data;
using EasyLOB;
using EasyLOB.Library.AspNet;
using EasyLOB.Mvc;
using EasyLOB.WebApi;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Chinook.WebApi
{
    public class PlaylistAPIController : BaseApiControllerApplication<PlaylistDTO, Playlist>
    {
        #region Methods

        public PlaylistAPIController(IChinookGenericApplicationDTO<PlaylistDTO, Playlist> application)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        // DELETE: api/playlistapi/1
        [Route("api/playlistapi/{playlistId}")]
        public IHttpActionResult DeletePlaylist(int playlistId)
        {
            ZOperationResult operationResult = new ZOperationResult();
            
            try
            {
                PlaylistDTO playlistDTO = Application.GetById(operationResult, new object[] { playlistId });    
                if (playlistDTO != null)
                {
                    if (Application.Delete(operationResult, playlistDTO))
                    {
                        return Ok();
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new ZActionResultApi(Request, operationResult);
        }

        // GET: api/playlistapi
        public IHttpActionResult GetPlaylists()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                return Ok<IEnumerable<PlaylistDTO>>(Application.Search(operationResult,
                    null, null, (null as int?), AppDefaults.SyncfusionRecordsBySearch));
                //return Ok<IEnumerable<PlaylistDTO>>(Application.SelectAll(operationResult));
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new ZActionResultApi(Request, operationResult);
        }

        // GET: api/playlistapi/1
        [Route("api/playlistapi/{playlistId}")]
        public IHttpActionResult GetPlaylist(int playlistId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                PlaylistDTO playlistDTO = Application.GetById(operationResult, new object[] { playlistId });   
                if (playlistDTO != null)
                {
                    return Ok(playlistDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new ZActionResultApi(Request, operationResult);
        }

        // POST: api/playlistapi
        public IHttpActionResult PostPlaylist(PlaylistDTO playlistDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (Application.Create(operationResult, playlistDTO))
                {
                    return CreatedAtRoute("DefaultApi", new { playlistDTO.PlaylistId }, playlistDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new ZActionResultApi(Request, operationResult);
        }

        // PUT: api/playlistapi/1
        [Route("api/playlistapi/{playlistId}")]
        public IHttpActionResult PutPlaylist(int playlistId, PlaylistDTO playlistDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (Application.Create(operationResult, playlistDTO))
                {
                    return Ok(playlistDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new ZActionResultApi(Request, operationResult);
        }

        #endregion Methods REST
    }
}
