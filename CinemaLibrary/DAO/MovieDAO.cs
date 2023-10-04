using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class MovieDAO
    {
        private static MovieDAO instance = null;
        private static readonly object instanceLock = new object();
        public static MovieDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MovieDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Movie> GetMovieList()
        {
            List<Movie> movies;
            try
            {
                using var context = new CinemaDbContext();
                movies = context.Movies.ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return movies;
        }

        public Movie GetMovieByID(int movieId)
        {
            Movie movie = null;
            try
            {
                using var context = new CinemaDbContext();
                movie = context.Movies.SingleOrDefault(c => c.MovieId == movieId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return movie;
        }

        public void AddNew(Movie movie)
        {
            try
            {
                Movie _Movie = GetMovieByID(movie.MovieId);
                if (_Movie == null)
                {
                    using var context = new CinemaDbContext();
                    context.Movies.Add(movie);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Movie is already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(Movie movie)
        {
            try
            {
                Movie _Movie = GetMovieByID(movie.MovieId);
                if (_Movie != null)
                {
                    using var context = new CinemaDbContext();
                    context.Movies.Update(movie);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Movie does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Movie movie)
        {
            try
            {
                Movie _movie = GetMovieByID(movie.MovieId);
                if (movie != null)
                {
                    using var context = new CinemaDbContext();
                    context.Movies.Remove(movie);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Movie does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
