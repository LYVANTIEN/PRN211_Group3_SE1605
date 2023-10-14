using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessObject.Repository
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetBooking();
        Booking GetBookingById(int bookingId);

        void Insert(Booking booking);
        void Update(Booking booking);
        void Delete(int bookingId);
    }
}
