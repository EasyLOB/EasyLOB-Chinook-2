using System;

namespace Chinook.Mvc
{
    public partial class InvoiceViewModel
    {
        #region Methods Custom

        public override void OnConstructor() // !!!
        {
            InvoiceDate = DateTime.Today;
        }

        #endregion Methods Custom
    }
}