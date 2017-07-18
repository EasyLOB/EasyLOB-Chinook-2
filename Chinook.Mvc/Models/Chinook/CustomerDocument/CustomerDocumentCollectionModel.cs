using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class CustomerDocumentCollectionModel : CollectionModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return MasterCustomerId != null; }
        }

        public int? MasterCustomerId { get; set; }

        #endregion Properties
        
        #region Methods

        public CustomerDocumentCollectionModel()
            : base()
        {
        }

        public CustomerDocumentCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, int? masterCustomerId = null)
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
