using System;
using System.Collections.Generic;
using ObjectManagerMovie.Interfaces;
using ObjectManager.Models;

namespace ObjectManagerMovie.DBLite
{
    public class MovieRepository : IMovieRepository
    {
        private readonly string DBPath = Config.MovieDBPath;

        public int Add(Movie movie)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Movie Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Movie Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
