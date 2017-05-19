using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Invoice : ZDataBase
    {        
        #region Properties
        
        public virtual int InvoiceId { get; set; }
        
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
        
        public virtual DateTime InvoiceDate { get; set; }
        
        public virtual string BillingAddress { get; set; }
        
        public virtual string BillingCity { get; set; }
        
        public virtual string BillingState { get; set; }
        
        public virtual string BillingCountry { get; set; }
        
        public virtual string BillingPostalCode { get; set; }
        
        public virtual decimal Total { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual Customer Customer { get; set; } // CustomerId

        #endregion Associations FK

        #region Collections (PK)

        public virtual IList<InvoiceLine> InvoiceLines { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Invoice()
        {            
            InvoiceId = LibraryDefaults.Default_Int32;
            CustomerId = LibraryDefaults.Default_Int32;
            InvoiceDate = LibraryDefaults.Default_DateTime;
            Total = LibraryDefaults.Default_Decimal;
            BillingAddress = null;
            BillingCity = null;
            BillingState = null;
            BillingCountry = null;
            BillingPostalCode = null;

            //Customer = new Customer();

            InvoiceLines = new List<InvoiceLine>();
    
            OnConstructor();
        }

        public Invoice(int invoiceId)
            : this()
        {            
            InvoiceId = invoiceId;
        }

        public Invoice(
            int invoiceId,
            int customerId,
            DateTime invoiceDate,
            decimal total,
            string billingAddress = null,
            string billingCity = null,
            string billingState = null,
            string billingCountry = null,
            string billingPostalCode = null
        )
            : this()
        {
            InvoiceId = invoiceId;
            CustomerId = customerId;
            InvoiceDate = invoiceDate;
            BillingAddress = billingAddress;
            BillingCity = billingCity;
            BillingState = billingState;
            BillingCountry = billingCountry;
            BillingPostalCode = billingPostalCode;
            Total = total;
        }

        public override object[] GetId()
        {
            return new object[] { InvoiceId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                InvoiceId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
