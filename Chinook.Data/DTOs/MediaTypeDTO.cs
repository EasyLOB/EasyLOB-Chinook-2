using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chinook.Data
{
    public partial class MediaTypeDTO : ZDTOBase<MediaTypeDTO, MediaType>
    {
        #region Properties
               
        public virtual int MediaTypeId { get; set; }
               
        public virtual string Name { get; set; }

        #endregion Properties

        #region Methods
        
        public MediaTypeDTO()
        {
            MediaTypeId = LibraryDefaults.Default_Int32;
            Name = null;
            LookupText = null;
        }
        
        public MediaTypeDTO(
            int mediaTypeId,
            string name = null
        )
        {
            MediaTypeId = mediaTypeId;
            Name = name;
            LookupText = null;
        }

        public MediaTypeDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<MediaTypeDTO, MediaType> GetDataSelector()
        {
            return x => new MediaType
            (
                x.MediaTypeId,
                x.Name
            );
        }

        public override Func<MediaType, MediaTypeDTO> GetDTOSelector()
        {
            return x => new MediaTypeDTO
            (
                x.MediaTypeId,
                x.Name
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                MediaType mediaType = (MediaType)data;
                MediaTypeDTO dto = (new List<MediaType> { mediaType })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.LookupText = mediaType.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<MediaTypeDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
