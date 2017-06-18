using Chinook.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Chinook.Persistence
{
    public class PlaylistTrackConfiguration : EntityTypeConfiguration<PlaylistTrack>
    {
        public PlaylistTrackConfiguration()
        {
            #region Class
            
            this.ToTable("PlaylistTrack");            

            this.HasKey(x => new { x.PlaylistId , x.TrackId });

            #endregion Class

            #region Properties
        
            this.Property(x => x.PlaylistId)
                .HasColumnName("PlaylistId")
                .HasColumnOrder(1)
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();
        
            this.Property(x => x.TrackId)
                .HasColumnName("TrackId")
                .HasColumnOrder(2)
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            #endregion Properties

            #region Associations (FK)
            
            this.HasRequired(x => x.Playlist)
                .WithMany(x => x.PlaylistTracks)
                .HasForeignKey(x => x.PlaylistId);
            
            this.HasRequired(x => x.Track)
                .WithMany(x => x.PlaylistTracks)
                .HasForeignKey(x => x.TrackId);
        
            #endregion Associations (FK)
        }
    }
}
