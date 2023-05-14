using Microsoft.EntityFrameworkCore;
using Projet__Sortie_Organisé.Models;
using Microsoft.AspNetCore.Mvc;

namespace Projet__Sortie_Organisé.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Ville> Villes { get; set; }
        public DbSet<Activite> Activites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activite>()
                .HasOne(a => a.Event)
                .WithMany(e => e.Activities)
                .HasForeignKey(a => a.idEvent);

            modelBuilder.Entity<Activite>()
                .HasOne(a => a.Ville)
                .WithMany(v => v.Activites)
                .HasForeignKey(a => a.idVille);
        }
    }
}

