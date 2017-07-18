using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class PlaylistTrackCollectionModel : CollectionModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return MasterPlaylistId != null || MasterTrackId != null; }
        }

        public int? MasterPlaylistId { get; set; }

        public int? MasterTrackId { get; set; }

        #endregion Properties
        
        #region Methods

        public PlaylistTrackCollectionModel()
            : base()
        {
        }

        public PlaylistTrackCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, int? masterPlaylistId = null, int? masterTrackId = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterControllerAction = masterControllerAction;
            MasterPlaylistId = masterPlaylistId;
            MasterTrackId = masterTrackId;
        }

        #endregion Methods
    }
}
