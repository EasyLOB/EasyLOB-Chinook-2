using EasyLOB.Persistence;
using EasyLOB.Security;

namespace Chinook.Persistence
{
    public class ChinookUnitOfWorkEF : UnitOfWorkEF, IChinookUnitOfWork
    {
        #region Methods

        public ChinookUnitOfWorkEF(IAuthenticationManager authenticationManager)
            : base(new ChinookDbContext(), authenticationManager)
        {
            //Domain = "Chinook"; // ???

            //ChinookDbContext context = (ChinookDbContext)base.context;
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new ChinookGenericRepositoryEF<TEntity>(this);
                Repositories.Add(typeof(TEntity), repository);
            }

            return Repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
        }
        
        #endregion Methods
    }
}

