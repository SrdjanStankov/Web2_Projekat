﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance;

namespace Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Core.Entities.Branch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("RentACarId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RentACarId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Core.Entities.Car", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BuildDate")
                        .HasColumnType("int");

                    b.Property<double>("CostPerDay")
                        .HasColumnType("float");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassengerNumber")
                        .HasColumnType("int");

                    b.Property<long?>("RentACarId")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RentACarId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Core.Entities.CarReservation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CostForRange")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("From")
                        .HasColumnType("datetime2");

                    b.Property<string>("OwnerEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.Property<long>("ReservedCarId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OwnerEmail");

                    b.HasIndex("ReservedCarId");

                    b.ToTable("CarReservations");
                });

            modelBuilder.Entity("Core.Entities.Flight", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("AviationCompanyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("FromId")
                        .HasColumnType("bigint");

                    b.Property<int>("MaxSeatsPerRow")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(4);

                    b.Property<int>("NumberOfChangeovers")
                        .HasColumnType("int");

                    b.Property<double>("TicketPrice")
                        .HasColumnType("float");

                    b.Property<long?>("ToId")
                        .HasColumnType("bigint");

                    b.Property<double>("TravelLength")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AviationCompanyId");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("Core.Entities.FlightSeat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("FlightId")
                        .HasColumnType("bigint");

                    b.Property<long>("SeatNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("FlightSeats");
                });

            modelBuilder.Entity("Core.Entities.FlightTicket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Accepted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<long>("FlightId")
                        .HasColumnType("bigint");

                    b.Property<long?>("FlightSeatId")
                        .HasColumnType("bigint");

                    b.Property<string>("TicketOwnerEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("FlightSeatId");

                    b.HasIndex("TicketOwnerEmail");

                    b.ToTable("FlightTicket");
                });

            modelBuilder.Entity("Core.Entities.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAviationAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRentACarAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSystemAdmin")
                        .HasColumnType("bit");

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

                    b.Property<double>("Points")
                        .HasColumnType("float");

                    b.Property<bool>("RequirePasswordChange")
                        .HasColumnType("bit");

                    b.HasKey("Email");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Core.Entities.UserFriends", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FriendEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FriendEmail");

                    b.HasIndex("UserEmail");

                    b.ToTable("UserFriends");
                });

            modelBuilder.Entity("Core.Entities.RentACarAdministrator", b =>
                {
                    b.HasBaseType("Core.Entities.User");

                    b.HasDiscriminator().HasValue("RentACarAdministrator");
                });

            modelBuilder.Entity("Core.Entities.SystemAdministrator", b =>
                {
                    b.HasBaseType("Core.Entities.User");

                    b.HasDiscriminator().HasValue("SystemAdministrator");
                });

            modelBuilder.Entity("Core.Entities.AviationCompany", b =>
                {
                    b.HasOne("Core.Entities.Location", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Core.Entities.Branch", b =>
                {
                    b.HasOne("Core.Entities.RentACar", null)
                        .WithMany("Branches")
                        .HasForeignKey("RentACarId");
                });

            modelBuilder.Entity("Core.Entities.Car", b =>
                {
                    b.HasOne("Core.Entities.RentACar", null)
                        .WithMany("Cars")
                        .HasForeignKey("RentACarId");
                });

            modelBuilder.Entity("Core.Entities.CarReservation", b =>
                {
                    b.HasOne("Core.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerEmail");

                    b.HasOne("Core.Entities.Car", "ReservedCar")
                        .WithMany()
                        .HasForeignKey("ReservedCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Flight", b =>
                {
                    b.HasOne("Core.Entities.AviationCompany", "AviationCompany")
                        .WithMany("Flights")
                        .HasForeignKey("AviationCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Location", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("Core.Entities.Location", "To")
                        .WithMany()
                        .HasForeignKey("ToId");
                });

            modelBuilder.Entity("Core.Entities.FlightSeat", b =>
                {
                    b.HasOne("Core.Entities.Flight", "Flight")
                        .WithMany("Seats")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.FlightTicket", b =>
                {
                    b.HasOne("Core.Entities.Flight", "Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.FlightSeat", "FlightSeat")
                        .WithMany()
                        .HasForeignKey("FlightSeatId");

                    b.HasOne("Core.Entities.User", "TicketOwner")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketOwnerEmail");
                });

            modelBuilder.Entity("Core.Entities.Rating", b =>
                {
                    b.HasOne("Core.Entities.AviationCompany", "AviationCompany")
                        .WithMany("Ratings")
                        .HasForeignKey("AviationCompanyId");

                    b.HasOne("Core.Entities.Car", "Car")
                        .WithMany("Ratings")
                        .HasForeignKey("CarId");

                    b.HasOne("Core.Entities.Flight", "Flight")
                        .WithMany("Ratings")
                        .HasForeignKey("FlightId");

                    b.HasOne("Core.Entities.User", "RatingGiver")
                        .WithMany()
                        .HasForeignKey("RatingGiverEmail");

                    b.HasOne("Core.Entities.RentACar", "RentACar")
                        .WithMany("Ratings")
                        .HasForeignKey("RentACarId");
                });

            modelBuilder.Entity("Core.Entities.UserFriends", b =>
                {
                    b.HasOne("Core.Entities.User", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendEmail");

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserEmail");
                });
#pragma warning restore 612, 618
        }
    }
}
