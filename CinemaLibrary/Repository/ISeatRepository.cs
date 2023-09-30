using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ISeatRepository
    {
        IEnumerable<Seat> GetSeats();
        Seat GetSeatbyID(int seatID);
        void InsertSeat(Seat seat);
        void UpdateSeat(Seat seat);
        void DeleteSeat(int seatID);
    }
}
