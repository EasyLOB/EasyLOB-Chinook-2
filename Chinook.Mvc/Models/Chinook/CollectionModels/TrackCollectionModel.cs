using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class TrackCollectionModel : CollectionModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return MasterAlbumId != null || MasterGenreId != null || MasterMediaTypeId != null; }
        }

        public int? MasterAlbumId { get; set; }

        public int? MasterGenreId { get; set; }

        public int? MasterMediaTypeId { get; set; }

        #endregion Properties
        
        #region Methods

        public TrackCollectionModel()
            : base()
        {
        }

        public TrackCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, int? masterAlbumId = null, int? masterGenreId = null, int? masterMediaTypeId = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterControllerAction = masterControllerAction;
            MasterAlbumId = masterAlbumId;
            MasterGenreId = masterGenreId;
            MasterMediaTypeId = masterMediaTypeId;
        }

        #endregion Methods
    }
}
