using Chinook;
using Chinook.Application;
using Chinook.Persistence;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupChinook()
        {
            Container.RegisterType(typeof(IChinookApplication), typeof(ChinookApplication), AppLifetimeManager);

            Container.RegisterType(typeof(IChinookGenericApplication<>), typeof(ChinookGenericApplication<>), AppLifetimeManager);
            Container.RegisterType(typeof(IChinookGenericApplicationDTO<,>), typeof(ChinookGenericApplicationDTO<,>), AppLifetimeManager);

            // Entity Framework
            Container.RegisterType(typeof(IChinookUnitOfWork), typeof(ChinookUnitOfWorkEF), AppLifetimeManager);
            Container.RegisterType(typeof(IChinookGenericRepository<>), typeof(ChinookGenericRepositoryEF<>), AppLifetimeManager);

            // LINQ to DB
            //Container.RegisterType(typeof(IChinookUnitOfWork), typeof(ChinookUnitOfWorkLINQ2DB), AppLifetimeManager);
            //Container.RegisterType(typeof(IChinookGenericRepository<>), typeof(ChinookGenericRepositoryLINQ2DB<>), AppLifetimeManager);

            // NHibernate
            //Container.RegisterType(typeof(IChinookUnitOfWork), typeof(ChinookUnitOfWorkNH), AppLifetimeManager);
            //Container.RegisterType(typeof(IChinookGenericRepository<>), typeof(ChinookGenericRepositoryNH<>), AppLifetimeManager);
        }
    }
}