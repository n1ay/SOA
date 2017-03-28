using System.Collections.Generic;
using System.ServiceModel;
using ObjectManager.Models;

namespace CRUDServiceMovie
{
    [ServiceContract]
    public interface IMovieService
    {
        [OperationContract]
        List<Movie> GetAllMovies();

        [OperationContract]
        int AddMovie(Movie movie);

        [OperationContract]
        Movie UpdateMovie(Movie movie);

        [OperationContract]
        Movie GetMovie(int id);

        [OperationContract]
        bool DeleteMovie(int id);
    }
}
