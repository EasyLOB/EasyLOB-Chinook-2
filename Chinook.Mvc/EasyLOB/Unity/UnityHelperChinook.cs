using Chinook;
using Chinook.Application;
using Chinook.Persistence;
using Microsoft.Practices.Unity;

namespace EasyLOB
{
    public static class UnityHelperChinook
    {
        public static void RegisterMappings(IUnityContainer container)
        {
            container.RegisterType(typeof(IChinookApplication), typeof(ChinookApplication), UnityHelper.AppLifetimeManager);

            container.RegisterType(typeof(IChinookGenericApplication<>), typeof(ChinookGenericApplication<>), UnityHelper.AppLifetimeManager);
            container.RegisterType(typeof(IChinookGenericApplicationDTO<,>), typeof(ChinookGenericApplicationDTO<,>), UnityHelper.AppLifetimeManager);

            // Entity Framework
            container.RegisterType(typeof(IChinookUnitOfWork), typeof(ChinookUnitOfWorkEF), UnityHelper.AppLifetimeManager);
            container.RegisterType(typeof(IChinookGenericRepository<>), typeof(ChinookGenericRepositoryEF<>), UnityHelper.AppLifetimeManager);

            // LINQ to DB
            //container.RegisterType(typeof(IChinookUnitOfWork), typeof(ChinookUnitOfWorkLINQ2DB));
            //container.RegisterType(typeof(IChinookGenericRepository<>), typeof(ChinookGenericRepositoryLINQ2DB<>));

            // NHibernate
            //container.RegisterType(typeof(IChinookUnitOfWork), typeof(ChinookUnitOfWorkNH));
            //container.RegisterType(typeof(IChinookGenericRepository<>), typeof(ChinookGenericRepositoryNH<>));
        }
    }
}