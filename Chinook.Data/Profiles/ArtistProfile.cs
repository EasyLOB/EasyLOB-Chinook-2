using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Artist
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "Artist",
            IsIdentity: true,
            Keys: new List<string> { "ArtistId" },
            Lookup: "Name",
            LINQOrderBy: "Name",
            LINQWhere: "ArtistId == @0",
            Associations: new List<string> { },
            Collections: new Dictionary<string, bool>
            {
                    { "Albums", true },
            },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true ,  50, false, false, "col-md-1", "ArtistId"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "Name")
            }
        );

        #endregion Profile
    }
}
