using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class InvoiceLineCollectionModel : CollectionModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return MasterInvoiceId != null || MasterTrackId != null; }
        }

        public int? MasterInvoiceId { get; set; }

        public int? MasterTrackId { get; set; }

        #endregion Properties
        
        #region Methods

        public InvoiceLineCollectionModel()
            : base()
        {
        }

        public InvoiceLineCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, int? masterInvoiceId = null, int? masterTrackId = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterControllerAction = masterControllerAction;
            MasterInvoiceId = masterInvoiceId;
            MasterTrackId = masterTrackId;
        }

        #endregion Methods
    }
}
