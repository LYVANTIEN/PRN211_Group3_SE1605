using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookingDAO
    {
        private static BookingDAO instance = null;
        private static readonly object instanceLock = new object();
        public static BookingDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookingDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Booking> GetBookingList()
        {
            var bookings = new List<Booking>();
            try
            {
                using var context = new CinemaDbContext();
                bookings = context.Bookings.ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return bookings;
        }

        public Booking GetBookingByID(int bookingId)
        {
            Booking booking = null;
            try
            {
                using var context = new CinemaDbContext();
                booking = context.Bookings.SingleOrDefault(c => c.BookingId == bookingId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return booking;
        }

        public void AddNew(Booking booking)
        {
            try
            {
                Booking _Booking = GetBookingByID(booking.BookingId);
                if (_Booking == null)
                {
                    using var context = new CinemaDbContext();
                    context.Bookings.Add(booking);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Seat is already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(Booking booking)
        {
            try
            {
                Booking _Booking = GetBookingByID(booking.BookingId);
                if (_Booking != null)
                {
                    using var context = new CinemaDbContext();
                    context.Bookings.Update(booking);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Seat does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int bookingId)
        {
            try
            {
                Booking booking = GetBookingByID(bookingId);
                if (booking != null)
                {
                    using var context = new CinemaDbContext();
                    context.Bookings.Remove(booking);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Set does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
