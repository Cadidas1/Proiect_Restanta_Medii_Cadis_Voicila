﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Restanta_Medii_Cadis_Voicila.Data;

#nullable disable

namespace Proiect_Restanta_Medii_Cadis_Voicila.Migrations
{
    [DbContext(typeof(Proiect_Restanta_Medii_Cadis_VoicilaContext))]
    partial class Proiect_Restanta_Medii_Cadis_VoicilaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_Restanta_Medii_Cadis_Voicila.Models.AgentInchirieri", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AgentInchirieri");
                });

            modelBuilder.Entity("Proiect_Restanta_Medii_Cadis_Voicila.Models.Categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("TipMasina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("Proiect_Restanta_Medii_Cadis_Voicila.Models.CategorieMasina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<int>("MasinaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("MasinaID");

                    b.ToTable("CategorieMasina");
                });

            modelBuilder.Entity("Proiect_Restanta_Medii_Cadis_Voicila.Models.Masina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AgentInchirieriID")
                        .HasColumnType("int");

                    b.Property<DateTime>("AnulFabricarii")
                        .HasColumnType("datetime2");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int?>("ReprezentantaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AgentInchirieriID");

                    b.HasIndex("ReprezentantaID");

                    b.ToTable("Masina");
                });

            modelBuilder.Entity("Proiect_Restanta_Medii_Cadis_Voicila.Models.Reprezentanta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeReprezentanta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Reprezentanta");
                });

            modelBuilder.Entity("Proiect_Restanta_Medii_Cadis_Voicila.Models.CategorieMasina", b =>
                {
                    b.HasOne("Proiect_Restanta_Medii_Cadis_Voicila.Models.Categorie", "Categorie")
                        .WithMany("CategorieMasina")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_Restanta_Medii_Cadis_Voicila.Models.Masina", "Masina")
                        .WithMany("CategoriiMasina")
                        .HasForeignKey("MasinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Masina");
                });

            modelBuilder.Entity("Proiect_Restanta_Medii_Cadis_Voicila.Models.Masina", b =>
                {
                    b.HasOne("Proiect_Restanta_Medii_Cadis_Voicila.Models.AgentInchirieri", "AgentInchirieri")
                        .WithMany()
                        .HasForeignKey("AgentInchirieriID");

                    b.HasOne("Proiect_Restanta_Medii_Cadis_Voicila.Models.Reprezentanta", "Reprezentanta")
                        .WithMany("Masini")
                        .HasForeignKey("ReprezentantaID");

                    b.Navigation("AgentInchirieri");

                    b.Navigation("Reprezentanta");
                });

            modelBuilder.Entity("Proiect_Restanta_Medii_Cadis_Voicila.Models.Categorie", b =>
                {
                    b.Navigation("CategorieMasina");
                });

            modelBuilder.Entity("Proiect_Restanta_Medii_Cadis_Voicila.Models.Masina", b =>
                {
                    b.Navigation("CategoriiMasina");
                });

            modelBuilder.Entity("Proiect_Restanta_Medii_Cadis_Voicila.Models.Reprezentanta", b =>
                {
                    b.Navigation("Masini");
                });
#pragma warning restore 612, 618
        }
    }
}
