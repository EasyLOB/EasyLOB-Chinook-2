using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Customer
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "Customer",
            IsIdentity: true,
            Keys: new List<string> { "CustomerId" },
            Lookup: "FirstName",
            LINQOrderBy: "FirstName",
            LINQWhere: "CustomerId == @0",
            Associations: new List<string>
            {
                    "Employee",
            },
            Collections: new Dictionary<string, bool>
            {
                    { "CustomerDocuments", true },
                    { "Invoices", true }
            },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true ,  50, false, false, "col-md-1", "CustomerId"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "FirstName"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-2", "LastName"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "Company"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "Address"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "City"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "State"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "Country"),
                new ZProfileProperty(false, true , 100, true , false, "col-md-1", "PostalCode"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-3", "Phone"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-3", "Fax"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "Email"),
                new ZProfileProperty(false, false,  50, true , false, "col-md-1", "SupportRepId"),
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "EmployeeLookupText")
            }
        );

        #endregion Profile
    }
}
