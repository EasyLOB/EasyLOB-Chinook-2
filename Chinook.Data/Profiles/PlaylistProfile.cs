using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Playlist
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "Playlist",
            IsIdentity: true,
            Keys: new string[] { "PlaylistId" },
            Lookup: "Name",
            LINQOrderBy: "Name",
            LINQWhere: "PlaylistId == @0",
            Associations: new string[] { },
            Collections: new Dictionary<string, bool>
            {
                    { "PlaylistTracks", true },
            },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true ,  50, false, false, "col-md-1", "PlaylistId"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "Name")
            }
        );

        #endregion Profile
    }
}
