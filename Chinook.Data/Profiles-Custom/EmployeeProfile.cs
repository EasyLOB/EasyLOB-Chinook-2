using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Employee
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "Employee",
            IsIdentity: true,
            Keys: new List<string> { "EmployeeId" },
            Lookup: "LastName",
            LINQOrderBy: "LastName",
            LINQWhere: "EmployeeId == @0",
            Associations: new List<string>
            {
                "EmployeeReportsTo",
            },
            Collections: new Dictionary<string, bool>
            {
                { "Customers", true },
                { "Employees", false } // !!!
            },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true ,  50, false, false, "col-md-1", "EmployeeId"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-2", "LastName"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-2", "FirstName"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-3", "Title"),
                new ZProfileProperty(false, false,  50, true , false, "col-md-1", "ReportsTo"),
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "EmployeeLookupText"),
                new ZProfileProperty(false, false, 200, true , false, "col-md-2", "BirthDate"),
                new ZProfileProperty(false, false, 200, true , false, "col-md-2", "HireDate"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "Address"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "City"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "State"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "Country"),
                new ZProfileProperty(false, true , 100, true , false, "col-md-1", "PostalCode"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-3", "Phone"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-3", "Fax"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "Email")
            }
        );

        #endregion Profile
    }
}
