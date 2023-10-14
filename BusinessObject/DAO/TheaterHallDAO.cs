using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessObject.DAO
{
    public class TheaterHallDAO
    {
        private static TheaterHallDAO instance = null;
        private static readonly object instanceLock = new object();
        public static TheaterHallDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TheaterHallDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<TheaterHall> GetList()
        {
            var theatreHalls = new List<TheaterHall>();
            try
            {
                using var context = new CinemaDbContext();
                theatreHalls = context.theaterHalls.ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return theatreHalls;
        }

        public TheaterHall GetTheatreHallById(int theaterHallId)
        {
            TheaterHall theaterHall = null;
            try
            {
                using var context = new CinemaDbContext();
                theaterHall = context.theaterHalls.SingleOrDefault(c => c.TheaterHallId == theaterHallId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return theaterHall;
        }

        public void AddNew(TheaterHall theaterHall)
        {
            try
            {
                TheaterHall _TheaterHall = GetTheatreHallById(theaterHall.TheaterHallId);
                if (_TheaterHall == null)
                {
                    using var context = new CinemaDbContext();
                    context.theaterHalls.Add(theaterHall);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Hall is already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(TheaterHall theaterHall)
        {
            try
            {
                TheaterHall _TheatreHall = GetTheatreHallById(theaterHall.TheaterHallId);
                if (_TheatreHall != null)
                {
                    using var context = new CinemaDbContext();
                    context.theaterHalls.Update(theaterHall);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Hall does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int theaterHallId)
        {
            try
            {
                TheaterHall theaterHall = GetTheatreHallById(theaterHallId);
                if (theaterHall != null)
                {
                    using var context = new CinemaDbContext();
                    context.theaterHalls.Remove(theaterHall);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Hall does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
