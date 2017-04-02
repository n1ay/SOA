using System.Collections.Generic;
using System.ServiceModel;
using global::ObjectManagerModels;
using System.ServiceModel.Web;

namespace CRUDServiceMovie
{
    [ServiceContract]
    public interface IMovieService
    {
        [OperationContract]
        [WebGet]
        List<Movie> GetAllMovies();

        [OperationContract]
        [WebInvoke(Method = "POST")]
        int AddMovie(Movie movie);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        Movie UpdateMovie(Movie movie);

        [OperationContract]
        [WebGet]
        Movie GetMovie(int id);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        bool DeleteMovie(int id);
    }
}
