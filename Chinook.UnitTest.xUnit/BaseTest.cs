using EasyLOB;
using Microsoft.Practices.Unity;

// Install-package xunit.runner.visualstudio

namespace Chinook.UnitTest.xUnit
{
    public class BaseTest
    {
        public void RegisterMappings(UnityContainer container)
        {
            UnityHelperChinook.RegisterMappings(container);

            UnityHelperActivity.RegisterMappings(container);
            UnityHelperAuditTrail.RegisterMappings(container);
            UnityHelperIdentity.RegisterMappings(container);
            UnityHelperLog.RegisterMappings(container);
        }

        public void RegisterMappingsEF(UnityContainer container)
        {
            UnityHelperChinook.RegisterMappingsEF(container);
        }

        public void RegisterMappingsLINQ2DB(UnityContainer container)
        {
            UnityHelperChinook.RegisterMappingsLINQ2DB(container);
        }

        public void RegisterMappingsNH(UnityContainer container)
        {
            UnityHelperChinook.RegisterMappingsNH(container);
        }
    }
}