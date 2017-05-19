using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Album : ZDataBase
    {        
        #region Properties
        
        public virtual int AlbumId { get; set; }
        
        public virtual string Title { get; set; }
        
        private int _artistId;
        
        public virtual int ArtistId
        {
            get { return this.Artist == null ? _artistId : this.Artist.ArtistId; }
            set
            {
                _artistId = value;
                Artist = null;
            }
        }

        #endregion Properties

        #region Associations (FK)

        public virtual Artist Artist { get; set; } // ArtistId

        #endregion Associations FK

        #region Collections (PK)

        public virtual IList<Track> Tracks { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Album()
        {            
            AlbumId = LibraryDefaults.Default_Int32;
            Title = LibraryDefaults.Default_String;
            ArtistId = LibraryDefaults.Default_Int32;

            //Artist = new Artist();

            Tracks = new List<Track>();
    
            OnConstructor();
        }

        public Album(int albumId)
            : this()
        {            
            AlbumId = albumId;
        }

        public Album(
            int albumId,
            string title,
            int artistId
        )
            : this()
        {
            AlbumId = albumId;
            Title = title;
            ArtistId = artistId;
        }

        public override object[] GetId()
        {
            return new object[] { AlbumId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                AlbumId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
