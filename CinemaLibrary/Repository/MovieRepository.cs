using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MovieRepository
    {
        public void Delete(int movieId)
        {
            MovieDAO.Instance.Remove(movieId);
        }

        public IEnumerable<Movie> GetMovie()
        {
            return MovieDAO.Instance.GetMovieList();
        }

        public Movie GetMovieById(int movieId)
        {
            return MovieDAO.Instance.GetMovieByID(movieId);
        }

        public void Insert(Movie movie)
        {
            MovieDAO.Instance.AddNew(movie);
        }

        public void Update(Movie movie)
        {
            MovieDAO.Instance.Update(movie);
        }
    }
}
