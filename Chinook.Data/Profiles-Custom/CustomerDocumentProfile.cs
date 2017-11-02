using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class CustomerDocument
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "CustomerDocument",
            IsIdentity: true,
            Keys: new string[] { "CustomerDocumentId" },
            Lookup: "Description",
            LINQOrderBy: "Description",
            LINQWhere: "CustomerDocumentId == @0",
            Associations: new string[]
            {
                "Customer",
            },
            Collections: new Dictionary<string, bool> { },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true ,  50, false, false, "col-md-1", "CustomerDocumentId"),
                new ZProfileProperty(false, false,  50, true , false, "col-md-1", "CustomerId"),
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "CustomerLookupText"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "Description"),
                new ZProfileProperty(false, true , 200, true , true , "col-md-4", "FileName"), // !!!
                new ZProfileProperty(true , true , 100, true , true , "col-md-1", "FileAcronym") // !!!
            }
        );

        #endregion Profile
    }
}
