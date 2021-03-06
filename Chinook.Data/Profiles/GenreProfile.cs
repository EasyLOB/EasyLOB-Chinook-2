﻿using EasyLOB.Data;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Genre
    {
        #region Profile

        public static IZProfile Profile { get; private set; } = new ZProfile
        (
            Name: "Genre",
            IsIdentity: true,
            Keys: new List<string> { "GenreId" },
            Lookup: "Name",
            LINQOrderBy: "Name",
            LINQWhere: "GenreId == @0",
            Associations: new List<string> { },
            Collections: new Dictionary<string, bool>
            {
                    { "Tracks", true },
            },
            Properties: new List<IZProfileProperty>
            {
                //                   Grd    Grd    Grd  Edt    Edt    Edt
                //                   Vis    Src    Wdt  Vis    RO     CSS         Name
                new ZProfileProperty(false, true ,  50, false, false, "col-md-1", "GenreId"),
                new ZProfileProperty(true , true , 200, true , false, "col-md-4", "Name")
            }
        );

        #endregion Profile
    }
}
