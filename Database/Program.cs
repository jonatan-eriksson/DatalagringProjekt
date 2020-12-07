using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;

namespace Database
{
    class Seeding
    {
        static void Main()
        {
            using (var ctx = new Context())
            {
                // Rensa data i databasen
                ctx.RemoveRange(ctx.Sales);
                ctx.RemoveRange(ctx.Movies);
                ctx.RemoveRange(ctx.Customers);
                ctx.RemoveRange(ctx.Genres);
         
                // Movie data
                //var fileData = File.ReadAllLines(@"../../../SeedData/MovieGenre.csv", System.Text.Encoding.ASCII);
                var fileData = File.ReadLines(@"../../../SeedData/MovieGenre.csv", System.Text.Encoding.ASCII).Take(100).ToArray();
                var movies = new List<Movie>();
                var genres = new Dictionary<string, Genre>();

                foreach(var line in fileData)
                {
                    var item = line.Split(','); //fileData[i].Split(',');

                    // Title
                    string title = item[2].Split('(')[0];

                    // Genre
                    var movieGenres = new List<Genre>();
                    foreach (var genre in item[4].Split('|'))
                    {
                        if (!genres.ContainsKey(genre))
                        {
                            genres.Add(genre, new Genre {Name = genre});
                        }
                        movieGenres.Add(genres[genre]);
                    }

                    // Year
                    string year = null;
                    if (item[2].Contains('('))
                    {
                        // Plockar ut årtalet från titeln
                        year = item[2].Split('(', ')')[1];
                    }

                    // Rating
                    var rating = item[3];
                    
                    // URL
                    string url = item[5].Trim('"');
                    try
                    {
                        // Försöker skapa en uri
                        WebRequest request = WebRequest.Create(url);
                        // Testar om adressen svarar när man kallar på den
                        request.GetResponse();
                    }
                    catch { continue; }

                    movies.Add(new Movie { Title = title, Year = year, Rating=rating, ImageUrl = url, Price = 0, Genres = movieGenres});
                }
                ctx.Movies.AddRange(movies);

                ctx.SaveChanges();
            }

            // Lägg till en demo customer
            API.CreateCustomer("Demo", "demo", "demo", "demo@demo.se", "Demo", "Demosson");
        }
    }
}
