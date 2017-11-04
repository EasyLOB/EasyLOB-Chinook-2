using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Album
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "Album",
            IsIdentity: true,
            Keys: new List<string> { "AlbumId" },
            Lookup: "Title",
            LINQOrderBy: "Title",
            LINQWhere: "AlbumId == @0",
            Associations: new List<string>
            {
                    "Artist",
            },
            Collections: new Dictionary<string, bool>
            {
                    { "Tracks", true },
            },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true ,  50, false, false, "col-md-1", "AlbumId"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "Title"),
                new ZProfileProperty(false, false,  50, true , false, "col-md-1", "ArtistId"),
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "ArtistLookupText")
            }
        );

        #endregion Profile
    }
}
