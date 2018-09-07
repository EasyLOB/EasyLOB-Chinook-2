using EasyLOB.Log;
using Unity;

namespace EasyLOB
{
    public static class UnityHelperLog
    {
        public static void RegisterMappings(IUnityContainer container)
        {
            //container.RegisterType(typeof(ILogManager), typeof(LogManagerMock));
            container.RegisterType(typeof(ILogManager), typeof(LogManager));
        }
    }
}