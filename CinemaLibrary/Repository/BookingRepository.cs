using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookingRepository: IBookingRepository
    {
        public void Delete(int bookingId)
        {
            BookingDAO.Instance.Remove(bookingId);
        }

        public IEnumerable<Booking> GetBooking()
        {
            return BookingDAO.Instance.GetBookingList();
        }

        public Booking GetBookingById(int bookingId)
        {
            return BookingDAO.Instance.GetBookingByID(bookingId);
        }

        public void Insert(Booking booking)
        {
            BookingDAO.Instance.AddNew(booking);
        }

        public void Update(Booking booking)
        {
            BookingDAO.Instance.Update(booking);
        }
    }
}
