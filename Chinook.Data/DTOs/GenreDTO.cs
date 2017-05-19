using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chinook.Data
{
    public partial class GenreDTO : ZDTOBase<GenreDTO, Genre>
    {
        #region Properties
               
        public virtual int GenreId { get; set; }
               
        public virtual string Name { get; set; }

        #endregion Properties

        #region Methods
        
        public GenreDTO()
        {
            GenreId = LibraryDefaults.Default_Int32;
            Name = null;
            LookupText = null;
        }
        
        public GenreDTO(
            int genreId,
            string name = null
        )
        {
            GenreId = genreId;
            Name = name;
            LookupText = null;
        }

        public GenreDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<GenreDTO, Genre> GetDataSelector()
        {
            return x => new Genre
            (
                x.GenreId,
                x.Name
            );
        }

        public override Func<Genre, GenreDTO> GetDTOSelector()
        {
            return x => new GenreDTO
            (
                x.GenreId,
                x.Name
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                Genre genre = (Genre)data;
                GenreDTO dto = (new List<Genre> { genre })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.LookupText = genre.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<GenreDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
