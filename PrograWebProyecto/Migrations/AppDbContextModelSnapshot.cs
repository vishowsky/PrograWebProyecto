﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrograWebProyecto.Models;

#nullable disable

namespace PrograWebProyecto.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PrograWebProyecto.Models.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NombreCargo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblCargo");
                });

            modelBuilder.Entity("PrograWebProyecto.Models.Civil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblCivil");
                });

            modelBuilder.Entity("PrograWebProyecto.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblGenero");
                });

            modelBuilder.Entity("PrograWebProyecto.Models.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblTurno");
                });

            modelBuilder.Entity("PrograWebProyecto.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CargoId")
                        .HasColumnType("int");

                    b.Property<int?>("CivilId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int>("IdCargo")
                        .HasColumnType("int");

                    b.Property<int>("IdCivil")
                        .HasColumnType("int");

                    b.Property<int>("IdGenero")
                        .HasColumnType("int");

                    b.Property<int>("IdTurno")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Password")
                        .HasColumnType("int");

                    b.Property<string>("Rut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Telefono")
                        .HasColumnType("int");

                    b.Property<int?>("TurnoId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("CivilId");

                    b.HasIndex("GeneroId");

                    b.HasIndex("TurnoId");

                    b.ToTable("tblUser");
                });

            modelBuilder.Entity("PrograWebProyecto.Models.User", b =>
                {
                    b.HasOne("PrograWebProyecto.Models.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId");

                    b.HasOne("PrograWebProyecto.Models.Civil", "Civil")
                        .WithMany()
                        .HasForeignKey("CivilId");

                    b.HasOne("PrograWebProyecto.Models.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId");

                    b.HasOne("PrograWebProyecto.Models.Turno", "Turno")
                        .WithMany()
                        .HasForeignKey("TurnoId");

                    b.Navigation("Cargo");

                    b.Navigation("Civil");

                    b.Navigation("Genero");

                    b.Navigation("Turno");
                });
#pragma warning restore 612, 618
        }
    }
}