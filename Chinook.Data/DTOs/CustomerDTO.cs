using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chinook.Data
{
    public partial class CustomerDTO : ZDTOBase<CustomerDTO, Customer>
    {
        #region Properties
               
        public virtual int CustomerId { get; set; }
               
        public virtual string FirstName { get; set; }
               
        public virtual string LastName { get; set; }
               
        public virtual string Company { get; set; }
               
        public virtual string Address { get; set; }
               
        public virtual string City { get; set; }
               
        public virtual string State { get; set; }
               
        public virtual string Country { get; set; }
               
        public virtual string PostalCode { get; set; }
               
        public virtual string Phone { get; set; }
               
        public virtual string Fax { get; set; }
               
        public virtual string Email { get; set; }
               
        public virtual int? SupportRepId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string EmployeeLookupText { get; set; } // SupportRepId
    
        #endregion Associations FK

        #region Methods
        
        public CustomerDTO()
        {
            CustomerId = LibraryDefaults.Default_Int32;
            FirstName = LibraryDefaults.Default_String;
            LastName = LibraryDefaults.Default_String;
            Email = LibraryDefaults.Default_String;
            Company = null;
            Address = null;
            City = null;
            State = null;
            Country = null;
            PostalCode = null;
            Phone = null;
            Fax = null;
            SupportRepId = null;
            EmployeeLookupText = null;
            LookupText = null;
        }
        
        public CustomerDTO(
            int customerId,
            string firstName,
            string lastName,
            string email,
            string company = null,
            string address = null,
            string city = null,
            string state = null,
            string country = null,
            string postalCode = null,
            string phone = null,
            string fax = null,
            int? supportRepId = null,
            string employeeLookupText = null
        )
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Company = company;
            Address = address;
            City = city;
            State = state;
            Country = country;
            PostalCode = postalCode;
            Phone = phone;
            Fax = fax;
            Email = email;
            SupportRepId = supportRepId;
            EmployeeLookupText = employeeLookupText;
            LookupText = null;
        }

        public CustomerDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<CustomerDTO, Customer> GetDataSelector()
        {
            return x => new Customer
            (
                x.CustomerId,
                x.FirstName,
                x.LastName,
                x.Email,
                x.Company,
                x.Address,
                x.City,
                x.State,
                x.Country,
                x.PostalCode,
                x.Phone,
                x.Fax,
                x.SupportRepId
            );
        }

        public override Func<Customer, CustomerDTO> GetDTOSelector()
        {
            return x => new CustomerDTO
            (
                x.CustomerId,
                x.FirstName,
                x.LastName,
                x.Email,
                x.Company,
                x.Address,
                x.City,
                x.State,
                x.Country,
                x.PostalCode,
                x.Phone,
                x.Fax,
                x.SupportRepId
            );
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                Customer customer = (Customer)data;
                CustomerDTO dto = (new List<Customer> { customer })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                dto.EmployeeLookupText = customer.Employee == null ? null : customer.Employee.LookupText;
                dto.LookupText = customer.LookupText;

                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<CustomerDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
