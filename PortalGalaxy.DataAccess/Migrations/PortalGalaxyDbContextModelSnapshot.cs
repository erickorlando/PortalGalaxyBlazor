﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortalGalaxy.DataAccess;

#nullable disable

namespace PortalGalaxy.DataAccess.Migrations
{
    [DbContext(typeof(PortalGalaxyDbContext))]
    partial class PortalGalaxyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PortalGalaxy.Entities.Alumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Distrito")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInscripcion")
                        .HasColumnType("DATE");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NroDocumento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Alumno");
                });

            modelBuilder.Entity("PortalGalaxy.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Hora")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Estado = true,
                            FechaCreacion = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Hora = new DateTime(2023, 12, 2, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = ".NET"
                        },
                        new
                        {
                            Id = 2,
                            Estado = true,
                            FechaCreacion = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Hora = new DateTime(2023, 12, 2, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Java"
                        },
                        new
                        {
                            Id = 3,
                            Estado = true,
                            FechaCreacion = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Hora = new DateTime(2023, 12, 2, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "AWS"
                        },
                        new
                        {
                            Id = 4,
                            Estado = true,
                            FechaCreacion = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Hora = new DateTime(2023, 12, 2, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Azure"
                        },
                        new
                        {
                            Id = 5,
                            Estado = true,
                            FechaCreacion = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Hora = new DateTime(2023, 12, 2, 23, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Python"
                        });
                });

            modelBuilder.Entity("PortalGalaxy.Entities.Inscripcion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Situacion")
                        .HasColumnType("int");

                    b.Property<int>("TallerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("TallerId");

                    b.ToTable("Inscripcion");
                });

            modelBuilder.Entity("PortalGalaxy.Entities.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NroDocumento")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("NroDocumento");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("PortalGalaxy.Entities.Taller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("DATETIME");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PortadaUrl")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Situacion")
                        .HasColumnType("int");

                    b.Property<string>("TemarioUrl")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("Nombre");

                    b.ToTable("Taller");
                });

            modelBuilder.Entity("PortalGalaxy.Entities.Inscripcion", b =>
                {
                    b.HasOne("PortalGalaxy.Entities.Alumno", "Alumno")
                        .WithMany("Inscripciones")
                        .HasForeignKey("AlumnoId")
                        .IsRequired();

                    b.HasOne("PortalGalaxy.Entities.Taller", "Taller")
                        .WithMany("Inscripciones")
                        .HasForeignKey("TallerId")
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Taller");
                });

            modelBuilder.Entity("PortalGalaxy.Entities.Instructor", b =>
                {
                    b.HasOne("PortalGalaxy.Entities.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("PortalGalaxy.Entities.Taller", b =>
                {
                    b.HasOne("PortalGalaxy.Entities.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .IsRequired();

                    b.HasOne("PortalGalaxy.Entities.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId")
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("PortalGalaxy.Entities.Alumno", b =>
                {
                    b.Navigation("Inscripciones");
                });

            modelBuilder.Entity("PortalGalaxy.Entities.Taller", b =>
                {
                    b.Navigation("Inscripciones");
                });
#pragma warning restore 612, 618
        }
    }
}
