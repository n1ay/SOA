using System;
using System.Collections.Generic;
using ObjectManager.Models;
using ObjectManagerReview.Interfaces;
using ObjectManagerReview.DBLite.Model;
using LiteDB;

namespace ObjectManagerReview.DBLite
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string DBPath = Config.ReviewDBPath;

        public int Add(Review review)
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var dbObject = InverseMap(review);
                var repository = db.GetCollection<ReviewDB>("reviews");
                if (repository.FindById(review.Id) != null)
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
                var repository = db.GetCollection<ReviewDB>("reviews");
                return repository.Delete(id);
            }
        }

        public Review Get(int id)
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                return Map(repository.FindById(id));
            }
        }

        public List<Review> GetAll()
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                var collection = repository.FindAll();
                List<Review> result = new List<Review>();
                foreach (ReviewDB rdb in collection)
                    result.Add(Map(rdb));
                return result;
            }
        }

        public Review Update(Review review)
        {
            using(var db = new LiteDatabase(DBPath))
            {
                var dbObj = InverseMap(review);
                var repository = db.GetCollection<ReviewDB>("reviews");
                if (repository.Update(dbObj))
                    return review;
                else
                    return null;
            }
        }

        internal Review Map(ReviewDB review)
        {
            if (review == null)
                return null;

            Review result = new Review();
            result.Author = review.Author;
            result.Content = review.Content;
            result.Id = review.Id;
            result.MovieId = review.MovieId;
            result.Score = review.Score;

            return result;
        }

        internal ReviewDB InverseMap(Review review)
        {
            if (review == null)
                return null;

            ReviewDB result = new ReviewDB();
            result.Author = review.Author;
            result.Content = review.Content;
            result.Id = review.Id;
            result.MovieId = review.MovieId;
            result.Score = review.Score;

            return result;
        }
    }
}
