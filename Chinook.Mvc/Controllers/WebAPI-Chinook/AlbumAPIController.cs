﻿using Chinook;
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
    public class AlbumAPIController : BaseApiControllerApplication<AlbumDTO, Album>
    {
        #region Methods

        public AlbumAPIController(IChinookGenericApplicationDTO<AlbumDTO, Album> application)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        // DELETE: api/albumapi/1
        [Route("api/albumapi/{albumId}")]
        public IHttpActionResult DeleteAlbum(int albumId)
        {
            ZOperationResult operationResult = new ZOperationResult();
            
            try
            {
                AlbumDTO albumDTO = Application.GetById(operationResult, new object[] { albumId });    
                if (albumDTO != null)
                {
                    if (Application.Delete(operationResult, albumDTO))
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

        // GET: api/albumapi
        public IHttpActionResult GetAlbums()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                return Ok<IEnumerable<AlbumDTO>>(Application.Search(operationResult,
                    null, null, (null as int?), AppDefaults.SyncfusionRecordsBySearch));
                //return Ok<IEnumerable<AlbumDTO>>(Application.SelectAll(operationResult));
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new ZActionResultApi(Request, operationResult);
        }

        // GET: api/albumapi/1
        [Route("api/albumapi/{albumId}")]
        public IHttpActionResult GetAlbum(int albumId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                AlbumDTO albumDTO = Application.GetById(operationResult, new object[] { albumId });   
                if (albumDTO != null)
                {
                    return Ok(albumDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new ZActionResultApi(Request, operationResult);
        }

        // POST: api/albumapi
        public IHttpActionResult PostAlbum(AlbumDTO albumDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (Application.Create(operationResult, albumDTO))
                {
                    return CreatedAtRoute("DefaultApi", new { albumDTO.AlbumId }, albumDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new ZActionResultApi(Request, operationResult);
        }

        // PUT: api/albumapi/1
        [Route("api/albumapi/{albumId}")]
        public IHttpActionResult PutAlbum(int albumId, AlbumDTO albumDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (Application.Create(operationResult, albumDTO))
                {
                    return Ok(albumDTO);
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
