using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class CustomerDocumentItemModel : ItemModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return MasterCustomerId != null; }
        }

        public int? MasterCustomerId { get; set; }

        public CustomerDocumentViewModel CustomerDocument { get; set; }

        #endregion Properties
        
        #region Methods

        public CustomerDocumentItemModel()
            : base()
        {
            CustomerDocument = new CustomerDocumentViewModel();
        }

        public CustomerDocumentItemModel(ZActivityOperations activityOperations, string controllerAction, int? masterCustomerId = null, CustomerDocumentViewModel customerDocument = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterCustomerId = masterCustomerId;
            CustomerDocument = customerDocument ?? CustomerDocument;
        }
        
        #endregion Methods
    }
}
