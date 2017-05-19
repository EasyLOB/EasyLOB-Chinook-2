﻿using Chinook.Data;
using LinqToDB.Mapping;

namespace Chinook.Persistence
{
    public static partial class ChinookLINQ2DBMap
    {
        public static void MediaTypeMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<MediaType>()
                .HasTableName("MediaType")

                .Property(x => x.MediaTypeId)
                    .IsPrimaryKey()
                    .IsIdentity()
                    .HasColumnName("MediaTypeId")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(false)

                .Property(x => x.Name)
                    .HasColumnName("Name")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(120)
                    .IsNullable(true)

                .Property(x => x.Tracks)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
