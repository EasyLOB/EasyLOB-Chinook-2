using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class InvoiceLine
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "InvoiceLine",
            IsIdentity: true,
            Keys: new string[] { "InvoiceLineId" },
            Lookup: "InvoiceId",
            LINQOrderBy: "InvoiceId",
            LINQWhere: "InvoiceLineId == @0",
            Associations: new string[]
            {
                    "Invoice",
                    "Track"
            },
            Collections: new Dictionary<string, bool> { },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true ,  50, false, false, "col-md-1", "InvoiceLineId"),
                new ZProfileProperty(false, false,  50, true , false, "col-md-1", "InvoiceId"),
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "InvoiceLookupText"),
                new ZProfileProperty(false, false,  50, true , false, "col-md-1", "TrackId"),
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "TrackLookupText"),
                new ZProfileProperty(true , false, 100, true , false, "col-md-1", "UnitPrice"),
                new ZProfileProperty(true , false,  50, true , false, "col-md-1", "Quantity")
            }
        );

        #endregion Profile
    }
}
