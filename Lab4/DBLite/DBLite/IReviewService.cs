using System.Collections.Generic;
using System.ServiceModel;
using ObjectManager.Models;

namespace CRUDServiceReview
{
    [ServiceContract]
    public interface IReviewService
    {
        #region Person
        [OperationContract]
        List<Person> GetAllPersons();

        [OperationContract]
        Person GetPerson(int id);

        [OperationContract]
        int AddPerson(Person person);

        [OperationContract]
        Person UpdatePerson(Person person);

        [OperationContract]
        bool DeletePerson(int id);
        #endregion

        #region Review
        [OperationContract]
        List<Review> GetAllReviews();

        [OperationContract]
        Review GetReview(int id);

        [OperationContract]
        int AddReview(Review review);

        [OperationContract]
        Review UpdateReview(Review review);

        [OperationContract]
        bool DeleteReview(int id);
        #endregion

    }

}
