using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual List<Sale> Sales { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rating { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        public virtual List<Genre> Genres { get; set; }
        public virtual List<Sale> Sales { get; set; }
        
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }

    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
