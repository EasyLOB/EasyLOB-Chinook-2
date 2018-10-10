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
    public class InvoiceLineAPIController : BaseApiControllerApplication<InvoiceLineDTO, InvoiceLine>
    {
        #region Methods

        public InvoiceLineAPIController(IChinookGenericApplicationDTO<InvoiceLineDTO, InvoiceLine> application)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        // DELETE: api/invoiceLineapi/1
        [Route("api/invoiceLineapi/{invoiceLineId}")]
        public IHttpActionResult DeleteInvoiceLine(int invoiceLineId)
        {
            ZOperationResult operationResult = new ZOperationResult();
            
            try
            {
                InvoiceLineDTO invoiceLineDTO = Application.GetById(operationResult, new object[] { invoiceLineId });    
                if (invoiceLineDTO != null)
                {
                    if (Application.Delete(operationResult, invoiceLineDTO))
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

        // GET: api/invoiceLineapi
        public IHttpActionResult GetInvoiceLines()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                return Ok<IEnumerable<InvoiceLineDTO>>(Application.Search(operationResult,
                    null, null, (null as int?), AppDefaults.SyncfusionRecordsBySearch));
                //return Ok<IEnumerable<InvoiceLineDTO>>(Application.SelectAll(operationResult));
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new ZActionResultApi(Request, operationResult);
        }

        // GET: api/invoiceLineapi/1
        [Route("api/invoiceLineapi/{invoiceLineId}")]
        public IHttpActionResult GetInvoiceLine(int invoiceLineId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                InvoiceLineDTO invoiceLineDTO = Application.GetById(operationResult, new object[] { invoiceLineId });   
                if (invoiceLineDTO != null)
                {
                    return Ok(invoiceLineDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new ZActionResultApi(Request, operationResult);
        }

        // POST: api/invoiceLineapi
        public IHttpActionResult PostInvoiceLine(InvoiceLineDTO invoiceLineDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (Application.Create(operationResult, invoiceLineDTO))
                {
                    return CreatedAtRoute("DefaultApi", new { invoiceLineDTO.InvoiceLineId }, invoiceLineDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new ZActionResultApi(Request, operationResult);
        }

        // PUT: api/invoiceLineapi/1
        [Route("api/invoiceLineapi/{invoiceLineId}")]
        public IHttpActionResult PutInvoiceLine(int invoiceLineId, InvoiceLineDTO invoiceLineDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (Application.Create(operationResult, invoiceLineDTO))
                {
                    return Ok(invoiceLineDTO);
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
