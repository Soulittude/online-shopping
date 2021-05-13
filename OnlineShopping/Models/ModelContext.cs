using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {

        }


        public DbSet<Firma> Firmalar { get; set; } //CRUD operations

        public DbSet<Platform> Platformlar { get; set; }

        public DbSet<Dil> Diller { get; set; }

        public DbSet<Tag> Tagler { get; set; }

        public DbSet<Oyun> Oyunlar { get; set; }

        public DbSet<OyunTag> OyunTagleri { get; set; }
        public DbSet<OyunDil> OyunDilleri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>()
                        .HasData(
                         new Platform { Id = 1, Ad = "Windows" },
                         new Platform { Id = 2, Ad = "Linux" },
                         new Platform { Id = 3, Ad = "MacOS" });

            modelBuilder.Entity<Firma>()
                       .HasData(
                        new Firma { Id = 1, Ad = "Ubisoft", Ulke = "Azerbaycan", Website = "www.cum.zone" },
                        new Firma { Id = 2, Ad = "Erzurum Game Studios", Ulke = "Türkiye", Website = "www.erzu.rum" },
                        new Firma { Id = 3, Ad = "Rockstar", Ulke = "Erzincan", Website = "www.rock.star" });

            modelBuilder.Entity<Oyun>()
                        .HasData(
                         new Oyun { Id = 1, Ad = "MM", CikisTarihi = DateTime.Now, Fiyat = 1, FirmaID = 1, PlatformID = 1 },
                         new Oyun { Id = 2, Ad = "a", CikisTarihi = DateTime.Now, Fiyat = 100, FirmaID = 2, PlatformID = 1 },
                         new Oyun { Id = 3, Ad = "x", CikisTarihi = DateTime.Now, Fiyat = 55, FirmaID = 3, PlatformID = 2 },
                         new Oyun { Id = 4, Ad = "d", CikisTarihi = DateTime.Now, Fiyat = 85, FirmaID = 1, PlatformID = 1 },
                         new Oyun { Id = 5, Ad = "ww", CikisTarihi = DateTime.Now, Fiyat = 200, FirmaID = 1, PlatformID = 3 });

            modelBuilder.Entity<Tag>()
                        .HasData(
                         new Tag { Id = 1, Ad = "Co-Op" },
                         new Tag { Id = 2, Ad = "Single" },
                         new Tag { Id = 3, Ad = "Multi" },
                         new Tag { Id = 4, Ad = "Çöp" });

            modelBuilder.Entity<OyunTag>()
                        .HasData(
                         new OyunTag { Id = 1, OyunID = 1, TagID = 2 },
                         new OyunTag { Id = 2, OyunID = 2, TagID = 3 },
                         new OyunTag { Id = 3, OyunID = 1, TagID = 3 },
                         new OyunTag { Id = 4, OyunID = 4, TagID = 1 },
                         new OyunTag { Id = 5, OyunID = 3, TagID = 4 });

            modelBuilder.Entity<Dil>()
                        .HasData(
                         new Dil { Id = 1, Ad = "Kürtçe" },
                         new Dil { Id = 2, Ad = "Zazaca" },
                         new Dil { Id = 3, Ad = "İbranice" },
                         new Dil { Id = 4, Ad = "Lazca" });

            modelBuilder.Entity<OyunDil>()
                        .HasData(
                         new OyunDil { Id = 1, OyunID = 1, DilID = 2 },
                         new OyunDil { Id = 2, OyunID = 2, DilID = 3 },
                         new OyunDil { Id = 3, OyunID = 1, DilID = 3 },
                         new OyunDil { Id = 4, OyunID = 4, DilID = 1 },
                         new OyunDil { Id = 5, OyunID = 3, DilID = 4 });
        }
    }
}
