﻿// <auto-generated />
using System;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CinemaProjectAPI.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    partial class CinemaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BusinessObject.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"), 1L, 1);

                    b.Property<bool>("Baned")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BusinessObject.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"), 1L, 1);

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("BookingId");

                    b.HasIndex("SeatId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BusinessObject.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<bool>("Upcoming")
                        .HasColumnType("bit");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("BusinessObject.MovieShow", b =>
                {
                    b.Property<int>("MovieShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieShowId"), 1L, 1);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("ShowTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheaterHallId")
                        .HasColumnType("int");

                    b.HasKey("MovieShowId");

                    b.HasIndex("MovieId");

                    b.HasIndex("TheaterHallId");

                    b.ToTable("MoviesShows");
                });

            modelBuilder.Entity("BusinessObject.Revenue_statics", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"), 1L, 1);

                    b.Property<int>("TheaterId")
                        .HasColumnType("int");

                    b.Property<double>("TotalMoney")
                        .HasColumnType("float");

                    b.HasKey("SaleId");

                    b.HasIndex("TheaterId");

                    b.ToTable("Revenue_statics");
                });

            modelBuilder.Entity("BusinessObject.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatId"), 1L, 1);

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("TheaterHallId")
                        .HasColumnType("int");

                    b.HasKey("SeatId");

                    b.HasIndex("TheaterHallId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("BusinessObject.Theater", b =>
                {
                    b.Property<int>("TheaterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TheaterId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberTheateHall")
                        .HasColumnType("int");

                    b.Property<string>("TheaterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TheaterId");

                    b.ToTable("Theater");
                });

            modelBuilder.Entity("BusinessObject.TheaterHall", b =>
                {
                    b.Property<int>("TheaterHallId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TheaterHallId"), 1L, 1);

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("TheaterId")
                        .HasColumnType("int");

                    b.Property<string>("TheaterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TheaterHallId");

                    b.HasIndex("TheaterId");

                    b.ToTable("theaterHalls");
                });

            modelBuilder.Entity("BusinessObject.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("MovieShowId")
                        .HasColumnType("int");

                    b.Property<string>("Payment_Method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("TicketId");

                    b.HasIndex("AccountId");

                    b.HasIndex("MovieShowId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("BusinessObject.Booking", b =>
                {
                    b.HasOne("BusinessObject.Seat", "Seat")
                        .WithMany("Bookings")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("BusinessObject.MovieShow", b =>
                {
                    b.HasOne("BusinessObject.Movie", "Movies")
                        .WithMany("MovieShows")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.TheaterHall", "TheaterHalls")
                        .WithMany("MovieShows")
                        .HasForeignKey("TheaterHallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movies");

                    b.Navigation("TheaterHalls");
                });

            modelBuilder.Entity("BusinessObject.Revenue_statics", b =>
                {
                    b.HasOne("BusinessObject.Theater", "Theater")
                        .WithMany("revenue_statics")
                        .HasForeignKey("TheaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("BusinessObject.Seat", b =>
                {
                    b.HasOne("BusinessObject.TheaterHall", "TheaterHall")
                        .WithMany("Seats")
                        .HasForeignKey("TheaterHallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TheaterHall");
                });

            modelBuilder.Entity("BusinessObject.TheaterHall", b =>
                {
                    b.HasOne("BusinessObject.Theater", "Theater")
                        .WithMany("theaterHalls")
                        .HasForeignKey("TheaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("BusinessObject.Ticket", b =>
                {
                    b.HasOne("BusinessObject.Account", "Account")
                        .WithMany("tickets")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.MovieShow", "MovieShow")
                        .WithMany("Tickets")
                        .HasForeignKey("MovieShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("MovieShow");
                });

            modelBuilder.Entity("BusinessObject.Account", b =>
                {
                    b.Navigation("tickets");
                });

            modelBuilder.Entity("BusinessObject.Movie", b =>
                {
                    b.Navigation("MovieShows");
                });

            modelBuilder.Entity("BusinessObject.MovieShow", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("BusinessObject.Seat", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BusinessObject.Theater", b =>
                {
                    b.Navigation("revenue_statics");

                    b.Navigation("theaterHalls");
                });

            modelBuilder.Entity("BusinessObject.TheaterHall", b =>
                {
                    b.Navigation("MovieShows");

                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
