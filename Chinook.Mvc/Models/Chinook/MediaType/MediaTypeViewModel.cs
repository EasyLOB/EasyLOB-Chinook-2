using Chinook.Data;
using Chinook.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Chinook.Mvc
{
    public partial class MediaTypeViewModel : ZViewBase<MediaTypeViewModel, MediaTypeDTO, MediaType>
    {
        #region Properties
        
        [Display(Name = "PropertyMediaTypeId", ResourceType = typeof(MediaTypeResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int MediaTypeId { get; set; }
        
        [Display(Name = "PropertyName", ResourceType = typeof(MediaTypeResources))]
        [StringLength(120)]
        public virtual string Name { get; set; }

        #endregion Properties

        #region Methods
        
        public MediaTypeViewModel()
        {
            MediaTypeId = LibraryDefaults.Default_Int32;
            Name = null;
            LookupText = null;

            OnConstructor();
        }

        public MediaTypeViewModel(
            int mediaTypeId,
            string name = null
        )
        {
            MediaTypeId = mediaTypeId;
            Name = name;
            LookupText = null;
        }

        public MediaTypeViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public MediaTypeViewModel(IZDTOBase<MediaTypeDTO, MediaType> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<MediaTypeViewModel, MediaTypeDTO> GetDTOSelector()
        {
            return x => new MediaTypeDTO
            (
                x.MediaTypeId,
                x.Name
            );
        }

        public override Func<MediaTypeDTO, MediaTypeViewModel> GetViewSelector()
        {
            return x => new MediaTypeViewModel
            (
                x.MediaTypeId,
                x.Name
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                MediaTypeDTO mediaTypeDTO = new MediaTypeDTO(data);
                MediaTypeViewModel view = (new List<MediaTypeDTO> { mediaTypeDTO })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                view.LookupText = mediaTypeDTO.LookupText;

                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<MediaTypeDTO, MediaType> dto)
        {
            if (dto != null)
            {
                MediaTypeDTO mediaTypeDTO = (MediaTypeDTO)dto;
                MediaTypeViewModel view = (new List<MediaTypeDTO> { mediaTypeDTO })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                view.LookupText = mediaTypeDTO.LookupText;

                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<MediaTypeDTO, MediaType> ToDTO()
        {
            return (new List<MediaTypeViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
