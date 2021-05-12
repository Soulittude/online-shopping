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


        }
    }
}
