using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class ArtistItemModel : ItemModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return false; }
        }

        public ArtistViewModel Artist { get; set; }

        #endregion Properties
        
        #region Methods

        public ArtistItemModel()
            : base()
        {
            Artist = new ArtistViewModel();
        }

        public ArtistItemModel(ZActivityOperations activityOperations, string controllerAction, ArtistViewModel artist = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            Artist = artist ?? Artist;
        }
        
        #endregion Methods
    }
}
