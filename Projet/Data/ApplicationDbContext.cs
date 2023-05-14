using Microsoft.EntityFrameworkCore;
using Projet.Models;
using Microsoft.AspNetCore.Mvc;
using Projet.Models;

namespace Projet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
 public DbSet<Personne> Personnes { get; set; }
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Activite> Activites { get; set; }
        public DbSet<Ville> Villes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personne>()
                .HasDiscriminator<string>("type")
                .HasValue<Utilisateur>("Utilisateur")
                .HasValue<Guide>("Guide")
                .HasValue<Admin>("Admin");

            modelBuilder.Entity<Evenement>()
                .HasOne(e => e.guide)
                .WithMany(g => g.evenements)
                .HasForeignKey(e => e.guideId);

            modelBuilder.Entity<Activite>()
                .HasOne(a => a.Ville)
                .WithMany(v => v.Activites)
                .HasForeignKey(a => a.VilleId);

            modelBuilder.Entity<Activite>()
                .HasOne(a => a.Event)
                .WithMany(e => e.activities)
                .HasForeignKey(a => a.EventId);

            modelBuilder.Entity<Utilisateur>()
                .HasMany(u => u.evenements)
                .WithMany(e => e.utilisateurs);

            modelBuilder.Entity<Personne>()
                .HasKey(p => p.cin);

            modelBuilder.Entity<Evenement>()
                .HasKey(e => e.idEvent);

            modelBuilder.Entity<Activite>()
                .HasKey(a => a.idActivite);

            modelBuilder.Entity<Ville>()
                .HasKey(v => v.idVille);
        }
    }
}

