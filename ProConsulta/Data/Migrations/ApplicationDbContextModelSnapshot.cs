﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProConsulta.Data;

#nullable disable

namespace ProConsulta.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "3363b173-2672-4281-ba10-9ea1d27e4a02",
                            Name = "Atendente",
                            NormalizedName = "ATENDENTE"
                        },
                        new
                        {
                            Id = "3b050464-9dcd-4d8d-81b7-27649f00e4ac",
                            Name = "Medico",
                            NormalizedName = "MEDICO"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "f7a39a6e-5b10-4daf-a580-628b50b6073b",
                            RoleId = "3363b173-2672-4281-ba10-9ea1d27e4a02"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProConsulta.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ProConsulta.Models.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("HoraConsulta")
                        .HasColumnType("time");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("Varchar(250)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Agendamentos", (string)null);
                });

            modelBuilder.Entity("ProConsulta.Models.Especialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Especialidades", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Especialidade médica que trata doenças do sistema cardiovascular.",
                            Nome = "Cardiologia"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Especialidade médica que trata doenças do estômago e intestino.",
                            Nome = "Gastroenterologia"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Especialidade médica que trata doenças do sistema urinário e masculino.",
                            Nome = "Urologia"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Especialidade médica que trata doenças do sistema nervoso.",
                            Nome = "Neurologia"
                        },
                        new
                        {
                            Id = 5,
                            Descricao = "Especialidade médica que trata de crianças e adolescentes.",
                            Nome = "Pediatria"
                        },
                        new
                        {
                            Id = 6,
                            Descricao = "Especialidade médica que trata da pele e suas doenças.",
                            Nome = "Dermatologia"
                        },
                        new
                        {
                            Id = 7,
                            Descricao = "Especialidade médica que trata doenças e distúrbios psicológicos.",
                            Nome = "Psiquiatria"
                        },
                        new
                        {
                            Id = 8,
                            Descricao = "Especialidade médica que trata dos olhos e sua visão.",
                            Nome = "Oftalmologia"
                        },
                        new
                        {
                            Id = 9,
                            Descricao = "Especialidade médica que trata o câncer.",
                            Nome = "Oncologia"
                        },
                        new
                        {
                            Id = 10,
                            Descricao = "Especialidade médica que trata do sistema reprodutor feminino",
                            Nome = "Ginecologia"
                        });
                });

            modelBuilder.Entity("ProConsulta.Models.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("NVarchar(8)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("NVarchar(11)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("NVarchar(11)");

                    b.Property<int>("EspecialidadeId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Documento")
                        .IsUnique();

                    b.HasIndex("EspecialidadeId");

                    b.ToTable("Medicos", (string)null);
                });

            modelBuilder.Entity("ProConsulta.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("NVarchar(11)");

                    b.Property<string>("DataNasicmento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("NVarchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Documento")
                        .IsUnique();

                    b.ToTable("Pacientes", (string)null);
                });

            modelBuilder.Entity("ProConsulta.Models.Atendende", b =>
                {
                    b.HasBaseType("ProConsulta.Data.ApplicationUser");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Atendende");

                    b.HasData(
                        new
                        {
                            Id = "f7a39a6e-5b10-4daf-a580-628b50b6073b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "908297be-c61f-4fa2-8da1-68191661472f",
                            Email = "proconsulta@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "PROCONSULTA@GMAIL.COM",
                            NormalizedUserName = "PROCONSULTA@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAELFfuKMMCcvp33a+Xico7kdxiXmXuW0vxzBekGjRnPS/GmpyM/2KKxQLDJYmm9Bjrg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "43484cf0-acce-464f-ac63-a58762f556e1",
                            TwoFactorEnabled = false,
                            UserName = "PROCONSULTA@GMAIL.COM",
                            Nome = "Pro Consulta"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProConsulta.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProConsulta.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProConsulta.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProConsulta.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProConsulta.Models.Agendamento", b =>
                {
                    b.HasOne("ProConsulta.Models.Medico", "Medico")
                        .WithMany("Agendamentos")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProConsulta.Models.Paciente", "Paciente")
                        .WithMany("Agendamentos")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("ProConsulta.Models.Medico", b =>
                {
                    b.HasOne("ProConsulta.Models.Especialidade", "Especialidade")
                        .WithMany("Medicos")
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Especialidade");
                });

            modelBuilder.Entity("ProConsulta.Models.Especialidade", b =>
                {
                    b.Navigation("Medicos");
                });

            modelBuilder.Entity("ProConsulta.Models.Medico", b =>
                {
                    b.Navigation("Agendamentos");
                });

            modelBuilder.Entity("ProConsulta.Models.Paciente", b =>
                {
                    b.Navigation("Agendamentos");
                });
#pragma warning restore 612, 618
        }
    }
}