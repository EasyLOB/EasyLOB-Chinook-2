using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class PlaylistTrackItemModel : ItemModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return MasterPlaylistId != null || MasterTrackId != null; }
        }

        public int? MasterPlaylistId { get; set; }

        public int? MasterTrackId { get; set; }

        public PlaylistTrackViewModel PlaylistTrack { get; set; }

        #endregion Properties
        
        #region Methods

        public PlaylistTrackItemModel()
            : base()
        {
            PlaylistTrack = new PlaylistTrackViewModel();
        }

        public PlaylistTrackItemModel(ZActivityOperations activityOperations, string controllerAction, int? masterPlaylistId = null, int? masterTrackId = null, PlaylistTrackViewModel playlistTrack = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterPlaylistId = masterPlaylistId;
            MasterTrackId = masterTrackId;
            PlaylistTrack = playlistTrack ?? PlaylistTrack;
        }
        
        #endregion Methods
    }
}
