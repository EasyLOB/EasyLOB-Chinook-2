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
    public partial class ArtistViewModel : ZViewBase<ArtistViewModel, ArtistDTO, Artist>
    {
        #region Properties
        
        [Display(Name = "PropertyArtistId", ResourceType = typeof(ArtistResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int ArtistId { get; set; }
        
        [Display(Name = "PropertyName", ResourceType = typeof(ArtistResources))]
        [StringLength(120)]
        public virtual string Name { get; set; }

        #endregion Properties

        #region Methods
        
        public ArtistViewModel()
        {
            ArtistId = LibraryDefaults.Default_Int32;
            Name = null;
            LookupText = null;

            OnConstructor();
        }

        public ArtistViewModel(
            int artistId,
            string name = null
        )
        {
            ArtistId = artistId;
            Name = name;
            LookupText = null;
        }

        public ArtistViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public ArtistViewModel(IZDTOBase<ArtistDTO, Artist> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<ArtistViewModel, ArtistDTO> GetDTOSelector()
        {
            return x => new ArtistDTO
            (
                x.ArtistId,
                x.Name
            );
        }

        public override Func<ArtistDTO, ArtistViewModel> GetViewSelector()
        {
            return x => new ArtistViewModel
            (
                x.ArtistId,
                x.Name
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                ArtistDTO artistDTO = new ArtistDTO(data);
                ArtistViewModel view = (new List<ArtistDTO> { artistDTO })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                view.LookupText = artistDTO.LookupText;

                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<ArtistDTO, Artist> dto)
        {
            if (dto != null)
            {
                ArtistDTO artistDTO = (ArtistDTO)dto;
                ArtistViewModel view = (new List<ArtistDTO> { artistDTO })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                view.LookupText = artistDTO.LookupText;

                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<ArtistDTO, Artist> ToDTO()
        {
            return (new List<ArtistViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
