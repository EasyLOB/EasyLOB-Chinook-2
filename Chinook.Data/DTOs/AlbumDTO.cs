using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chinook.Data
{
    public partial class AlbumDTO : ZDTOBase<AlbumDTO, Album>
    {
        #region Properties
               
        public virtual int AlbumId { get; set; }
               
        public virtual string Title { get; set; }
               
        public virtual int ArtistId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string ArtistLookupText { get; set; } // ArtistId
    
        #endregion Associations FK

        #region Methods
        
        public AlbumDTO()
        {
            AlbumId = LibraryDefaults.Default_Int32;
            Title = LibraryDefaults.Default_String;
            ArtistId = LibraryDefaults.Default_Int32;
            ArtistLookupText = null;
            LookupText = null;
        }
        
        public AlbumDTO(
            int albumId,
            string title,
            int artistId,
            string artistLookupText = null
        )
        {
            AlbumId = albumId;
            Title = title;
            ArtistId = artistId;
            ArtistLookupText = artistLookupText;
            LookupText = null;
        }

        public AlbumDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<AlbumDTO, Album> GetDataSelector()
        {
            return x => new Album
            (
                x.AlbumId,
                x.Title,
                x.ArtistId
            );
        }

        public override Func<Album, AlbumDTO> GetDTOSelector()
        {
            return x => new AlbumDTO
            (
                x.AlbumId,
                x.Title,
                x.ArtistId
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                Album album = (Album)data;
                AlbumDTO dto = (new List<Album> { album })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.ArtistLookupText = album.Artist == null ? null : album.Artist.LookupText;
                dto.LookupText = album.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<AlbumDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
