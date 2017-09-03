using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class MediaType
    {
        #region Profile

        public static IZDataProfile DataProfile { get; private set; } = new ZDataProfile
        {
            Class = new ZClassProfile
            (
                Name: "MediaType",
                IsIdentity: true,
                Keys: new string[] { "MediaTypeId" },
                Lookup: "Name",
                Associations: new string[] { },
                CollectionsDictionary: new Dictionary<string, bool>
                {
                    { "Tracks", true },
                },
                LINQOrderBy: "Name",
                LINQWhere: "MediaTypeId == @0"
            ),
            Properties = new List<IZPropertyProfile>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZPropertyProfile(false, true ,  50, false, false, "col-md-1", "MediaTypeId"),
                new ZPropertyProfile(true , true , 200, true , false, "col-md-4", "Name")
            }
        };

        #endregion Profile
    }
}
