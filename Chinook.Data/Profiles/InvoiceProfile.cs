using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Invoice
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "Invoice",
            IsIdentity: true,
            Keys: new List<string> { "InvoiceId" },
            Lookup: "BillingAddress",
            LINQOrderBy: "BillingAddress",
            LINQWhere: "InvoiceId == @0",
            Associations: new List<string>
            {
                    "Customer",
            },
            Collections: new Dictionary<string, bool>
            {
                    { "InvoiceLines", true },
            },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true ,  50, false, false, "col-md-1", "InvoiceId"),
                new ZProfileProperty(false, false,  50, true , false, "col-md-1", "CustomerId"),
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "CustomerLookupText"),
                new ZProfileProperty(true , false, 200, true , false, "col-md-2", "InvoiceDate"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "BillingAddress"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "BillingCity"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "BillingState"),
                new ZProfileProperty(false, true , 200, true , false, "col-md-4", "BillingCountry"),
                new ZProfileProperty(false, true , 100, true , false, "col-md-1", "BillingPostalCode"),
                new ZProfileProperty(false, false, 100, true , false, "col-md-1", "Total")
            }
        );

        #endregion Profile
    }
}
