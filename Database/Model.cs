using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database
{
    public class Customer
    {
        public int Id { get; set; }
        // Unique username
        [Required]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public List<Sale> Sales { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImageUrl { get; set; }
        
        public List<Sale> Sales { get; set; }
    }

    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
    }
}
