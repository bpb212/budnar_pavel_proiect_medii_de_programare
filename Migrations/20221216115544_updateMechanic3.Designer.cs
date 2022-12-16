﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using budnar_pavel_proiect_medii_de_programare.Data;

#nullable disable

namespace budnar_pavel_proiect_medii_de_programare.Migrations
{
    [DbContext(typeof(budnar_pavel_proiect_medii_de_programareContext))]
    [Migration("20221216115544_updateMechanic3")]
    partial class updateMechanic3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("budnar_pavel_proiect_medii_de_programare.Models.Driver", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeamID");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("budnar_pavel_proiect_medii_de_programare.Models.Duty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DutyName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID");

                    b.ToTable("Duty");
                });

            modelBuilder.Entity("budnar_pavel_proiect_medii_de_programare.Models.Mechanic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.HasIndex("TeamID");

                    b.ToTable("Mechanic");
                });

            modelBuilder.Entity("budnar_pavel_proiect_medii_de_programare.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("budnar_pavel_proiect_medii_de_programare.Models.RoleDuty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("DutyID")
                        .HasColumnType("int");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DutyID");

                    b.HasIndex("RoleID");

                    b.ToTable("RoleDuty");
                });

            modelBuilder.Entity("budnar_pavel_proiect_medii_de_programare.Models.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("budnar_pavel_proiect_medii_de_programare.Models.Driver", b =>
                {
                    b.HasOne("budnar_pavel_proiect_medii_de_programare.Models.Team", "Team")
                        .WithMany("Drivers")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("budnar_pavel_proiect_medii_de_programare.Models.Mechanic", b =>
                {
                    b.HasOne("budnar_pavel_proiect_medii_de_programare.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("budnar_pavel_proiect_medii_de_programare.Models.Team", "Team")
                        .WithMany("Mechanics")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("budnar_pavel_proiect_medii_de_programare.Models.RoleDuty", b =>
                {
                    b.HasOne("budnar_pavel_proiect_medii_de_programare.Models.Duty", "Duty")
                        .WithMany("RoleDuties")
                        .HasForeignKey("DutyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("budnar_pavel_proiect_medii_de_programare.Models.Role", "Role")
                        .WithMany("RoleDuty")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Duty");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("budnar_pavel_proiect_medii_de_programare.Models.Duty", b =>
                {
                    b.Navigation("RoleDuties");
                });

            modelBuilder.Entity("budnar_pavel_proiect_medii_de_programare.Models.Role", b =>
                {
                    b.Navigation("RoleDuty");
                });

            modelBuilder.Entity("budnar_pavel_proiect_medii_de_programare.Models.Team", b =>
                {
                    b.Navigation("Drivers");

                    b.Navigation("Mechanics");
                });
#pragma warning restore 612, 618
        }
    }
}