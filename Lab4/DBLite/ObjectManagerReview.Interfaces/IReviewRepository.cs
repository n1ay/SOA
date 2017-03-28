using System.Collections.Generic;
using ObjectManager.Models;

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
