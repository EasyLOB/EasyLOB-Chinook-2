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
    public class InvoiceAPIController : BaseApiControllerApplication<InvoiceDTO, Invoice>
    {
        #region Methods

        public InvoiceAPIController(IChinookGenericApplicationDTO<InvoiceDTO, Invoice> application)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        // DELETE: api/invoiceapi/1
        [Route("api/invoiceapi/{invoiceId}")]
        public IHttpActionResult DeleteInvoice(int invoiceId)
        {
            ZOperationResult operationResult = new ZOperationResult();
            
            try
            {
                InvoiceDTO invoiceDTO = Application.GetById(operationResult, new object[] { invoiceId });    
                if (invoiceDTO != null)
                {
                    if (Application.Delete(operationResult, invoiceDTO))
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

        // GET: api/invoiceapi
        public IHttpActionResult GetInvoices()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                return Ok<IEnumerable<InvoiceDTO>>(Application.Search(operationResult,
                    null, null, (null as int?), AppDefaults.SyncfusionRecordsBySearch));
                //return Ok<IEnumerable<InvoiceDTO>>(Application.SelectAll(operationResult));
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // GET: api/invoiceapi/1
        [Route("api/invoiceapi/{invoiceId}")]
        public IHttpActionResult GetInvoice(int invoiceId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                InvoiceDTO invoiceDTO = Application.GetById(operationResult, new object[] { invoiceId });   
                if (invoiceDTO != null)
                {
                    return Ok(invoiceDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // POST: api/invoiceapi
        public IHttpActionResult PostInvoice(InvoiceDTO invoiceDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (Application.Create(operationResult, invoiceDTO))
                {
                    return CreatedAtRoute("DefaultApi", new { invoiceDTO.InvoiceId }, invoiceDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // PUT: api/invoiceapi/1
        [Route("api/invoiceapi/{invoiceId}")]
        public IHttpActionResult PutInvoice(int invoiceId, InvoiceDTO invoiceDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (Application.Create(operationResult, invoiceDTO))
                {
                    return Ok(invoiceDTO);
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
