using EasyLOB.Persistence;
using EasyLOB.Security;

namespace Chinook.Persistence
{
    public class ChinookUnitOfWorkNH : UnitOfWorkNH, IChinookUnitOfWork
    {
        #region Methods
        
        public ChinookUnitOfWorkNH(IAuthenticationManager authenticationManager)
            : base(ChinookFactory.Session, authenticationManager)
        {
            Domain = "Chinook";

            //ISession session = base.Session;
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new ChinookGenericRepositoryNH<TEntity>(this);
                Repositories.Add(typeof(TEntity), repository);
            }

            return Repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
        }
        
        #endregion Methods        
    }
}

