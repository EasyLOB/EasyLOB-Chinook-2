using Chinook.Data;
using Chinook.Persistence;
using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Persistence;
using System;

namespace Chinook.Shell
{
    partial class Program
    {
        private static void PersistenceChinookGetByIdDemo()
        {
            Console.WriteLine("\nPersistence Chinook GetById() Demo");

            IUnitOfWork unitOfWork = DIHelper.GetService<IChinookUnitOfWork>();

            GetById<Album>();
            GetById<Artist>();
            GetById<Customer>();
            GetById<Employee>();
            GetById<Genre>();
            GetById<Invoice>();
            GetById<InvoiceLine>();
            GetById<MediaType>();
            GetById<Playlist>();
            GetById<PlaylistTrack>(new object[] { 1, 1 });
            GetById<Track>();
        }

        private static void GetById<TEntity>(object[] ids = null)
            where TEntity : ZDataBase
        {
            IChinookUnitOfWork unitOfWork = DIHelper.GetService<IChinookUnitOfWork>();
            IGenericRepository<TEntity> repository = unitOfWork.GetRepository<TEntity>();

            TEntity entity;
            object[] getByIds;

            getByIds = ids ?? new object[] { 1 };
            entity = repository.GetById(getByIds);
            Console.WriteLine("\n{0}: {1}", typeof(TEntity).Name, (entity == null ? "null" : entity.GetType().Name));

            if (ids == null)
            {
                getByIds = new object[] { 100001 };
                entity = repository.GetById(getByIds);
                Console.WriteLine("{0}: {1}", typeof(TEntity).Name, (entity == null ? "null" : entity.GetType().Name));
            }
        }
    }
}