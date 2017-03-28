using System.Collections.Generic;
using ObjectManager.Models;

namespace ObjectManagerMovie.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        int Add(Movie movie);
        Movie Get(int id);
        Movie Update(Movie movie);
        bool Delete(int id);      
    }
}
