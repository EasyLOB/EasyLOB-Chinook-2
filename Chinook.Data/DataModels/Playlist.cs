using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Playlist : ZDataBase
    {        
        #region Properties
        
        public virtual int PlaylistId { get; set; }
        
        public virtual string Name { get; set; }

        #endregion Properties

        #region Collections (PK)

        public virtual IList<PlaylistTrack> PlaylistTracks { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Playlist()
        {            
            PlaylistId = LibraryDefaults.Default_Int32;
            Name = null;

            PlaylistTracks = new List<PlaylistTrack>();
    
            OnConstructor();
        }

        public Playlist(int playlistId)
            : this()
        {            
            PlaylistId = playlistId;
        }

        public Playlist(
            int playlistId,
            string name = null
        )
            : this()
        {
            PlaylistId = playlistId;
            Name = name;
        }

        public override object[] GetId()
        {
            return new object[] { PlaylistId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                PlaylistId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
