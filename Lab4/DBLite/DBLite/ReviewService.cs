using System;
using System.Collections.Generic;
using System.ServiceModel;
using global::ObjectManagerModels;
using ObjectManagerReview.Interfaces;
using ObjectManagerReview.DBLite;
using System.Runtime.Serialization;

namespace CRUDServiceReview
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IPersonRepository _personRepository;

        public ReviewService()
        {
            _reviewRepository = new ReviewRepository();
            _personRepository = new PersonRepository();
        }

        public int AddPerson(Person person)
        {
            return _personRepository.Add(person);
        }

        public int AddReview(Review review)
        {
           return _reviewRepository.Add(review);
        }

        public bool DeletePerson(int id)
        {
            return _personRepository.Delete(id);
        }

        public bool DeleteReview(int id)
        {
            return _reviewRepository.Delete(id);
        }

        public List<Person> GetAllPersons()
        {
            return _personRepository.GetAll();
        }

        public List<Review> GetAllReviews()
        {
            return _reviewRepository.GetAll();
        }

        public Person GetPerson(int id)
        {
            return _personRepository.Get(id);
        }

        public Review GetReview(int id)
        {
            return _reviewRepository.Get(id);
        }

        public Person UpdatePerson(Person person)
        {
            return _personRepository.Update(person);
        }

        public Review UpdateReview(Review review)
        {
            return _reviewRepository.Update(review);
        }
    }
}
