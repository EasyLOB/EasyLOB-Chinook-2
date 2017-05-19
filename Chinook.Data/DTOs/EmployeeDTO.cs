﻿using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chinook.Data
{
    public partial class EmployeeDTO : ZDTOBase<EmployeeDTO, Employee>
    {
        #region Properties
               
        public virtual int EmployeeId { get; set; }
               
        public virtual string LastName { get; set; }
               
        public virtual string FirstName { get; set; }
               
        public virtual string Title { get; set; }
               
        public virtual int? ReportsTo { get; set; }
               
        public virtual DateTime? BirthDate { get; set; }
               
        public virtual DateTime? HireDate { get; set; }
               
        public virtual string Address { get; set; }
               
        public virtual string City { get; set; }
               
        public virtual string State { get; set; }
               
        public virtual string Country { get; set; }
               
        public virtual string PostalCode { get; set; }
               
        public virtual string Phone { get; set; }
               
        public virtual string Fax { get; set; }
               
        public virtual string Email { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string EmployeeLookupText { get; set; } // ReportsTo
    
        #endregion Associations FK

        #region Methods
        
        public EmployeeDTO()
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
        }
        
        public EmployeeDTO(
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

        public EmployeeDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<EmployeeDTO, Employee> GetDataSelector()
        {
            return x => new Employee
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

        public override Func<Employee, EmployeeDTO> GetDTOSelector()
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

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                Employee employee = (Employee)data;
                EmployeeDTO dto = (new List<Employee> { employee })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.EmployeeLookupText = employee.EmployeeReportsTo == null ? null : employee.EmployeeReportsTo.LookupText;
                dto.LookupText = employee.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<EmployeeDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
