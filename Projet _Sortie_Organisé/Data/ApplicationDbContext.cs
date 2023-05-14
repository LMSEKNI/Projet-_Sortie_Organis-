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
                    .HasOne(e => e.Guide)
                    .WithMany(g => g.evenements)
                    .HasForeignKey(e => e.cin);


            modelBuilder.Entity<Activite>()
                .HasOne(a => a.Ville)
                .WithMany(v => v.Activites)
                .HasForeignKey(a => a.idVille);

            modelBuilder.Entity<Activite>()
                .HasOne(a => a.Event)
                .WithMany(e => e.activities)
                .HasForeignKey(a => a.idEvent);

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
