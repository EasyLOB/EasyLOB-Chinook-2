using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Track
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "Track",
            IsIdentity: true,
            Keys: new List<string> { "TrackId" },
            Lookup: "Name",
            LINQOrderBy: "Name",
            LINQWhere: "TrackId == @0",
            Associations: new List<string>
            {
                    "Album",
                    "Genre",
                    "MediaType"
            },
            Collections: new Dictionary<string, bool>
            {
                    { "InvoiceLines", true },
                    { "PlaylistTracks", true }
            },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true ,  50, false, false, "col-md-1", "TrackId"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "Name"),
                new ZProfileProperty(false, false,  50, true , false, "col-md-1", "AlbumId"),
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "AlbumLookupText"),
                new ZProfileProperty(false, false,  50, true , false, "col-md-1", "MediaTypeId"),
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "MediaTypeLookupText"),
                new ZProfileProperty(false, false,  50, true , false, "col-md-1", "GenreId"),
                new ZProfileProperty(true , true , 200, false, false, "col-md-4", "GenreLookupText"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "Composer"),
                new ZProfileProperty(false, false,  50, true , false, "col-md-1", "Milliseconds"),
                new ZProfileProperty(false, false,  50, true , false, "col-md-1", "Bytes"),
                new ZProfileProperty(false, false, 100, true , false, "col-md-1", "UnitPrice")
            }
        );

        #endregion Profile
    }
}
