using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class InvoiceLine
    {
        #region Profile

        public static IZDataProfile DataProfile { get; private set; } = new ZDataProfile
        {
            Class = new ZClassProfile
            (
                Name: "InvoiceLine",
                IsIdentity: true,
                Keys: new string[] { "InvoiceLineId" },
                Lookup: "InvoiceId",
                Associations: new string[]
                {
                    "Invoice",
                    "Track"
                },
                CollectionsDictionary: new Dictionary<string, bool> { },
                LINQOrderBy: "InvoiceId",
                LINQWhere: "InvoiceLineId == @0"
            ),
            Properties = new List<IZPropertyProfile>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZPropertyProfile(false, true ,  50, false, false, "col-md-1", "InvoiceLineId"),
                new ZPropertyProfile(false, false,  50, true , false, "col-md-1", "InvoiceId"),
                new ZPropertyProfile(true , true , 200, false, false, "col-md-4", "InvoiceLookupText"),
                new ZPropertyProfile(false, false,  50, true , false, "col-md-1", "TrackId"),
                new ZPropertyProfile(true , true , 200, false, false, "col-md-4", "TrackLookupText"),
                new ZPropertyProfile(true , false, 100, true , false, "col-md-1", "UnitPrice"),
                new ZPropertyProfile(true , false,  50, true , false, "col-md-1", "Quantity")
            }
        };

        #endregion Profile
    }
}
