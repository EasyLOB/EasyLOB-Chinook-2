using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class AlbumItemModel : ItemModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return MasterArtistId != null; }
        }

        public int? MasterArtistId { get; set; }

        public AlbumViewModel Album { get; set; }

        #endregion Properties
        
        #region Methods

        public AlbumItemModel()
            : base()
        {
            Album = new AlbumViewModel();
        }

        public AlbumItemModel(ZActivityOperations activityOperations, string controllerAction, int? masterArtistId = null, AlbumViewModel album = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterArtistId = masterArtistId;
            Album = album ?? Album;
        }
        
        #endregion Methods
    }
}
