﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance;

namespace Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200523161914_AddedVerifiedEmailColumn")]
    partial class AddedVerifiedEmailColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.AviationCompany", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("AviationCompany");
                });

            modelBuilder.Entity("Core.Entities.Car", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CostPerDay")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassengerNumber")
                        .HasColumnType("int");

                    b.Property<long?>("RentACarId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ReservedFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReservedTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RentACarId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Core.Entities.Flight", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("AviationCompanyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfChangeovers")
                        .HasColumnType("int");

                    b.Property<double>("TicketPrice")
                        .HasColumnType("float");

                    b.Property<double>("TravelLength")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AviationCompanyId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("Core.Entities.FlightTicket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirplaneSeat")
                        .HasColumnType("int");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<long?>("FlightId")
                        .HasColumnType("bigint");

                    b.Property<string>("TicketOwnerEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("TicketOwnerEmail");

                    b.ToTable("FlightTicket");
                });

            modelBuilder.Entity("Core.Entities.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Core.Entities.Rating", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AviationCompanyId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CarId")
                        .HasColumnType("bigint");

                    b.Property<long?>("FlightId")
                        .HasColumnType("bigint");

                    b.Property<string>("RatingGiverEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long?>("RentACarId")
                        .HasColumnType("bigint");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AviationCompanyId");

                    b.HasIndex("CarId");

                    b.HasIndex("FlightId");

                    b.HasIndex("RatingGiverEmail");

                    b.HasIndex("RentACarId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("Core.Entities.RentACar", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RentACar");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Email");

                    b.HasIndex("UserEmail");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Core.Entities.AviationCompany", b =>
                {
                    b.HasOne("Core.Entities.Location", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Core.Entities.Car", b =>
                {
                    b.HasOne("Core.Entities.RentACar", null)
                        .WithMany("Cars")
                        .HasForeignKey("RentACarId");
                });

            modelBuilder.Entity("Core.Entities.Flight", b =>
                {
                    b.HasOne("Core.Entities.AviationCompany", "AviationCompany")
                        .WithMany("Flights")
                        .HasForeignKey("AviationCompanyId");
                });

            modelBuilder.Entity("Core.Entities.FlightTicket", b =>
                {
                    b.HasOne("Core.Entities.Flight", "Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId");

                    b.HasOne("Core.Entities.User", "TicketOwner")
                        .WithMany()
                        .HasForeignKey("TicketOwnerEmail");
                });

            modelBuilder.Entity("Core.Entities.Rating", b =>
                {
                    b.HasOne("Core.Entities.AviationCompany", null)
                        .WithMany("Ratings")
                        .HasForeignKey("AviationCompanyId");

                    b.HasOne("Core.Entities.Car", null)
                        .WithMany("Ratings")
                        .HasForeignKey("CarId");

                    b.HasOne("Core.Entities.Flight", null)
                        .WithMany("Ratings")
                        .HasForeignKey("FlightId");

                    b.HasOne("Core.Entities.User", "RatingGiver")
                        .WithMany()
                        .HasForeignKey("RatingGiverEmail");

                    b.HasOne("Core.Entities.RentACar", null)
                        .WithMany("Ratings")
                        .HasForeignKey("RentACarId");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.HasOne("Core.Entities.User", null)
                        .WithMany("Friends")
                        .HasForeignKey("UserEmail");
                });
#pragma warning restore 612, 618
        }
    }
}
