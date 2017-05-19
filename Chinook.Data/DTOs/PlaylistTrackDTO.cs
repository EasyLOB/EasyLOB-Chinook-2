using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chinook.Data
{
    public partial class PlaylistTrackDTO : ZDTOBase<PlaylistTrackDTO, PlaylistTrack>
    {
        #region Properties
               
        public virtual int PlaylistId { get; set; }
               
        public virtual int TrackId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string PlaylistLookupText { get; set; } // PlaylistId

        public virtual string TrackLookupText { get; set; } // TrackId
    
        #endregion Associations FK

        #region Methods
        
        public PlaylistTrackDTO()
        {
            PlaylistId = LibraryDefaults.Default_Int32;
            TrackId = LibraryDefaults.Default_Int32;
            PlaylistLookupText = null;
            TrackLookupText = null;
            LookupText = null;
        }
        
        public PlaylistTrackDTO(
            int playlistId,
            int trackId,
            string playlistLookupText = null,
            string trackLookupText = null
        )
        {
            PlaylistId = playlistId;
            TrackId = trackId;
            PlaylistLookupText = playlistLookupText;
            TrackLookupText = trackLookupText;
            LookupText = null;
        }

        public PlaylistTrackDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<PlaylistTrackDTO, PlaylistTrack> GetDataSelector()
        {
            return x => new PlaylistTrack
            (
                x.PlaylistId,
                x.TrackId
            );
        }

        public override Func<PlaylistTrack, PlaylistTrackDTO> GetDTOSelector()
        {
            return x => new PlaylistTrackDTO
            (
                x.PlaylistId,
                x.TrackId
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                PlaylistTrack playlistTrack = (PlaylistTrack)data;
                PlaylistTrackDTO dto = (new List<PlaylistTrack> { playlistTrack })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.PlaylistLookupText = playlistTrack.Playlist == null ? null : playlistTrack.Playlist.LookupText;
                dto.TrackLookupText = playlistTrack.Track == null ? null : playlistTrack.Track.LookupText;
                dto.LookupText = playlistTrack.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<PlaylistTrackDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
