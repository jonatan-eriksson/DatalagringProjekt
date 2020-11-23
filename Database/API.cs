using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class API
    {
        public static Customer GetCustomerByName(string name)
        {
            using var ctx = new Context();
            return ctx.Customers
                .FirstOrDefault(c => c.Username.ToLower() == name.ToLower());
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

        public static List<Movie> GetMovieByTitle(string title)
        {
            using var ctx = new Context();
            return ctx.Movies
                .Include(m => m.Genres)
                .Where(m => m.Title.ToLower().StartsWith(title.ToLower()))
                .ToList();
        }

        public static List<Movie> GetMoviesByGenre(string genre)
        {
            var genreObj = new Genre {Name = genre};

            using var ctx = new Context();
            
            var movies = ctx.Movies
                .Include(m => m.Genres)
                .Where(m => m.Genres.Any(g => g.Name.ToLower() == genre.ToLower())).ToList();
            //var test = ctx.Movies
            //    .Select(m => m.Genres.Contains(genreObj)).ToList();
            return movies;
        }
    }
}
