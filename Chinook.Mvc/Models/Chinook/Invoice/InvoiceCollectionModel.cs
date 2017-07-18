using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class InvoiceCollectionModel : CollectionModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return MasterCustomerId != null; }
        }

        public int? MasterCustomerId { get; set; }

        #endregion Properties
        
        #region Methods

        public InvoiceCollectionModel()
            : base()
        {
        }

        public InvoiceCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, int? masterCustomerId = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterControllerAction = masterControllerAction;
            MasterCustomerId = masterCustomerId;
        }

        #endregion Methods
    }
}
