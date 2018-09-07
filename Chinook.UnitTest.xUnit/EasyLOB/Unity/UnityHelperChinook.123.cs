using Chinook;
using Chinook.Application;
using Chinook.Persistence;
using EasyLOB.Persistence;
using NHibernate;
using Unity;

namespace EasyLOB
{
    public static partial class UnityHelperChinook
    {
        public static void RegisterMappings(IUnityContainer container)
        {
            container.RegisterType(typeof(IChinookGenericApplication<>), typeof(ChinookGenericApplication<>));
            container.RegisterType(typeof(IChinookGenericApplicationDTO<,>), typeof(ChinookGenericApplicationDTO<,>));

            container.RegisterType(typeof(IChinookApplication), typeof(ChinookApplication));
        }

        public static void RegisterMappingsEF(IUnityContainer container)
        {
            container.RegisterType(typeof(IChinookUnitOfWork), typeof(ChinookUnitOfWorkEF));
            container.RegisterType(typeof(IChinookGenericRepository<>), typeof(ChinookGenericRepositoryEF<>));
        }

        public static void RegisterMappingsLINQ2DB(IUnityContainer container)
        {
            container.RegisterType(typeof(IChinookUnitOfWork), typeof(ChinookUnitOfWorkLINQ2DB));
            container.RegisterType(typeof(IChinookGenericRepository<>), typeof(ChinookGenericRepositoryLINQ2DB<>));
        }

        public static void RegisterMappingsNH(IUnityContainer container)
        {
            container.RegisterType(typeof(IChinookUnitOfWork), typeof(ChinookUnitOfWorkNH));
            container.RegisterType(typeof(IChinookGenericRepository<>), typeof(ChinookGenericRepositoryNH<>));
        }
    }
}