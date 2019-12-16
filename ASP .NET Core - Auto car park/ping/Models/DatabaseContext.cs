using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ping.Models.DatabaseKlase;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ping.Models
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Auto> Auto { get; set; }
        public DbSet<Nalog> Nalog { get; set; }
        public DbSet<Gorivo> Gorivo { get; set; }
        public DbSet<NalogStatus> NalogStatus { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Auto>().ToTable("Auto");
            modelBuilder.Entity<Nalog>().ToTable("Nalog");
            modelBuilder.Entity<Gorivo>().ToTable("Gorivo");
            modelBuilder.Entity<NalogStatus>().ToTable("NalogStatus");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
