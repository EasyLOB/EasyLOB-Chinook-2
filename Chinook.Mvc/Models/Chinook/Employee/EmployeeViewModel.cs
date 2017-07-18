﻿using Chinook.Data;
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
    public partial class EmployeeViewModel : ZViewBase<EmployeeViewModel, EmployeeDTO, Employee>
    {
        #region Properties
        
        [Display(Name = "PropertyEmployeeId", ResourceType = typeof(EmployeeResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int EmployeeId { get; set; }
        
        [Display(Name = "PropertyLastName", ResourceType = typeof(EmployeeResources))]
        [Required]
        [StringLength(20)]
        public virtual string LastName { get; set; }
        
        [Display(Name = "PropertyFirstName", ResourceType = typeof(EmployeeResources))]
        [Required]
        [StringLength(20)]
        public virtual string FirstName { get; set; }
        
        [Display(Name = "PropertyTitle", ResourceType = typeof(EmployeeResources))]
        [StringLength(30)]
        public virtual string Title { get; set; }
        
        [Display(Name = "PropertyReportsTo", ResourceType = typeof(EmployeeResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual int? ReportsTo { get; set; }
        
        [Display(Name = "PropertyBirthDate", ResourceType = typeof(EmployeeResources))]
        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public virtual DateTime? BirthDate { get; set; }
        
        [Display(Name = "PropertyHireDate", ResourceType = typeof(EmployeeResources))]
        //[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}", ApplyFormatInEditMode = true)]
        public virtual DateTime? HireDate { get; set; }
        
        [Display(Name = "PropertyAddress", ResourceType = typeof(EmployeeResources))]
        [StringLength(70)]
        public virtual string Address { get; set; }
        
        [Display(Name = "PropertyCity", ResourceType = typeof(EmployeeResources))]
        [StringLength(40)]
        public virtual string City { get; set; }
        
        [Display(Name = "PropertyState", ResourceType = typeof(EmployeeResources))]
        [StringLength(40)]
        public virtual string State { get; set; }
        
        [Display(Name = "PropertyCountry", ResourceType = typeof(EmployeeResources))]
        [StringLength(40)]
        public virtual string Country { get; set; }
        
        [Display(Name = "PropertyPostalCode", ResourceType = typeof(EmployeeResources))]
        [StringLength(10)]
        public virtual string PostalCode { get; set; }
        
        [Display(Name = "PropertyPhone", ResourceType = typeof(EmployeeResources))]
        [StringLength(24)]
        public virtual string Phone { get; set; }
        
        [Display(Name = "PropertyFax", ResourceType = typeof(EmployeeResources))]
        [StringLength(24)]
        public virtual string Fax { get; set; }
        
        [Display(Name = "PropertyEmail", ResourceType = typeof(EmployeeResources))]
        [StringLength(60)]
        public virtual string Email { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string EmployeeLookupText { get; set; } // ReportsTo
    
        #endregion Associations FK

        #region Methods
        
        public EmployeeViewModel()
        {
            EmployeeId = LibraryDefaults.Default_Int32;
            LastName = LibraryDefaults.Default_String;
            FirstName = LibraryDefaults.Default_String;
            Title = null;
            ReportsTo = null;
            BirthDate = null;
            HireDate = null;
            Address = null;
            City = null;
            State = null;
            Country = null;
            PostalCode = null;
            Phone = null;
            Fax = null;
            Email = null;
            EmployeeLookupText = null;
            LookupText = null;

            OnConstructor();
        }

        public EmployeeViewModel(
            int employeeId,
            string lastName,
            string firstName,
            string title = null,
            int? reportsTo = null,
            DateTime? birthDate = null,
            DateTime? hireDate = null,
            string address = null,
            string city = null,
            string state = null,
            string country = null,
            string postalCode = null,
            string phone = null,
            string fax = null,
            string email = null,
            string employeeLookupText = null
        )
        {
            EmployeeId = employeeId;
            LastName = lastName;
            FirstName = firstName;
            Title = title;
            ReportsTo = reportsTo;
            BirthDate = birthDate;
            HireDate = hireDate;
            Address = address;
            City = city;
            State = state;
            Country = country;
            PostalCode = postalCode;
            Phone = phone;
            Fax = fax;
            Email = email;
            EmployeeLookupText = employeeLookupText;
            LookupText = null;
        }

        public EmployeeViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public EmployeeViewModel(IZDTOBase<EmployeeDTO, Employee> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<EmployeeViewModel, EmployeeDTO> GetDTOSelector()
        {
            return x => new EmployeeDTO
            (
                x.EmployeeId,
                x.LastName,
                x.FirstName,
                x.Title,
                x.ReportsTo,
                x.BirthDate,
                x.HireDate,
                x.Address,
                x.City,
                x.State,
                x.Country,
                x.PostalCode,
                x.Phone,
                x.Fax,
                x.Email
            );
        }

        public override Func<EmployeeDTO, EmployeeViewModel> GetViewSelector()
        {
            return x => new EmployeeViewModel
            (
                x.EmployeeId,
                x.LastName,
                x.FirstName,
                x.Title,
                x.ReportsTo,
                x.BirthDate,
                x.HireDate,
                x.Address,
                x.City,
                x.State,
                x.Country,
                x.PostalCode,
                x.Phone,
                x.Fax,
                x.Email
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                EmployeeDTO employeeDTO = new EmployeeDTO(data);
                EmployeeViewModel view = (new List<EmployeeDTO> { employeeDTO })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                view.EmployeeLookupText = employeeDTO.EmployeeLookupText;
                view.LookupText = employeeDTO.LookupText;

                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<EmployeeDTO, Employee> dto)
        {
            if (dto != null)
            {
                EmployeeDTO employeeDTO = (EmployeeDTO)dto;
                EmployeeViewModel view = (new List<EmployeeDTO> { employeeDTO })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                view.EmployeeLookupText = employeeDTO.EmployeeLookupText;
                view.LookupText = employeeDTO.LookupText;

                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<EmployeeDTO, Employee> ToDTO()
        {
            return (new List<EmployeeViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
