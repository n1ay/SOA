using System;
using System.ServiceModel;
using System.Collections.Generic;
using global::ObjectManagerModels;
using ObjectManagerMovie.Interfaces;
using ObjectManagerMovie.DBLite;
using System.Runtime.Serialization;


namespace CRUDServiceMovie
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService()
        {
            _movieRepository = new MovieRepository();
        }

        public int AddMovie(Movie movie)
        {
            return _movieRepository.Add(movie);
        }

        public bool DeleteMovie(int id)
        {
            return _movieRepository.Delete(id);
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAll();
        }

        public Movie GetMovie(int id)
        {
            return _movieRepository.Get(id);
        }

        public Movie UpdateMovie(Movie movie)
        {
            return _movieRepository.Update(movie);
        }
    }
}
