using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ShowTimeDAO
    {
        private static ShowTimeDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ShowTimeDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ShowTimeDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<ShowTime> GetShowTimeList()
        {
            var showTimes = new List<ShowTime>();
            try
            {
                using var context = new CinemaDbContext();
                showTimes = context.showTimes.ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return showTimes;
        }

        public ShowTime GetShowTimeByID(int showTimeId)
        {
            ShowTime showTime = null;
            try
            {
                using var context = new CinemaDbContext();
                showTime = context.showTimes.SingleOrDefault(c => c.TimeId == showTimeId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return showTime;
        }

        public void AddNew(ShowTime showTime)
        {
            try
            {
                ShowTime _ShowTime = GetShowTimeByID(showTime.TimeId);
                if (_ShowTime == null)
                {
                    using var context = new CinemaDbContext();
                    context.showTimes.Add(showTime);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Show Time is already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(ShowTime showTime)
        {
            try
            {
                ShowTime _ShowTime = GetShowTimeByID(showTime.TimeId);
                if (_ShowTime != null)
                {
                    using var context = new CinemaDbContext();
                    context.showTimes.Update(showTime);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Show Time does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int showTimeId)
        {
            try
            {
                ShowTime showTime = GetShowTimeByID(showTimeId);
                if (showTime != null)
                {
                    using var context = new CinemaDbContext();
                    context.showTimes.Remove(showTime);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Show Time does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
