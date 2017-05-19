﻿using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Genre : ZDataBase
    {        
        #region Properties
        
        public virtual int GenreId { get; set; }
        
        public virtual string Name { get; set; }

        #endregion Properties

        #region Collections (PK)

        public virtual IList<Track> Tracks { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Genre()
        {            
            GenreId = LibraryDefaults.Default_Int32;
            Name = null;

            Tracks = new List<Track>();
    
            OnConstructor();
        }

        public Genre(int genreId)
            : this()
        {            
            GenreId = genreId;
        }

        public Genre(
            int genreId,
            string name = null
        )
            : this()
        {
            GenreId = genreId;
            Name = name;
        }

        public override object[] GetId()
        {
            return new object[] { GenreId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                GenreId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
