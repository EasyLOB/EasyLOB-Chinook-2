using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class PlaylistItemModel : ItemModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return false; }
        }

        public PlaylistViewModel Playlist { get; set; }

        #endregion Properties
        
        #region Methods

        public PlaylistItemModel()
            : base()
        {
            Playlist = new PlaylistViewModel();
        }

        public PlaylistItemModel(ZActivityOperations activityOperations, string controllerAction, PlaylistViewModel playlist = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            Playlist = playlist ?? Playlist;
        }
        
        #endregion Methods
    }
}
