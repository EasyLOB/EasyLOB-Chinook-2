using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class ArtistCollectionModel : CollectionModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return false; }
        }

        #endregion Properties
        
        #region Methods

        public ArtistCollectionModel()
            : base()
        {
        }

        public ArtistCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterControllerAction = masterControllerAction;
        }

        #endregion Methods
    }
}
