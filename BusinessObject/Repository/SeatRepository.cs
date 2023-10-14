using BusinessObject;
using BusinessObject.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessObject.Repository
{
    public class SeatRepository: ISeatRepository
    {
        public void DeleteSeat(int seatID) => SeatDAO.Instance.Remove(seatID);


        public Seat GetSeatbyID(int seatID) => SeatDAO.Instance.GetSeatbyID(seatID);


        public IEnumerable<Seat> GetSeats() => SeatDAO.Instance.GetSeatList();


        public void InsertSeat(Seat seat) => SeatDAO.Instance.AddNew(seat);


        public void UpdateSeat(Seat seat) => SeatDAO.Instance.Update(seat);
    }
}
