using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Identity;
using EasyLOB.Identity.Application;
using EasyLOB.Identity.Data;
using EasyLOB.Library;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chinook.Shell
{
    partial class Program
    {
        private static void ApplicationIdentityDemo()
        {
            Console.WriteLine("\nApplication Identity Demo\n");

            var container = new UnityContainer();
            UnityHelper.RegisterMappings(container);

            ApplicationSecurityData<Role>(container);
            ApplicationSecurityDTO<RoleDTO, Role>(container);

            ApplicationSecurityData<UserClaim>(container);
            ApplicationSecurityDTO<UserClaimDTO, UserClaim>(container);

            ApplicationSecurityData<UserLogin>(container);
            ApplicationSecurityDTO<UserLoginDTO, UserLogin>(container);

            ApplicationSecurityData<UserRole>(container);
            ApplicationSecurityDTO<UserRoleDTO, UserRole>(container);

            ApplicationSecurityData<User>(container);
            ApplicationSecurityDTO<UserDTO, User>(container);
        }

        private static void ApplicationSecurityData<TEntity>(UnityContainer container)
            where TEntity : ZDataBase
        {
            IdentityGenericApplication<TEntity> application =
                (IdentityGenericApplication<TEntity>)container.Resolve<IIdentityGenericApplication<TEntity>>();
            ZOperationResult operationResult = new ZOperationResult();
            IEnumerable<TEntity> enumerable = application.SelectAll(operationResult);
            Console.WriteLine(typeof(TEntity).Name + ": {0}", enumerable.Count());
        }

        private static void ApplicationSecurityDTO<TEntityDTO, TEntity>(UnityContainer container)
            where TEntityDTO : ZDTOBase<TEntityDTO, TEntity>
            where TEntity : ZDataBase
        {
            IdentityGenericApplicationDTO<TEntityDTO, TEntity> application =
                (IdentityGenericApplicationDTO<TEntityDTO, TEntity>)container.Resolve<IIdentityGenericApplicationDTO<TEntityDTO, TEntity>>();
            ZOperationResult operationResult = new ZOperationResult();
            IEnumerable<TEntityDTO> enumerable = application.SelectAll(operationResult);
            Console.WriteLine(typeof(TEntity).Name + "DTO: {0}", enumerable.Count());
        }
    }
}