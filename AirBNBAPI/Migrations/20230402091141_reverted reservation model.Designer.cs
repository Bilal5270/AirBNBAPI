﻿// <auto-generated />
using System;
using AirBNBAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirBNBAPI.Migrations
{
    [DbContext(typeof(AirBNBAPIContext))]
    [Migration("20230402091141_reverted reservation model")]
    partial class revertedreservationmodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AirBnb.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Bilal.youssry@gmail.com",
                            FirstName = "Bilal",
                            LastName = "Yousef"
                        },
                        new
                        {
                            Id = 2,
                            Email = "maxmetz8@gmail.com",
                            FirstName = "Max",
                            LastName = "Metz"
                        });
                });

            modelBuilder.Entity("AirBnb.Model.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsCover")
                        .HasColumnType("bit");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Image");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsCover = false,
                            LocationId = 1,
                            Url = "https://dq1eylutsoz4u.cloudfront.net/2019/12/20060024/adult-man-baby-boomer-clean-cut_t20_b8wV6V-800x600-50-year-old-man.jpg"
                        },
                        new
                        {
                            Id = 2,
                            IsCover = false,
                            LocationId = 2,
                            Url = "https://as1.ftcdn.net/v2/jpg/04/70/50/70/1000_F_470507000_FxGToXZnkwPgMYAc5KdX9SvtlYLjPhKf.jpg"
                        },
                        new
                        {
                            Id = 3,
                            IsCover = true,
                            LocationId = 1,
                            Url = "https://www.chr-apartments.com/sites/default/files/styles/tile_image_cropped/public/video_thumbnails/Rwiy-8x8o5w.jpg?itok=X0MqiZeY"
                        },
                        new
                        {
                            Id = 4,
                            IsCover = true,
                            LocationId = 2,
                            Url = "https://www.mapofjoy.nl/wp-content/uploads/2022/11/kasteel-de-haar-mapofjoy.jpg"
                        });
                });

            modelBuilder.Entity("AirBnb.Model.Landlord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("AvatarId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AvatarId")
                        .IsUnique()
                        .HasFilter("[AvatarId] IS NOT NULL");

                    b.ToTable("Landlord");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 55,
                            AvatarId = 1,
                            FirstName = "Herman ",
                            LastName = "Mol"
                        },
                        new
                        {
                            Id = 2,
                            Age = 61,
                            AvatarId = 2,
                            FirstName = "Jaap",
                            LastName = "Keizer"
                        });
                });

            modelBuilder.Entity("AirBnb.Model.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Features")
                        .HasColumnType("int");

                    b.Property<int?>("LandlordId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<float>("PricePerDay")
                        .HasColumnType("real");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LandlordId");

                    b.ToTable("Location");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Mooi huis gelegen in het centrum",
                            Features = 1,
                            LandlordId = 1,
                            NumberOfGuests = 3,
                            PricePerDay = 50.99f,
                            Rooms = 3,
                            SubTitle = "Huis word al jaren goed bevonden door 100+ klanten",
                            Title = "BeeldhouwerKasteel",
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Prachtig kasteel van Nederland",
                            Features = 1,
                            LandlordId = 2,
                            NumberOfGuests = 20,
                            PricePerDay = 500.99f,
                            Rooms = 4,
                            SubTitle = "Prijzig, maar een echte ervaring.",
                            Title = "Kasteel",
                            Type = 5
                        });
                });

            modelBuilder.Entity("AirBnb.Model.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LocationId");

                    b.ToTable("Reservation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            Discount = 0f,
                            EndDate = new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LocationId = 1,
                            StartDate = new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            Discount = 0f,
                            EndDate = new DateTime(2022, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LocationId = 2,
                            StartDate = new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AirBnb.Model.Image", b =>
                {
                    b.HasOne("AirBnb.Model.Location", "Location")
                        .WithMany("Images")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("AirBnb.Model.Landlord", b =>
                {
                    b.HasOne("AirBnb.Model.Image", "Avatar")
                        .WithOne("Landlord")
                        .HasForeignKey("AirBnb.Model.Landlord", "AvatarId");

                    b.Navigation("Avatar");
                });

            modelBuilder.Entity("AirBnb.Model.Location", b =>
                {
                    b.HasOne("AirBnb.Model.Landlord", "Landlord")
                        .WithMany("Locations")
                        .HasForeignKey("LandlordId");

                    b.Navigation("Landlord");
                });

            modelBuilder.Entity("AirBnb.Model.Reservation", b =>
                {
                    b.HasOne("AirBnb.Model.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId");

                    b.HasOne("AirBnb.Model.Location", "Location")
                        .WithMany("Reservations")
                        .HasForeignKey("LocationId");

                    b.Navigation("Customer");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("AirBnb.Model.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("AirBnb.Model.Image", b =>
                {
                    b.Navigation("Landlord");
                });

            modelBuilder.Entity("AirBnb.Model.Landlord", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("AirBnb.Model.Location", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
