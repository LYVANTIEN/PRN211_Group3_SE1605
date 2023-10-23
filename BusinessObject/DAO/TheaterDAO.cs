using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessObject.DAO
{
    public class TheaterDAO
    {
        private static TheaterDAO instance = null;
        private static readonly object instanceLock = new object();
        public static TheaterDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TheaterDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Theater> GetTheaterList()
        {
            var theater = new List<Theater>();
            try
            {
                using var context = new CinemaDbContext();
                theater = context.Theater.ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return theater;
        }

        public Theater GetTheaterById(int theaterId)
        {
            Theater theater = null;
            try
            {
                using var context = new CinemaDbContext();
                theater = context.Theater.SingleOrDefault(c => c.TheaterId == theaterId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return theater;
        }

        public void AddNew(Theater theater)
        {
            try
            {
                Theater _Theater = GetTheaterById(theater.TheaterId);
                if (_Theater == null)
                {
                    using var context = new CinemaDbContext();
                    context.Theater.Add(theater);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Theater is already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(Theater theater)
        {
            try
            {
                Theater _Theater = GetTheaterById(theater.TheaterId);
                if (_Theater != null)
                {
                    using var context = new CinemaDbContext();
                    context.Theater.Update(theater);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Theater does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int theaterId)
        {
            try
            {
                Theater theater = GetTheaterById(theaterId);
                if (theater != null)
                {
                    using var context = new CinemaDbContext();
                    context.Theater.Remove(theater);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Theater does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
