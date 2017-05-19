using Chinook.Data;
using EasyLOB.Persistence;
using System.Linq;

namespace Chinook.Persistence
{
    public class ChinookArtistRepositoryLINQ2DB : ChinookGenericRepositoryLINQ2DB<Artist>
    {
        #region Methods

        public ChinookArtistRepositoryLINQ2DB(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<Artist> Join(IQueryable<Artist> query)
        {
            return
                from artist in query
                select new Artist
                {
                    ArtistId = artist.ArtistId,
                    Name = artist.Name
                };
        }

        #endregion Methods
    }
}

