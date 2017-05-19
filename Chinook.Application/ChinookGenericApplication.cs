using Chinook.Persistence;
using EasyLOB.Application;
using EasyLOB.Data;

namespace Chinook.Application
{
    public class ChinookGenericApplication<TEntity>
        : GenericApplication<TEntity>, IChinookGenericApplication<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public ChinookGenericApplication(IChinookUnitOfWork unitOfWork, IDIManager diManager)
            : base(unitOfWork, diManager)
            
        {
        }

        #endregion Methods
    }
}