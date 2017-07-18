using EasyLOB;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class InvoiceItemModel : ItemModel
    {
        #region Properties

        public override bool IsMasterDetail
        {
            get { return MasterCustomerId != null; }
        }

        public int? MasterCustomerId { get; set; }

        public InvoiceViewModel Invoice { get; set; }

        #endregion Properties
        
        #region Methods

        public InvoiceItemModel()
            : base()
        {
            Invoice = new InvoiceViewModel();
        }

        public InvoiceItemModel(ZActivityOperations activityOperations, string controllerAction, int? masterCustomerId = null, InvoiceViewModel invoice = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterCustomerId = masterCustomerId;
            Invoice = invoice ?? Invoice;
        }
        
        #endregion Methods
    }
}
