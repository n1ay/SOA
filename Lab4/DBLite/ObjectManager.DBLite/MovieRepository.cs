using System;
using System.Collections.Generic;
using ObjectManagerMovie.Interfaces;
using global::ObjectManagerModels;
using LiteDB;
using ObjectManagerMovie.DBLite.Model;

namespace ObjectManagerMovie.DBLite
{
    public class MovieRepository : IMovieRepository
    {
        private readonly string DBPath = Config.MovieDBPath;

        public int Add(Movie movie)
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var dbObject = InverseMap(movie);
                var repository = db.GetCollection<MovieDB>("movies");
                if (repository.FindById(movie.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<MovieDB>("movies");
                return repository.Delete(id);
            }
        }

        public Movie Get(int id)
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<MovieDB>("movies");
                return Map(repository.FindById(id));
            }
        }

        public List<Movie> GetAll()
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<MovieDB>("movies");
                var collection = repository.FindAll();
                List<Movie> result = new List<Movie>();
                foreach (MovieDB rdb in collection)
                    result.Add(Map(rdb));
                return result;
            }
        }

        public Movie Update(Movie movie)
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var dbObj = InverseMap(movie);
                var repository = db.GetCollection<MovieDB>("movies");
                if (repository.Update(dbObj))
                    return movie;
                else
                    return null;
            }
        }

        internal Movie Map(MovieDB movie)
        {
            if (movie == null)
                return null;

            Movie result = new Movie();
            result.Id = movie.Id;
            result.ReleaseYear = movie.ReleaseYear;
            result.Title = movie.Title;

            return result;
        }

        internal MovieDB InverseMap(Movie movie)
        {
            if (movie == null)
                return null;

            MovieDB result = new MovieDB();
            result.Id = movie.Id;
            result.ReleaseYear = movie.ReleaseYear;
            result.Title = movie.Title;

            return result;
        }
    }
}
