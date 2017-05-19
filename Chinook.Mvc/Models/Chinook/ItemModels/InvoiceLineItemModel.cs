using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class InvoiceLineItemModel : ItemModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return MasterInvoiceId != null || MasterTrackId != null; }
        }

        public int? MasterInvoiceId { get; set; }

        public int? MasterTrackId { get; set; }

        public InvoiceLineViewModel InvoiceLine { get; set; }

        #endregion Properties
        
        #region Methods

        public InvoiceLineItemModel()
            : base()
        {
            InvoiceLine = new InvoiceLineViewModel();
        }

        public InvoiceLineItemModel(ZActivityOperations activityOperations, string controllerAction, int? masterInvoiceId = null, int? masterTrackId = null, InvoiceLineViewModel invoiceLine = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterInvoiceId = masterInvoiceId;
            MasterTrackId = masterTrackId;
            InvoiceLine = invoiceLine ?? InvoiceLine;
        }
        
        #endregion Methods
    }
}
