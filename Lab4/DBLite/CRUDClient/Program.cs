using System;
using CRUDClient.MovieService;
using CRUDClient.ReviewService;
using System.Collections.Generic;

namespace CRUDClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieServiceClient movieClient = new MovieServiceClient();
            ReviewServiceClient reviewClient = new ReviewServiceClient();

            Console.WriteLine("Podaj imię:");
            Person person = new Person();
            person.Id = 0;
            person.Name = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko:");
            person.Surname = Console.ReadLine();
            
            while(true)
            {
                Console.WriteLine("a) dodanie recenzji\nb) edycja recenzji\nc) usunięcie edycji\nd) zobacz recenzję dla filmów\n e) dodaj film");
                string input = Console.ReadLine();
                if(input == "a")
                {
                    AddNewReview(person, movieClient, reviewClient);
                }
                else if(input == "b")
                {
                    UpdateReview(person, reviewClient);
                }
                else if(input == "c")
                {
                    DeleteReview(person, reviewClient);
                }
                else if(input == "d")
                {
                    ShowMovieReviews(movieClient, reviewClient);
                }
                else if(input == "e")
                {
                    AddNewMovie(movieClient);
                }
            }
        }

        private static void DeleteReview(Person person, ReviewServiceClient reviewClient)
        {
            foreach (Review review in reviewClient.GetAllReviews())
                if (review.Author.Name == person.Name && review.Author.Surname == person.Surname)
                    Console.WriteLine(review.Id + " " + review.Score + " " + review.Content);
            Console.WriteLine("Wybierz numer recenzji, którą chcesz usunąć");
            int reviewId = int.Parse(Console.ReadLine());
            Console.WriteLine("Czy na pewno chcesz usunąć tę recenzję? [T/N]");
            string input = Console.ReadLine();
            if (input.ToLower() == "t")
                reviewClient.DeleteReview(reviewId);
        }

        private static void UpdateReview(Person person, ReviewServiceClient reviewClient)
        {
            foreach (Review review in reviewClient.GetAllReviews())
                if (review.Author.Name == person.Name && review.Author.Surname == person.Surname)
                    Console.WriteLine(review.Id + " " + review.Score + " " + review.Content);
            Console.WriteLine("Wybierz numer recenzji, którą chcesz edytować");
            int reviewId = int.Parse(Console.ReadLine());

            Console.WriteLine("Napisz recenzję od nowa");
            Review updatedReview = reviewClient.GetReview(reviewId);
            updatedReview.Content = Console.ReadLine();
            Console.WriteLine("Podaj ocenę");
            updatedReview.Score = int.Parse(Console.ReadLine());
            reviewClient.UpdateReview(updatedReview);
        }

        private static void AddNewReview(Person author, MovieServiceClient movieClient, ReviewServiceClient reviewClient)
        {
            foreach(Movie movie in movieClient.GetAllMovies())
                Console.WriteLine(movie.Id + " " + movie.ReleaseYear + " " + movie.Title);
            Console.WriteLine("\nPodaj numer filmu, dla którego chcesz napisać recenzję");
            string input = Console.ReadLine();
            Review review = new Review();
            review.Author = author;
            review.Id = 0;
            review.MovieId = int.Parse(input);
            Console.WriteLine("Napisz recenzję");
            review.Content = Console.ReadLine();
            do
            {
                Console.WriteLine("Podaj ocenę filmu 0-100");
                review.Score = int.Parse(Console.ReadLine());
            } while (review.Score < 0 || review.Score > 100);
            reviewClient.AddReview(review);
        }

        private static void AddNewMovie(MovieServiceClient movieClient)
        {
            Movie movie = new Movie();
            Console.WriteLine("Podaj rok wydania filmu");
            movie.ReleaseYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj tytuł filmu");
            movie.Title = Console.ReadLine();
            movie.Id = 0;

            movieClient.AddMovie(movie);
        }

        private static void ShowMovieReviews(MovieServiceClient movieClient, ReviewServiceClient reviewClient)
        {
            foreach (Movie movie in movieClient.GetAllMovies())
                Console.WriteLine(movie.Id + " " + movie.ReleaseYear + " " + movie.Title);
            Console.WriteLine("\nPodaj numer filmu, dla którego chcesz napisać recenzję");
            int movieId = int.Parse(Console.ReadLine());

            Review[] reviews = reviewClient.GetAllReviews();
            List<Review> certainReviews = new List<Review>();
            foreach (Review review in reviews)
                if (review.MovieId == movieId)
                    certainReviews.Add(review);
            double meanScore = 0;
            foreach (Review review in certainReviews)
            {
                Console.WriteLine(review.Author.Name + " " + review.Author.Surname + " " + review.Score + " " + review.Content);
                meanScore += review.Score;
            }
            Console.WriteLine("Średnia ocen: " + meanScore / certainReviews.Count);

        }
    }
}
