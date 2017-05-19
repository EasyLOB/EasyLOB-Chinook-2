using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chinook.Data
{
    public partial class ArtistDTO : ZDTOBase<ArtistDTO, Artist>
    {
        #region Properties
               
        public virtual int ArtistId { get; set; }
               
        public virtual string Name { get; set; }

        #endregion Properties

        #region Methods
        
        public ArtistDTO()
        {
            ArtistId = LibraryDefaults.Default_Int32;
            Name = null;
            LookupText = null;
        }
        
        public ArtistDTO(
            int artistId,
            string name = null
        )
        {
            ArtistId = artistId;
            Name = name;
            LookupText = null;
        }

        public ArtistDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<ArtistDTO, Artist> GetDataSelector()
        {
            return x => new Artist
            (
                x.ArtistId,
                x.Name
            );
        }

        public override Func<Artist, ArtistDTO> GetDTOSelector()
        {
            return x => new ArtistDTO
            (
                x.ArtistId,
                x.Name
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                Artist artist = (Artist)data;
                ArtistDTO dto = (new List<Artist> { artist })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.LookupText = artist.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<ArtistDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
