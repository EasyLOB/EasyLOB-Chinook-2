using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class MediaType
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "MediaType",
            IsIdentity: true,
            Keys: new List<string> { "MediaTypeId" },
            Lookup: "Name",
            LINQOrderBy: "Name",
            LINQWhere: "MediaTypeId == @0",
            Associations: new List<string> { },
            Collections: new Dictionary<string, bool>
            {
                    { "Tracks", true },
            },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true ,  50, false, false, "col-md-1", "MediaTypeId"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "Name")
            }
        );

        #endregion Profile
    }
}
