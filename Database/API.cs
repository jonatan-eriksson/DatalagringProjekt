using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Database
{
    public class API
    {
        // Movie
        public static List<Movie> GetMovieByTitle(string title)
        {
            using var ctx = new Context();
            return ctx.Movies
                .Include(m => m.Genres)
                .Where(m => m.Title.ToLower().Contains(title.ToLower()))
                .ToList();
        }

        public static List<Movie> GetMovieSlice(int start, int amount)
        {
            using var ctx = new Context();
            return ctx.Movies
                .Include(m => m.Genres)
                .Skip(start)
                .Take(amount)
                .ToList();
        }

        public static List<Movie> GetMoviesByGenre(string genre)
        {
            var genreObj = new Genre {Name = genre};

            using var ctx = new Context();
            
            var movies = ctx.Movies
                .Include(m => m.Genres)
                .Where(m => m.Genres.Any(g => g.Name.ToLower() == genre.ToLower()))
                .ToList();

            return movies;
        }

        public static List<Movie> GetCustomerMovies(Customer customer)
        {
            
            using var ctx = new Context();
            return ctx.Sales
                .Include(m => m.Movie)
                .Where(s => s.Customer == customer)
                .Select(s => s.Movie)
                .ToList();
        }

        public static List<Genre> GetGenres()
        {
            using var ctx = new Context();
            return ctx.Genres.ToList();
        }


        // Sale
        public static bool RegisterSale(Customer customer, Movie movie)
        {
            var sale = new Sale()
            {
                Date = DateTime.Now,
                CustomerId = customer.Id,
                MovieId = movie.Id
            };

            using var ctx = new Context();
            try
            {
                ctx.Sales.Add(sale);

                return ctx.SaveChanges() == 1;
            }
            catch (DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                return false;
            }
        }
        
        // Customer
        public static Customer GetCustomerByUsername(string username)
        {
            using var ctx = new Context();
            return ctx.Customers
                .FirstOrDefault(c => c.Username.ToLower() == username.ToLower());
        }

        public static Customer LoginCustomer(string username, string password)
        {
            var customer = GetCustomerByUsername(username);
            
            if (customer != null)
            {
                var hasher = new PasswordHasher<string>();
                var verification = hasher.VerifyHashedPassword("", customer.PasswordHash, password);

                if (verification == PasswordVerificationResult.Success)
                {
                    return customer;
                }
            }

            return null;
        }

        public enum CustomerCreationResult
        {
            WrongPassword,
            UserExists,
            Error,
            Success
        }
        public static CustomerCreationResult CreateCustomer(string username, string password, string confirmPassword,
            string email, string firstName, string lastName)
        {
            if (password != confirmPassword)
            {
                return CustomerCreationResult.WrongPassword;
            }

            if (GetCustomerByUsername(username) != null)
            {
                return CustomerCreationResult.UserExists;
            }

            var hasher = new PasswordHasher<string>();
            var hashedPassword = hasher.HashPassword(null, password);

            var customer = new Customer()
            {
                Username = username,
                PasswordHash = hashedPassword,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                RegisterDate = DateTime.Now
            };

            using var ctx = new Context();
            try
            {
                ctx.Customers.Add(customer);

                ctx.SaveChanges();
                return CustomerCreationResult.Success;
            }
            catch (DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                return CustomerCreationResult.Error;
            }
        
        }
    }
}
