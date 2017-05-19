using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Album
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
                        Name: "Album",
                        IsIdentity: true,
                        Keys: new string[] { "AlbumId" },
                        Lookup: "Title",
                        Associations: new string[]
                        {
                            "Artist",
                        },
                        CollectionsDictionary: new Dictionary<string, bool>
                        {
                            { "Tracks", true },
                        },
                        LINQOrderBy: "Title",
                        LINQWhere: "AlbumId == @0"
                    ),
                    Properties = new List<IZPropertyProfile>
                    {
                        //                   Grd    Grd    Grd  Edt    Edt    Edt
                        //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                        new ZPropertyProfile(false, true ,  50, false, false, "col-md-1", "AlbumId"),
                        new ZPropertyProfile(true , true , 200, true , false, "col-md-4", "Title"),
                        new ZPropertyProfile(false, false,  50, true , false, "col-md-1", "ArtistId"),
                        new ZPropertyProfile(true , true , 200, false, false, "col-md-4", "ArtistLookupText")
                    }
                };
            }
        }

        #endregion Dictionaries
    }
}
