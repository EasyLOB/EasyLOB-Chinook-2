using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class TrackItemModel : ItemModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return MasterAlbumId != null || MasterGenreId != null || MasterMediaTypeId != null; }
        }

        public int? MasterAlbumId { get; set; }

        public int? MasterGenreId { get; set; }

        public int? MasterMediaTypeId { get; set; }

        public TrackViewModel Track { get; set; }

        #endregion Properties
        
        #region Methods

        public TrackItemModel()
            : base()
        {
            Track = new TrackViewModel();
        }

        public TrackItemModel(ZActivityOperations activityOperations, string controllerAction, int? masterAlbumId = null, int? masterGenreId = null, int? masterMediaTypeId = null, TrackViewModel track = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterAlbumId = masterAlbumId;
            MasterGenreId = masterGenreId;
            MasterMediaTypeId = masterMediaTypeId;
            Track = track ?? Track;
        }
        
        #endregion Methods
    }
}
