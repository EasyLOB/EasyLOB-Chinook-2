using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class PlaylistTrack
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "PlaylistTrack",
            IsIdentity: false,
            Keys: new string[] { "PlaylistId", "TrackId" },
            Lookup: "TrackId",
            LINQOrderBy: "TrackId",
            LINQWhere: "PlaylistId == @0 && TrackId == @1",
            Associations: new string[]
            {
                    "Playlist",
                    "Track"
            },
            Collections: new Dictionary<string, bool> { },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(true , true ,  50, true , false, "col-md-1", "PlaylistId"),
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "PlaylistLookupText"),
                new ZProfileProperty(true , true ,  50, true , false, "col-md-1", "TrackId"),
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "TrackLookupText")
            }
        );

        #endregion Profile
    }
}
