using System.Collections.Generic;
using System.ServiceModel;
using global::ObjectManagerModels;
using System.ServiceModel.Web;

namespace CRUDServiceReview
{
    [ServiceContract]
    public interface IReviewService
    {
        #region Person
        [OperationContract]
        [WebGet]
        List<Person> GetAllPersons();

        [OperationContract]
        [WebGet]
        Person GetPerson(int id);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        int AddPerson(Person person);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        Person UpdatePerson(Person person);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        bool DeletePerson(int id);
        #endregion

        #region Review
        [OperationContract]
        [WebGet]
        List<Review> GetAllReviews();

        [OperationContract]
        [WebGet]
        Review GetReview(int id);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        int AddReview(Review review);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        Review UpdateReview(Review review);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        bool DeleteReview(int id);
        #endregion

    }

}
