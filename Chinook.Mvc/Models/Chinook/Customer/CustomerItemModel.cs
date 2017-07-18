using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class CustomerItemModel : ItemModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return MasterSupportRepId != null; }
        }

        public int? MasterSupportRepId { get; set; }

        public CustomerViewModel Customer { get; set; }

        #endregion Properties
        
        #region Methods

        public CustomerItemModel()
            : base()
        {
            Customer = new CustomerViewModel();
        }

        public CustomerItemModel(ZActivityOperations activityOperations, string controllerAction, int? masterSupportRepId = null, CustomerViewModel customer = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterSupportRepId = masterSupportRepId;
            Customer = customer ?? Customer;
        }
        
        #endregion Methods
    }
}
