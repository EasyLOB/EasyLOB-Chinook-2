using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class PlaylistTrack
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
                        Name: "PlaylistTrack",
                        IsIdentity: false,
                        Keys: new string[] { "PlaylistId", "TrackId" },
                        Lookup: "TrackId",
                        Associations: new string[]
                        {
                            "Playlist",
                            "Track"
                        },
                        CollectionsDictionary: new Dictionary<string, bool> { },
                        LINQOrderBy: "TrackId",
                        LINQWhere: "PlaylistId == @0 && TrackId == @1"
                    ),
                    Properties = new List<IZPropertyProfile>
                    {
                        //                   Grd    Grd    Grd  Edt    Edt    Edt
                        //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                        new ZPropertyProfile(true , true ,  50, true , false, "col-md-1", "PlaylistId"),
                        new ZPropertyProfile(true , true , 200, false, false, "col-md-4", "PlaylistLookupText"),
                        new ZPropertyProfile(true , true ,  50, true , false, "col-md-1", "TrackId"),
                        new ZPropertyProfile(true , true , 200, false, false, "col-md-4", "TrackLookupText")
                    }
                };
            }
        }

        #endregion Dictionaries
    }
}
