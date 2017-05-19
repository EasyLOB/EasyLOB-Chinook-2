using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Mvc;

namespace Chinook.Mvc
{
    public partial class ChinookTasksController : BaseMvcControllerTask
    {
        #region Properties

        protected IChinookApplication Application { get; }

        protected override string Domain
        {
            get { return AppDefaults.Domain; }
        }

        #endregion Properties

        #region Methods

        public ChinookTasksController(IChinookApplication application)
        {
            Application = application;
        }

        protected override bool IsValid(ZOperationResult operationResult, IZValidatableObject entity)
        {
            bool result = base.IsValid(operationResult, entity);

            if (!result)
            {
                operationResult.Clear(); // Html.BeginForm() + Html.ValidationSummary()
            }

            return result;
        }

        #endregion Methods
    }
}
 