using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.DTO_s;

namespace WebApplication1.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }
        
        protected DBContext()
        {
        }

        public virtual DbSet<Musician> Musicians { get; set; }
        public virtual DbSet<MusicLabel> MusicLabels { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<Musician_Track> Musician_Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musician>(m =>
           {
               m.HasKey(e => e.IdMusician);
               m.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
               m.Property(e => e.LastName).IsRequired().HasMaxLength(50);
               m.Property(e => e.Nickname).HasMaxLength(20);

               m.HasData(
                   new Musician { IdMusician = 1, FirstName = "Olaf", LastName = "Kurgeberg", Nickname = "Bonez MC" },
                   new Musician { IdMusician = 2, FirstName = "Anna", LastName = "Dabrowska", Nickname = "Anna Dabrowska" }
                   );
           }
                );
            modelBuilder.Entity<MusicLabel>(m =>
            {
                m.HasKey(e => e.IdMusicLabel);
                m.Property(e => e.Name).IsRequired().HasMaxLength(50);

                m.HasData(
                    new MusicLabel { IdMusicLabel = 1, Name = "Atlantic" },
                    new MusicLabel { IdMusicLabel = 2, Name = "4PF" }
                    );
           }
                );
            modelBuilder.Entity<Album>(a =>
            {
                a.HasKey(e => e.IdAlbum);
                a.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                a.Property(e => e.PublishDate).IsRequired();
                a.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);

                a.HasData(
                    new Album { IdAlbum=1, AlbumName="187",PublishDate=DateTime.Now, IdMusicLabel=2},
                    new Album { IdAlbum=2, AlbumName="Kwiaty",PublishDate=DateTime.Now, IdMusicLabel=1}
                    );
           }
                );
            modelBuilder.Entity<Track>(t =>
            {
                t.HasKey(e => e.IdTrack);
                t.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                t.Property(e => e.Duration).IsRequired();
                t.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum);

                t.HasData(
                    new Track { IdTrack=1,TrackName="Kontrollieren",Duration=3.5f,IdMusicAlbum=1},
                    new Track { IdTrack=2,TrackName="Nigdy wiecej nie tancz ze mna",Duration=3.5f,IdMusicAlbum=2}
                    );
           }
                );
            modelBuilder.Entity<Musician_Track>(m =>
            {
                m.HasKey(e => e.IdMusician);
                m.HasKey(e => e.IdTrack);
                m.HasOne(e => e.Musician).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdMusician);
                m.HasOne(e => e.Track).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdTrack);

                m.HasData(
                    new Musician_Track { IdTrack=1,IdMusician=1},
                    new Musician_Track { IdTrack=2,IdMusician=2}
                    );
           }
                );
        }
    }
}
