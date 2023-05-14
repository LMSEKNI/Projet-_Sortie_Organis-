﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projet.Data;

#nullable disable

namespace Projet.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230514123208_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Evenements");
                });

            modelBuilder.Entity("Projet.Models.Activite", b =>
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

            modelBuilder.Entity("Projet.Models.Ville", b =>
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

            modelBuilder.Entity("Projet.Models.Activite", b =>
                {
                    b.HasOne("Evenement", "Event")
                        .WithMany("Activities")
                        .HasForeignKey("idEvent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projet.Models.Ville", "Ville")
                        .WithMany("Activites")
                        .HasForeignKey("idVille")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Ville");
                });

            modelBuilder.Entity("Evenement", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("Projet.Models.Ville", b =>
                {
                    b.Navigation("Activites");
                });
#pragma warning restore 612, 618
        }
    }
}