using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovie();
        Movie GetMovieById(int movieId);

        void Insert(Movie movie);
        void Delete(Movie movie);
        void Update(Movie movie);
       
    }
}
