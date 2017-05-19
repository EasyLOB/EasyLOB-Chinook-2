using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Track
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
                        Name: "Track",
                        IsIdentity: true,
                        Keys: new string[] { "TrackId" },
                        Lookup: "Name",
                        Associations: new string[]
                        {
                            "Album",
                            "Genre",
                            "MediaType"
                        },
                        CollectionsDictionary: new Dictionary<string, bool>
                        {
                            { "InvoiceLines", true },
                            { "PlaylistTracks", true }
                        },
                        LINQOrderBy: "Name",
                        LINQWhere: "TrackId == @0"
                    ),
                    Properties = new List<IZPropertyProfile>
                    {
                        //                   Grd    Grd    Grd  Edt    Edt    Edt
                        //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                        new ZPropertyProfile(false, true ,  50, false, false, "col-md-1", "TrackId"),
                        new ZPropertyProfile(true , true , 200, true , false, "col-md-4", "Name"),
                        new ZPropertyProfile(false, false,  50, true , false, "col-md-1", "AlbumId"),
                        new ZPropertyProfile(true , true , 200, false, false, "col-md-4", "AlbumLookupText"),
                        new ZPropertyProfile(false, false,  50, true , false, "col-md-1", "MediaTypeId"),
                        new ZPropertyProfile(true , true , 200, false, false, "col-md-4", "MediaTypeLookupText"),
                        new ZPropertyProfile(false, false,  50, true , false, "col-md-1", "GenreId"),
                        new ZPropertyProfile(true , true , 200, false, false, "col-md-4", "GenreLookupText"),
                        new ZPropertyProfile(true , true , 200, true , false, "col-md-4", "Composer"),
                        new ZPropertyProfile(false, false,  50, true , false, "col-md-1", "Milliseconds"),
                        new ZPropertyProfile(false, false,  50, true , false, "col-md-1", "Bytes"),
                        new ZPropertyProfile(false, false, 100, true , false, "col-md-1", "UnitPrice")
                    }
                };
            }
        }

        #endregion Dictionaries
    }
}
