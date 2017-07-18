using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class MediaTypeItemModel : ItemModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return false; }
        }

        public MediaTypeViewModel MediaType { get; set; }

        #endregion Properties
        
        #region Methods

        public MediaTypeItemModel()
            : base()
        {
            MediaType = new MediaTypeViewModel();
        }

        public MediaTypeItemModel(ZActivityOperations activityOperations, string controllerAction, MediaTypeViewModel mediaType = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MediaType = mediaType ?? MediaType;
        }
        
        #endregion Methods
    }
}
