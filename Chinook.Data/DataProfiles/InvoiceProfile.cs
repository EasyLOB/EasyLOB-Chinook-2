using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Invoice
    {
        #region Dictionaries

        public static IZDataProfile DataProfile
        {
            get
            {
                return new ZDataProfile
                {
                    Class = new ZClassProfile
                    (
                        Name: "Invoice",
                        IsIdentity: true,
                        Keys: new string[] { "InvoiceId" },
                        Lookup: "BillingAddress",
                        Associations: new string[]
                        {
                            "Customer",
                        },
                        CollectionsDictionary: new Dictionary<string, bool>
                        {
                            { "InvoiceLines", true },
                        },
                        LINQOrderBy: "BillingAddress",
                        LINQWhere: "InvoiceId == @0"
                    ),
                    Properties = new List<IZPropertyProfile>
                    {
                        //                   Grd    Grd    Grd  Edt    Edt    Edt
                        //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                        new ZPropertyProfile(false, true ,  50, false, false, "col-md-1", "InvoiceId"),
                        new ZPropertyProfile(false, false,  50, true , false, "col-md-1", "CustomerId"),
                        new ZPropertyProfile(true , true , 200, false, false, "col-md-4", "CustomerLookupText"),
                        new ZPropertyProfile(true , false, 200, true , false, "col-md-2", "InvoiceDate"),
                        new ZPropertyProfile(true , true , 200, true , false, "col-md-4", "BillingAddress"),
                        new ZPropertyProfile(false, true , 200, true , false, "col-md-4", "BillingCity"),
                        new ZPropertyProfile(false, true , 200, true , false, "col-md-4", "BillingState"),
                        new ZPropertyProfile(false, true , 200, true , false, "col-md-4", "BillingCountry"),
                        new ZPropertyProfile(false, true , 100, true , false, "col-md-1", "BillingPostalCode"),
                        new ZPropertyProfile(false, false, 100, true , false, "col-md-1", "Total")
                    }
                };
            }
        }

        #endregion Dictionaries
    }
}
