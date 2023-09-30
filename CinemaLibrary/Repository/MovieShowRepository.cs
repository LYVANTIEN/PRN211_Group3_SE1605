using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MovieShowRepository: IMovieShowRepository
    {
        public void Delete(int movieShowId)
        {
            MovieShowDAO.Instance.Remove(movieShowId);
        }

        public IEnumerable<MovieShow> GetMovieShows()
        {
            return MovieShowDAO.Instance.GetMovieShowList();
        }

        public MovieShow GetMovieShowsById(int movieShowId)
        {
            return MovieShowDAO.Instance.GetMovieShowByID(movieShowId);
        }

        public void Insert(MovieShow movieShow)
        {
            MovieShowDAO.Instance.AddNew(movieShow);
        }

        public void Update(MovieShow movieShow)
        {
            MovieShowDAO.Instance.Update(movieShow);
        }
    }
}
