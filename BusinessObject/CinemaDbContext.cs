using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
        {
        }

        public CinemaDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieShow> MoviesShows { get; set; }
        public DbSet<Revenue_statics> Revenue_statics { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<ShowTime> showTimes { get; set; }
        public DbSet<Theater> Theater { get; set; }
        public DbSet<TheaterHall> theaterHalls { get; set; }
        public DbSet<Ticket> Ticket { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // mối quan hệ giữa TheaterHall và Theater
            modelBuilder.Entity<TheaterHall>()
                .HasOne(t => t.Theater)
                .WithMany(th => th.theaterHalls)
                .HasForeignKey(t => t.TheaterId);

            // mối quan hệ giữa TheaterHall và Seat
            modelBuilder.Entity<Seat>()
                .HasOne(th => th.TheaterHall)
                .WithMany(s => s.Seats)
                .HasForeignKey(th => th.TheaterHallId);

            // mối quan hệ giữa Booking và Seat
            modelBuilder.Entity<Booking>()
                .HasOne(s => s.Seat)
                .WithMany(b => b.Bookings)
                .HasForeignKey(s => s.SeatId);

            // mối quan hệ giữa Revenue và Theater 
            modelBuilder.Entity<Revenue_statics>()
                .HasOne(t => t.Theater)
                .WithMany(r => r.revenue_statics)
                .HasForeignKey(t => t.TheaterId);

            // mối quan hệ giữa MovieShow và TheaterHall 
            modelBuilder.Entity<MovieShow>()
                .HasOne(th => th.TheaterHalls)
                .WithMany(ms => ms.MovieShows)
                .HasForeignKey(th => th.TheaterHallId);

            // mối quan hệ giữa MovieShow và Movie 
            modelBuilder.Entity<MovieShow>()
                .HasOne(m =>m.Movies)
                .WithMany(ms =>ms.MovieShows)
                .HasForeignKey(m => m.MovieId);

            // mối quan hệ giữa MovieShow và ShowTime 
            modelBuilder.Entity<MovieShow>()
                .HasOne(st => st.ShowTimes)
                .WithMany(ms => ms.MovieShows)
                .HasForeignKey(st => st.TimeId);

            // mối quan hệ giữa Ticket và MovieShow
            modelBuilder.Entity<Ticket>()
                .HasOne(ms => ms.MovieShow)
                .WithMany(t => t.Tickets)
                .HasForeignKey(ms => ms.MovieShowId);

            // account
            modelBuilder.Entity<Account>();
        }
    }
}
