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
    public partial class CustomerDocumentViewModel : ZViewBase<CustomerDocumentViewModel, CustomerDocumentDTO, CustomerDocument>
    {
        #region Properties
        
        [Display(Name = "PropertyCustomerDocumentId", ResourceType = typeof(CustomerDocumentResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int CustomerDocumentId { get; set; }
        
        [Display(Name = "PropertyCustomerId", ResourceType = typeof(CustomerDocumentResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Range(1, System.Int32.MaxValue, ErrorMessageResourceName = "Range", ErrorMessageResourceType = typeof(DataAnnotationResources))]
        [Required]
        public virtual int CustomerId { get; set; }
        
        [Display(Name = "PropertyDescription", ResourceType = typeof(CustomerDocumentResources))]
        [Required]
        [StringLength(100)]
        public virtual string Description { get; set; }
        
        //[Display(Name = "PropertyFileName", ResourceType = typeof(CustomerDocumentResources))]
        //[Required]
        //[StringLength(100)]
        //public virtual string FileName { get; set; }
        
        //[Display(Name = "PropertyFileAcronym", ResourceType = typeof(CustomerDocumentResources))]
        //[Required]
        //[StringLength(10)]
        //public virtual string FileAcronym { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string CustomerLookupText { get; set; } // CustomerId
    
        #endregion Associations FK

        #region Methods
        
        public CustomerDocumentViewModel()
        {
            CustomerDocumentId = LibraryDefaults.Default_Int32;
            CustomerId = LibraryDefaults.Default_Int32;
            Description = LibraryDefaults.Default_String;
            FileName = LibraryDefaults.Default_String;
            FileAcronym = LibraryDefaults.Default_String;
            CustomerLookupText = null;
            LookupText = null;

            OnConstructor();
        }

        public CustomerDocumentViewModel(
            int customerDocumentId,
            int customerId,
            string description,
            string fileName,
            string fileAcronym,
            string customerLookupText = null
        )
        {
            CustomerDocumentId = customerDocumentId;
            CustomerId = customerId;
            Description = description;
            FileName = fileName;
            FileAcronym = fileAcronym;
            CustomerLookupText = customerLookupText;
            LookupText = null;
        }

        public CustomerDocumentViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public CustomerDocumentViewModel(IZDTOBase<CustomerDocumentDTO, CustomerDocument> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<CustomerDocumentViewModel, CustomerDocumentDTO> GetDTOSelector()
        {
            return x => new CustomerDocumentDTO
            (
                x.CustomerDocumentId,
                x.CustomerId,
                x.Description,
                x.FileName,
                x.FileAcronym
            );
        }

        public override Func<CustomerDocumentDTO, CustomerDocumentViewModel> GetViewSelector()
        {
            return x => new CustomerDocumentViewModel
            (
                x.CustomerDocumentId,
                x.CustomerId,
                x.Description,
                x.FileName,
                x.FileAcronym
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                CustomerDocumentDTO customerDocumentDTO = new CustomerDocumentDTO(data);
                CustomerDocumentViewModel view = (new List<CustomerDocumentDTO> { customerDocumentDTO })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                view.CustomerLookupText = customerDocumentDTO.CustomerLookupText;
                view.LookupText = customerDocumentDTO.LookupText;

                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<CustomerDocumentDTO, CustomerDocument> dto)
        {
            if (dto != null)
            {
                CustomerDocumentDTO customerDocumentDTO = (CustomerDocumentDTO)dto;
                CustomerDocumentViewModel view = (new List<CustomerDocumentDTO> { customerDocumentDTO })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                view.CustomerLookupText = customerDocumentDTO.CustomerLookupText;
                view.LookupText = customerDocumentDTO.LookupText;

                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<CustomerDocumentDTO, CustomerDocument> ToDTO()
        {
            return (new List<CustomerDocumentViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
