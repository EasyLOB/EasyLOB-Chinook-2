using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class CustomerCollectionModel : CollectionModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return MasterSupportRepId != null; }
        }

        public int? MasterSupportRepId { get; set; }

        #endregion Properties
        
        #region Methods

        public CustomerCollectionModel()
            : base()
        {
        }

        public CustomerCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, int? masterSupportRepId = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterControllerAction = masterControllerAction;
            MasterSupportRepId = masterSupportRepId;
        }

        #endregion Methods
    }
}
