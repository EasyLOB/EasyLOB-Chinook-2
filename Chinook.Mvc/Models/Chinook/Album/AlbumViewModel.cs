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
    public partial class AlbumViewModel : ZViewBase<AlbumViewModel, AlbumDTO, Album>
    {
        #region Properties
        
        [Display(Name = "PropertyAlbumId", ResourceType = typeof(AlbumResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int AlbumId { get; set; }
        
        [Display(Name = "PropertyTitle", ResourceType = typeof(AlbumResources))]
        [Required]
        [StringLength(160)]
        public virtual string Title { get; set; }
        
        [Display(Name = "PropertyArtistId", ResourceType = typeof(AlbumResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Range(1, System.Int32.MaxValue, ErrorMessageResourceName = "Range", ErrorMessageResourceType = typeof(DataAnnotationResources))]
        [Required]
        public virtual int ArtistId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string ArtistLookupText { get; set; } // ArtistId
    
        #endregion Associations FK

        #region Methods
        
        public AlbumViewModel()
        {
            AlbumId = LibraryDefaults.Default_Int32;
            Title = LibraryDefaults.Default_String;
            ArtistId = LibraryDefaults.Default_Int32;
            ArtistLookupText = null;
            LookupText = null;

            OnConstructor();
        }

        public AlbumViewModel(
            int albumId,
            string title,
            int artistId,
            string artistLookupText = null
        )
        {
            AlbumId = albumId;
            Title = title;
            ArtistId = artistId;
            ArtistLookupText = artistLookupText;
            LookupText = null;
        }

        public AlbumViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public AlbumViewModel(IZDTOBase<AlbumDTO, Album> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<AlbumViewModel, AlbumDTO> GetDTOSelector()
        {
            return x => new AlbumDTO
            (
                x.AlbumId,
                x.Title,
                x.ArtistId
            );
        }

        public override Func<AlbumDTO, AlbumViewModel> GetViewSelector()
        {
            return x => new AlbumViewModel
            (
                x.AlbumId,
                x.Title,
                x.ArtistId
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                AlbumDTO albumDTO = new AlbumDTO(data);
                AlbumViewModel view = (new List<AlbumDTO> { albumDTO })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                view.ArtistLookupText = albumDTO.ArtistLookupText;
                view.LookupText = albumDTO.LookupText;

                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<AlbumDTO, Album> dto)
        {
            if (dto != null)
            {
                AlbumDTO albumDTO = (AlbumDTO)dto;
                AlbumViewModel view = (new List<AlbumDTO> { albumDTO })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                view.ArtistLookupText = albumDTO.ArtistLookupText;
                view.LookupText = albumDTO.LookupText;

                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<AlbumDTO, Album> ToDTO()
        {
            return (new List<AlbumViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
