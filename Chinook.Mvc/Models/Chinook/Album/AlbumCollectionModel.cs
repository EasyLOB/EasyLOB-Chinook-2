using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class AlbumCollectionModel : CollectionModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return MasterArtistId != null; }
        }

        public int? MasterArtistId { get; set; }

        #endregion Properties
        
        #region Methods

        public AlbumCollectionModel()
            : base()
        {
        }

        public AlbumCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, int? masterArtistId = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterControllerAction = masterControllerAction;
            MasterArtistId = masterArtistId;
        }

        #endregion Methods
    }
}
