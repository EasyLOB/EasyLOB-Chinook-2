using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Artist
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
                        Name: "Artist",
                        IsIdentity: true,
                        Keys: new string[] { "ArtistId" },
                        Lookup: "Name",
                        Associations: new string[] { },
                        CollectionsDictionary: new Dictionary<string, bool>
                        {
                            { "Albums", true },
                        },
                        LINQOrderBy: "Name",
                        LINQWhere: "ArtistId == @0"
                    ),
                    Properties = new List<IZPropertyProfile>
                    {
                        //                   Grd    Grd    Grd  Edt    Edt    Edt
                        //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                        new ZPropertyProfile(false, true ,  50, false, false, "col-md-1", "ArtistId"),
                        new ZPropertyProfile(true , true , 200, true , false, "col-md-4", "Name")
                    }
                };
            }
        }

        #endregion Dictionaries
    }
}
