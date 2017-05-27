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
    public class CustomerDocumentAPIController : BaseApiControllerApplication<CustomerDocumentDTO, CustomerDocument>
    {
        #region Methods

        public CustomerDocumentAPIController(IChinookGenericApplicationDTO<CustomerDocumentDTO, CustomerDocument> application)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        // DELETE: api/customerDocumentapi/1
        [Route("api/customerDocumentapi/{customerDocumentId}")]
        public IHttpActionResult DeleteCustomerDocument(int customerDocumentId)
        {
            ZOperationResult operationResult = new ZOperationResult();
            
            try
            {
                CustomerDocumentDTO customerDocumentDTO = Application.GetById(operationResult, new object[] { customerDocumentId });    
                if (customerDocumentDTO != null)
                {
                    if (Application.Delete(operationResult, customerDocumentDTO))
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

        // GET: api/customerDocumentapi
        public IHttpActionResult GetCustomerDocuments()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                return Ok<IEnumerable<CustomerDocumentDTO>>(Application.Select(operationResult,
                    null, null, (null as int?), AppDefaults.SyncfusionRecordsBySearch));
                //return Ok<IEnumerable<CustomerDocumentDTO>>(Application.SelectAll(operationResult));
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // GET: api/customerDocumentapi/1
        [Route("api/customerDocumentapi/{customerDocumentId}")]
        public IHttpActionResult GetCustomerDocument(int customerDocumentId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                CustomerDocumentDTO customerDocumentDTO = Application.GetById(operationResult, new object[] { customerDocumentId });   
                if (customerDocumentDTO != null)
                {
                    return Ok(customerDocumentDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // POST: api/customerDocumentapi
        public IHttpActionResult PostCustomerDocument(CustomerDocumentDTO customerDocumentDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (Application.Create(operationResult, customerDocumentDTO))
                {
                    return CreatedAtRoute("DefaultApi", new { customerDocumentDTO.CustomerDocumentId }, customerDocumentDTO);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return new OperationResultActionResult(Request, operationResult);
        }

        // PUT: api/customerDocumentapi/1
        [Route("api/customerDocumentapi/{customerDocumentId}")]
        public IHttpActionResult PutCustomerDocument(int customerDocumentId, CustomerDocumentDTO customerDocumentDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (Application.Create(operationResult, customerDocumentDTO))
                {
                    return Ok(customerDocumentDTO);
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
