using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class CustomerDocument : ZDataBase
    {        
        #region Properties
        
        public virtual int CustomerDocumentId { get; set; }
        
        private int _customerId;
        
        public virtual int CustomerId
        {
            get { return this.Customer == null ? _customerId : this.Customer.CustomerId; }
            set
            {
                _customerId = value;
                Customer = null;
            }
        }
        
        public virtual string Description { get; set; }
        
        public virtual string FileName { get; set; }
        
        public virtual string FileAcronym { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual Customer Customer { get; set; } // CustomerId

        #endregion Associations FK

        #region Methods
        
        public CustomerDocument()
        {            
            CustomerDocumentId = LibraryDefaults.Default_Int32;
            CustomerId = LibraryDefaults.Default_Int32;
            Description = LibraryDefaults.Default_String;
            FileName = LibraryDefaults.Default_String;
            FileAcronym = LibraryDefaults.Default_String;

            //Customer = new Customer();
    
            OnConstructor();
        }

        public CustomerDocument(int customerDocumentId)
            : this()
        {            
            CustomerDocumentId = customerDocumentId;
        }

        public CustomerDocument(
            int customerDocumentId,
            int customerId,
            string description,
            string fileName,
            string fileAcronym
        )
            : this()
        {
            CustomerDocumentId = customerDocumentId;
            CustomerId = customerId;
            Description = description;
            FileName = fileName;
            FileAcronym = fileAcronym;
        }

        public override object[] GetId()
        {
            return new object[] { CustomerDocumentId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                CustomerDocumentId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
