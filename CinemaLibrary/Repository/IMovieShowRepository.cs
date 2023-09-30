using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMovieShowRepository
    {
        IEnumerable<MovieShow> GetMovieShows();
        MovieShow GetMovieShowsById(int movieShowId);

        void Insert(MovieShow movieShow);
        void Update(MovieShow movieShow);
        void Delete(int movieShowId);
    }
}
