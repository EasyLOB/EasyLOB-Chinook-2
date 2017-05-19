using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chinook.Data
{
    public partial class PlaylistDTO : ZDTOBase<PlaylistDTO, Playlist>
    {
        #region Properties
               
        public virtual int PlaylistId { get; set; }
               
        public virtual string Name { get; set; }

        #endregion Properties

        #region Methods
        
        public PlaylistDTO()
        {
            PlaylistId = LibraryDefaults.Default_Int32;
            Name = null;
            LookupText = null;
        }
        
        public PlaylistDTO(
            int playlistId,
            string name = null
        )
        {
            PlaylistId = playlistId;
            Name = name;
            LookupText = null;
        }

        public PlaylistDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<PlaylistDTO, Playlist> GetDataSelector()
        {
            return x => new Playlist
            (
                x.PlaylistId,
                x.Name
            );
        }

        public override Func<Playlist, PlaylistDTO> GetDTOSelector()
        {
            return x => new PlaylistDTO
            (
                x.PlaylistId,
                x.Name
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                Playlist playlist = (Playlist)data;
                PlaylistDTO dto = (new List<Playlist> { playlist })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.LookupText = playlist.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<PlaylistDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
