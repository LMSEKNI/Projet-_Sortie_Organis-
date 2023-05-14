﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projet__Sortie_Organisé.Data;

#nullable disable

namespace Projet__Sortie_Organisé.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Evenement", b =>
                {
                    b.Property<int>("idEvent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idEvent"), 1L, 1);

                    b.Property<float>("Note")
                        .HasColumnType("real");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cin")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("dateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateFin")
                        .HasColumnType("datetime2");

                    b.Property<string>("descriptionEvent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomEvent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nombreMax")
                        .HasColumnType("int");

                    b.Property<float>("prix")
                        .HasColumnType("real");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idEvent");

                    b.HasIndex("cin");

                    b.ToTable("Evenements");
                });

            modelBuilder.Entity("EvenementUtilisateur", b =>
                {
                    b.Property<int>("evenementsidEvent")
                        .HasColumnType("int");

                    b.Property<string>("utilisateurscin")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("evenementsidEvent", "utilisateurscin");

                    b.HasIndex("utilisateurscin");

                    b.ToTable("EvenementUtilisateur");
                });

            modelBuilder.Entity("Personne", b =>
                {
                    b.Property<string>("cin")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cin");

                    b.ToTable("Personnes");

                    b.HasDiscriminator<string>("type").HasValue("Personne");
                });

            modelBuilder.Entity("Projet__Sortie_Organisé.Models.Activite", b =>
                {
                    b.Property<int>("idActivite")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idActivite"), 1L, 1);

                    b.Property<string>("descriptionAct")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idEvent")
                        .HasColumnType("int");

                    b.Property<int>("idVille")
                        .HasColumnType("int");

                    b.Property<string>("nomActivite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idActivite");

                    b.HasIndex("idEvent");

                    b.HasIndex("idVille");

                    b.ToTable("Activites");
                });

            modelBuilder.Entity("Projet__Sortie_Organisé.Models.Ville", b =>
                {
                    b.Property<int>("idVille")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVille"), 1L, 1);

                    b.Property<string>("codePostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomVille")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idVille");

                    b.ToTable("Villes");
                });

            modelBuilder.Entity("Admin", b =>
                {
                    b.HasBaseType("Personne");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Guide", b =>
                {
                    b.HasBaseType("Personne");

                    b.HasDiscriminator().HasValue("Guide");
                });

            modelBuilder.Entity("Utilisateur", b =>
                {
                    b.HasBaseType("Personne");

                    b.HasDiscriminator().HasValue("Utilisateur");
                });

            modelBuilder.Entity("Evenement", b =>
                {
                    b.HasOne("Guide", "Guide")
                        .WithMany("evenements")
                        .HasForeignKey("cin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guide");
                });

            modelBuilder.Entity("EvenementUtilisateur", b =>
                {
                    b.HasOne("Evenement", null)
                        .WithMany()
                        .HasForeignKey("evenementsidEvent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("utilisateurscin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projet__Sortie_Organisé.Models.Activite", b =>
                {
                    b.HasOne("Evenement", "Event")
                        .WithMany("activities")
                        .HasForeignKey("idEvent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projet__Sortie_Organisé.Models.Ville", "Ville")
                        .WithMany("Activites")
                        .HasForeignKey("idVille")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Ville");
                });

            modelBuilder.Entity("Evenement", b =>
                {
                    b.Navigation("activities");
                });

            modelBuilder.Entity("Projet__Sortie_Organisé.Models.Ville", b =>
                {
                    b.Navigation("Activites");
                });

            modelBuilder.Entity("Guide", b =>
                {
                    b.Navigation("evenements");
                });
#pragma warning restore 612, 618
        }
    }
}
