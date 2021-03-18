﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrackLocation.Model;

namespace TrackLocation.Migrations
{
    [DbContext(typeof(TrackLocationContext))]
    partial class TrackLocationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrackLocation.Model.Car", b =>
                {
                    b.Property<long>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CarID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCirculation")
                        .HasColumnType("datetime2");

                    b.Property<long>("FamilyCarId")
                        .HasColumnName("FamilyCarID")
                        .HasColumnType("bigint");

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameCar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberPlace")
                        .HasColumnType("int");

                    b.Property<int>("Puissance")
                        .HasColumnType("int");

                    b.Property<int?>("TotKm")
                        .HasColumnType("int");

                    b.Property<long>("TypeCarId")
                        .HasColumnName("TypeCarID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnName("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("CarId");

                    b.HasIndex("FamilyCarId");

                    b.HasIndex("TypeCarId");

                    b.HasIndex("UserId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("TrackLocation.Model.FamilyCar", b =>
                {
                    b.Property<long>("FamilyCarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FamilyCarID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameFamily")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FamilyCarId");

                    b.ToTable("FamilyCar");
                });

            modelBuilder.Entity("TrackLocation.Model.Location", b =>
                {
                    b.Property<long>("LocationId")
                        .HasColumnName("LocationID")
                        .HasColumnType("bigint");

                    b.Property<long>("CarId")
                        .HasColumnName("CarID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnName("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("LocationId")
                        .HasName("PK__Location__E7FEA47605B8C4E7")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("TrackLocation.Model.Tracks", b =>
                {
                    b.Property<long>("TrackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmbientAirTemp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ENGINE_LOAD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ENGINE_RPM")
                        .HasColumnType("bigint");

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.Property<int>("SPEED")
                        .HasColumnType("int");

                    b.Property<string>("ThrottlePos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("insFuel")
                        .HasColumnType("float");

                    b.Property<double>("latitude")
                        .HasColumnType("float");

                    b.Property<double>("longitude")
                        .HasColumnType("float");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime2");

                    b.Property<double>("valX")
                        .HasColumnType("float");

                    b.Property<double>("valY")
                        .HasColumnType("float");

                    b.Property<double>("valZ")
                        .HasColumnType("float");

                    b.Property<string>("zone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrackID");

                    b.HasIndex("LocationId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("TrackLocation.Model.TypeCar", b =>
                {
                    b.Property<long>("TypeCarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TypeCarID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeCarId");

                    b.ToTable("TypeCar");
                });

            modelBuilder.Entity("TrackLocation.Model.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cin")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<long>("CreatedByAdminID")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("NumPassport")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NumTel")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnName("token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TrackLocation.Model.Car", b =>
                {
                    b.HasOne("TrackLocation.Model.FamilyCar", "FamilyCar")
                        .WithMany()
                        .HasForeignKey("FamilyCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrackLocation.Model.TypeCar", "TypeCar")
                        .WithMany()
                        .HasForeignKey("TypeCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrackLocation.Model.User", "User")
                        .WithMany("Car")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrackLocation.Model.Location", b =>
                {
                    b.HasOne("TrackLocation.Model.Car", "Car")
                        .WithMany("Location")
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK_CAR_LOC")
                        .IsRequired();

                    b.HasOne("TrackLocation.Model.User", "User")
                        .WithMany("Location")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_USER_LOC")
                        .IsRequired();
                });

            modelBuilder.Entity("TrackLocation.Model.Tracks", b =>
                {
                    b.HasOne("TrackLocation.Model.Location", "Location")
                        .WithMany("Tracks")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
