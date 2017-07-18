using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class PlaylistCollectionModel : CollectionModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return false; }
        }

        #endregion Properties
        
        #region Methods

        public PlaylistCollectionModel()
            : base()
        {
        }

        public PlaylistCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterControllerAction = masterControllerAction;
        }

        #endregion Methods
    }
}
