using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chinook.Data
{
    public partial class TrackDTO : ZDTOBase<TrackDTO, Track>
    {
        #region Properties
               
        public virtual int TrackId { get; set; }
               
        public virtual string Name { get; set; }
               
        public virtual int? AlbumId { get; set; }
               
        public virtual int MediaTypeId { get; set; }
               
        public virtual int? GenreId { get; set; }
               
        public virtual string Composer { get; set; }
               
        public virtual int Milliseconds { get; set; }
               
        public virtual int? Bytes { get; set; }
               
        public virtual decimal UnitPrice { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string AlbumLookupText { get; set; } // AlbumId

        public virtual string GenreLookupText { get; set; } // GenreId

        public virtual string MediaTypeLookupText { get; set; } // MediaTypeId
    
        #endregion Associations FK

        #region Methods
        
        public TrackDTO()
        {
            TrackId = LibraryDefaults.Default_Int32;
            Name = LibraryDefaults.Default_String;
            MediaTypeId = LibraryDefaults.Default_Int32;
            Milliseconds = LibraryDefaults.Default_Int32;
            UnitPrice = LibraryDefaults.Default_Decimal;
            AlbumId = null;
            GenreId = null;
            Composer = null;
            Bytes = null;
            AlbumLookupText = null;
            GenreLookupText = null;
            MediaTypeLookupText = null;
            LookupText = null;
        }
        
        public TrackDTO(
            int trackId,
            string name,
            int mediaTypeId,
            int milliseconds,
            decimal unitPrice,
            int? albumId = null,
            int? genreId = null,
            string composer = null,
            int? bytes = null,
            string albumLookupText = null,
            string genreLookupText = null,
            string mediaTypeLookupText = null
        )
        {
            TrackId = trackId;
            Name = name;
            AlbumId = albumId;
            MediaTypeId = mediaTypeId;
            GenreId = genreId;
            Composer = composer;
            Milliseconds = milliseconds;
            Bytes = bytes;
            UnitPrice = unitPrice;
            AlbumLookupText = albumLookupText;
            GenreLookupText = genreLookupText;
            MediaTypeLookupText = mediaTypeLookupText;
            LookupText = null;
        }

        public TrackDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<TrackDTO, Track> GetDataSelector()
        {
            return x => new Track
            (
                x.TrackId,
                x.Name,
                x.MediaTypeId,
                x.Milliseconds,
                x.UnitPrice,
                x.AlbumId,
                x.GenreId,
                x.Composer,
                x.Bytes
            );
        }

        public override Func<Track, TrackDTO> GetDTOSelector()
        {
            return x => new TrackDTO
            (
                x.TrackId,
                x.Name,
                x.MediaTypeId,
                x.Milliseconds,
                x.UnitPrice,
                x.AlbumId,
                x.GenreId,
                x.Composer,
                x.Bytes
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                Track track = (Track)data;
                TrackDTO dto = (new List<Track> { track })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.AlbumLookupText = track.Album == null ? null : track.Album.LookupText;
                dto.GenreLookupText = track.Genre == null ? null : track.Genre.LookupText;
                dto.MediaTypeLookupText = track.MediaType == null ? null : track.MediaType.LookupText;
                dto.LookupText = track.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<TrackDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
