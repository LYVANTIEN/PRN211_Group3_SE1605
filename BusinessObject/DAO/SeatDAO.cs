using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessObject.DAO
{
    public class SeatDAO
    {
        private static SeatDAO instance = null;
        public static readonly object instanceLock = new object();

        public static SeatDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SeatDAO();
                    }

                    return instance;
                }
            }
        }

        public IEnumerable<Seat> GetSeatList()
        {
            var seats = new List<Seat>();
            try
            {
                using var context = new CinemaDbContext();
                seats = context.Seats.Include(m => m.TheaterHall).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return seats;
        }

        public Seat GetSeatbyID(int seatID)
        {
            Seat seat = null;
            try
            {
                using var context = new CinemaDbContext();
                seat = context.Seats.Include(m => m.TheaterHall).SingleOrDefault(c => c.SeatId == seatID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return seat;
        }


        public void AddNew(Seat seat)
        {
            try
            {
                Seat _seat = GetSeatbyID(seat.SeatId);
                if (_seat == null)
                {
                    using var context = new CinemaDbContext();
                    context.Seats.Add(seat);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Seat is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Seat seat)
        {
            try
            {
                Seat _seat = GetSeatbyID(seat.SeatId);
                if (_seat != null)
                {
                    using var context = new CinemaDbContext();
                    context.Seats.Update(seat);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Seat does not already exits");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int seatID)
        {
            try
            {
                Seat seat = GetSeatbyID(seatID);
                if (seat != null)
                {
                    using var context = new CinemaDbContext();
                    context.Seats.Remove(seat);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Seat does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
