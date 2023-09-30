using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class MovieShowDAO
    {
        private static MovieShowDAO instance = null;
        private static readonly object instanceLock = new object();
        public static MovieShowDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MovieShowDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<MovieShow> GetMovieShowList()
        {
            var movieShows = new List<MovieShow>();
            try
            {
                using var context = new CinemaDbContext();
                movieShows = context.MoviesShows.Include(m => m.Movies).Include(m => m.TheaterHalls).Include(m => m.ShowTimes).ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return movieShows;
        }

        public MovieShow GetMovieShowByID(int movieShowId)
        {
            MovieShow movieShow = null;
            try
            {
                using var context = new CinemaDbContext();
                movieShow = context.MoviesShows.Include(m => m.Movies).Include(m => m.TheaterHalls).Include(m => m.ShowTimes).SingleOrDefault(c => c.MovieShowId == movieShowId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return movieShow;
        }

        public void AddNew(MovieShow movieShow)
        {
            try
            {
                MovieShow _MovieShow = GetMovieShowByID(movieShow.MovieShowId);
                if (_MovieShow == null)
                {
                    using var context = new CinemaDbContext();
                    context.MoviesShows.Add(movieShow);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The movie show is already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(MovieShow movieShow)
        {
            try
            {
                MovieShow _MovieShow = GetMovieShowByID(movieShow.MovieShowId);
                if (_MovieShow != null)
                {
                    using var context = new CinemaDbContext();
                    context.MoviesShows.Update(movieShow);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The movie show does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int movieShowId)
        {
            try
            {
                MovieShow movieShow = GetMovieShowByID(movieShowId);
                if (movieShow != null)
                {
                    using var context = new CinemaDbContext();
                    context.MoviesShows.Remove(movieShow);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The movie show does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
