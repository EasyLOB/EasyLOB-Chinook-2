using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Identity;
using EasyLOB.Identity.Data;
using EasyLOB.Identity.Persistence;
using EasyLOB.Persistence;
using Microsoft.Practices.Unity;
using System;
using System.Linq;

namespace Chinook.Shell
{
    partial class Program
    {
        private static void PersistenceIdentityDemo()
        {
            Console.WriteLine("\nPersistence Identity Demo\n");

            var container = new UnityContainer();
            UnityHelper.RegisterMappings(container);

            IUnitOfWork unitOfWork = (IUnitOfWork)container.Resolve<IIdentityUnitOfWork>();
            Console.WriteLine(unitOfWork.GetType().FullName + " with " + unitOfWork.DBMS.ToString() + "\n");

            PersistenceSecurityData<Role>(unitOfWork);
            PersistenceSecurityData<UserClaim>(unitOfWork);
            PersistenceSecurityData<UserLogin>(unitOfWork);
            PersistenceSecurityData<UserRole>(unitOfWork);
            PersistenceSecurityData<User>(unitOfWork);
        }

        private static void PersistenceSecurityData<TEntity>(IUnitOfWork unitOfWork)
            where TEntity : ZDataBase
        {
            IGenericRepository<TEntity> repository = unitOfWork.GetRepository<TEntity>();
            TEntity entity = repository.Query().FirstOrDefault();
            Console.WriteLine(typeof(TEntity).Name + ": " + repository.CountAll());
        }
    }
}