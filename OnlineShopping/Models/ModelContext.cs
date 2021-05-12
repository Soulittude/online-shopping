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
            Database.Migrate();
        }

        public DbSet<Firma> Firmalar { get; set; } //CRUD operations

        public DbSet<Platform> Platformlar { get; set; }

        public DbSet<Dil> Diller { get; set; }

        public DbSet<Tag> Tagler { get; set; }

        public DbSet<Oyun> Oyunlar { get; set; }
    }
}
