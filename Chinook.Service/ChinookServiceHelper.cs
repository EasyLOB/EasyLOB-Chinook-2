using EasyLOB;
using EasyLOB.Log;
using EasyLOB.Resources;
using System;
using Unity;

namespace Chinook.Service
{
    public partial class ChinookServiceHelper
    {
        #region Properties

        private static ILogManager LogManager;

        private static UnityContainer Container = new UnityContainer();

        #endregion Properties

        #region Methods

        static ChinookServiceHelper()
        {
            LogManager = DIHelper.GetService<ILogManager>();
        }

        private static string GetLog(string activity, string description)
        {
            return
                String.Format(PatternResources.DataFormat_DateTime, DateTime.Now.ToString()) +
                " - " + activity +
                (String.IsNullOrEmpty(description) ? "" : ": " + description);
        }

        #endregion Methods
    }
}