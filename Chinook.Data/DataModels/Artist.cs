using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Artist : ZDataBase
    {        
        #region Properties
        
        public virtual int ArtistId { get; set; }
        
        public virtual string Name { get; set; }

        #endregion Properties

        #region Collections (PK)

        public virtual IList<Album> Albums { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Artist()
        {            
            ArtistId = LibraryDefaults.Default_Int32;
            Name = null;

            Albums = new List<Album>();
    
            OnConstructor();
        }

        public Artist(int artistId)
            : this()
        {            
            ArtistId = artistId;
        }

        public Artist(
            int artistId,
            string name = null
        )
            : this()
        {
            ArtistId = artistId;
            Name = name;
        }

        public override object[] GetId()
        {
            return new object[] { ArtistId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                ArtistId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
