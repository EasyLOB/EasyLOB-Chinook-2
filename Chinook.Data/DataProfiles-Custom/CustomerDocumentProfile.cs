using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class CustomerDocument
    {
        #region Profile

        public static IZDataProfile DataProfile { get; private set; } = new ZDataProfile
        {
            Class = new ZClassProfile
            (
                Name: "CustomerDocument",
                IsIdentity: true,
                Keys: new string[] { "CustomerDocumentId" },
                Lookup: "Description",
                Associations: new string[]
                {
                    "Customer",
                },
                CollectionsDictionary: new Dictionary<string, bool> { },
                LINQOrderBy: "Description",
                LINQWhere: "CustomerDocumentId == @0"
            ),
            Properties = new List<IZPropertyProfile>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZPropertyProfile(false, true ,  50, false, false, "col-md-1", "CustomerDocumentId"),
                new ZPropertyProfile(false, false,  50, true , false, "col-md-1", "CustomerId"),
                new ZPropertyProfile(true , true , 200, false, false, "col-md-4", "CustomerLookupText"),
                new ZPropertyProfile(true , true , 200, true , false, "col-md-4", "Description"),
                new ZPropertyProfile(false, true , 200, true , true , "col-md-4", "FileName"), // !!!
                new ZPropertyProfile(true , true , 100, true , true , "col-md-1", "FileAcronym") // !!!
            }
        };

        #endregion Profile
    }
}
