using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chinook.Data
{
    public partial class CustomerDocumentDTO : ZDTOBase<CustomerDocumentDTO, CustomerDocument>
    {
        #region Properties
               
        public virtual int CustomerDocumentId { get; set; }
               
        public virtual int CustomerId { get; set; }
               
        public virtual string Description { get; set; }
               
        public virtual string FileName { get; set; }
               
        public virtual string FileAcronym { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string CustomerLookupText { get; set; } // CustomerId
    
        #endregion Associations FK

        #region Methods
        
        public CustomerDocumentDTO()
        {
            CustomerDocumentId = LibraryDefaults.Default_Int32;
            CustomerId = LibraryDefaults.Default_Int32;
            Description = LibraryDefaults.Default_String;
            FileName = LibraryDefaults.Default_String;
            FileAcronym = LibraryDefaults.Default_String;
            CustomerLookupText = null;
            LookupText = null;
        }
        
        public CustomerDocumentDTO(
            int customerDocumentId,
            int customerId,
            string description,
            string fileName,
            string fileAcronym,
            string customerLookupText = null
        )
        {
            CustomerDocumentId = customerDocumentId;
            CustomerId = customerId;
            Description = description;
            FileName = fileName;
            FileAcronym = fileAcronym;
            CustomerLookupText = customerLookupText;
            LookupText = null;
        }

        public CustomerDocumentDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<CustomerDocumentDTO, CustomerDocument> GetDataSelector()
        {
            return x => new CustomerDocument
            (
                x.CustomerDocumentId,
                x.CustomerId,
                x.Description,
                x.FileName,
                x.FileAcronym
            );
        }

        public override Func<CustomerDocument, CustomerDocumentDTO> GetDTOSelector()
        {
            return x => new CustomerDocumentDTO
            (
                x.CustomerDocumentId,
                x.CustomerId,
                x.Description,
                x.FileName,
                x.FileAcronym
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                CustomerDocument customerDocument = (CustomerDocument)data;
                CustomerDocumentDTO dto = (new List<CustomerDocument> { customerDocument })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.CustomerLookupText = customerDocument.Customer == null ? null : customerDocument.Customer.LookupText;
                dto.LookupText = customerDocument.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<CustomerDocumentDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
