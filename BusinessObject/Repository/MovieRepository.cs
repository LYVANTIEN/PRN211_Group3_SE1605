﻿using BusinessObject;
using BusinessObject.DAO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessObject.Repository
{
    public class MovieRepository: IMovieRepository
    {


        
        public IEnumerable<Movie> GetMovie() => MovieDAO.Instance.GetMovieList();


        public Movie GetMovieById(int movieId) => MovieDAO.Instance.GetMovieByID(movieId);


        public void Insert(Movie movie) => MovieDAO.Instance.AddNew(movie);


        public void Delete(Movie movie) => MovieDAO.Instance.Remove(movie);


        public void Update(Movie movie) => MovieDAO.Instance.Update(movie);

        //public IEnumerable<MovieShow> GetMovieShows() => MovieDAO.Instance.GetMovieShows();
        
    }
}
