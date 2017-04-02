using System.Collections.Generic;
using global::ObjectManagerModels;

namespace ObjectManagerReview.Interfaces
{
    public interface IReviewRepository
    {
        List<Review> GetAll();
        int Add(Review review);
        Review Get(int id);
        Review Update(Review review);
        bool Delete(int id);
    }
}
