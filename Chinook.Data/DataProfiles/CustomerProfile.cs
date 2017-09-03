using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Customer
    {
        #region Profile

        public static IZDataProfile DataProfile { get; private set; } = new ZDataProfile
        {
            Class = new ZClassProfile
            (
                Name: "Customer",
                IsIdentity: true,
                Keys: new string[] { "CustomerId" },
                Lookup: "FirstName",
                Associations: new string[]
                {
                    "Employee",
                },
                CollectionsDictionary: new Dictionary<string, bool>
                {
                    { "CustomerDocuments", true },
                    { "Invoices", true }
                },
                LINQOrderBy: "FirstName",
                LINQWhere: "CustomerId == @0"
            ),
            Properties = new List<IZPropertyProfile>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZPropertyProfile(false, true ,  50, false, false, "col-md-1", "CustomerId"),
                new ZPropertyProfile(true , true , 200, true , false, "col-md-4", "FirstName"),
                new ZPropertyProfile(true , true , 200, true , false, "col-md-2", "LastName"),
                new ZPropertyProfile(false, true , 200, true , false, "col-md-4", "Company"),
                new ZPropertyProfile(false, true , 200, true , false, "col-md-4", "Address"),
                new ZPropertyProfile(false, true , 200, true , false, "col-md-4", "City"),
                new ZPropertyProfile(false, true , 200, true , false, "col-md-4", "State"),
                new ZPropertyProfile(false, true , 200, true , false, "col-md-4", "Country"),
                new ZPropertyProfile(false, true , 100, true , false, "col-md-1", "PostalCode"),
                new ZPropertyProfile(false, true , 200, true , false, "col-md-3", "Phone"),
                new ZPropertyProfile(false, true , 200, true , false, "col-md-3", "Fax"),
                new ZPropertyProfile(false, true , 200, true , false, "col-md-4", "Email"),
                new ZPropertyProfile(false, false,  50, true , false, "col-md-1", "SupportRepId"),
                new ZPropertyProfile(true , true , 200, false, false, "col-md-4", "EmployeeLookupText")
            }
        };

        #endregion Profile
    }
}
