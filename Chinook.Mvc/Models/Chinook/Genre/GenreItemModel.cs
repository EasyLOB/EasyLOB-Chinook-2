using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class GenreItemModel : ItemModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return false; }
        }

        public GenreViewModel Genre { get; set; }

        #endregion Properties
        
        #region Methods

        public GenreItemModel()
            : base()
        {
            Genre = new GenreViewModel();
        }

        public GenreItemModel(ZActivityOperations activityOperations, string controllerAction, GenreViewModel genre = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            Genre = genre ?? Genre;
        }
        
        #endregion Methods
    }
}
