using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.EntityFrameworkCore;

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


                // Customer data
                ctx.Customers.AddRange(new List<Customer>
                {
                    new Customer { Username = "Munches", FirstName = "Jack", LastName = "Suhonen"},
                    new Customer { Username = "Sluzy", FirstName = "Andreas", LastName = "Karlsson"},
                    new Customer { Username = "TheThufir", FirstName = "Cornelia", LastName = "Lennartsson"},
                    new Customer { Username = "StarLite", FirstName = "Mattias", LastName = "Andersson"},
                    new Customer { Username = "Leren", FirstName = "Anita", LastName = "Åhlander"},
                    new Customer { Username = "Kasavy", FirstName = "Lukas", LastName = "Ahlqvist"},
                    new Customer { Username = "Jyotsana", FirstName = "Justina", LastName = "Hagberg"},
                    new Customer { Username = "JayGatsby", FirstName = "Tobias", LastName = "Cedergren"},
                    new Customer { Username = "Hausfreund", FirstName = "Rakel", LastName = "Jönsson"},
                    new Customer { Username = "Howling 0wl", FirstName = "Ejnar", LastName = "Isberg"},
                    new Customer { Username = "Fooraap", FirstName = "Janne", LastName = "Söderman"},
                    new Customer { Username = "Dixi", FirstName = "Anneli", LastName = "Forsström"},
                    new Customer { Username = "DeathTool", FirstName = "Alf", LastName = "Fransén"},
                    new Customer { Username = "CptnAmazin", FirstName = "Ralf", LastName = "Lif"},
                    new Customer { Username = "Blastfizzle", FirstName = "Judith", LastName = "Östlund"},
                    new Customer { Username = "Aticus", FirstName = "Yngve", LastName = "Henningsson"},
                    new Customer { Username = "Aleverette", FirstName = "Hilda", LastName = "Lindholm"},
                    new Customer { Username = "CpTnFantastic", FirstName = "Solvig", LastName = "Markström"},
                    new Customer { Username = "Miss DMeaner", FirstName = "Helén", LastName = "Modin"},
                    new Customer { Username = "Zaendol", FirstName = "Filippa", LastName = "Evertsson"},
                    new Customer { Username = "xelaj", FirstName = "Signhild", LastName = "Markusson"},
                    new Customer { Username = "Xirin", FirstName = "Marit", LastName = "Oskarsson"},
                    new Customer { Username = "Naaiya Kado", FirstName = "Anna-Karin", LastName = "Ringdahl"},
                    new Customer { Username = "Shirasawa", FirstName = "Maria", LastName = "Johannisson"},
                    new Customer { Username = "Lord Kermit", FirstName = "Brynolf", LastName = "Ek"},
                    new Customer { Username = "Lord Takan", FirstName = "Billy", LastName = "Hedqvist"},
                    new Customer { Username = "IceCold Garant", FirstName = "Gunn", LastName = "Nordberg"},
                    new Customer { Username = "The Mrs Butters", FirstName = "Inga", LastName = "Bark"},
                    new Customer { Username = "Blood for Mercy", FirstName = "Allan", LastName = "Rasmusson"},
                    new Customer { Username = "Hunter Freemen", FirstName = "Ragnar", LastName = "Öst"},
                    new Customer { Username = "Jonatan", FirstName = "Jonatan", LastName = "Eriksson"}
                });

                // Movie data
                var fileData = File.ReadAllLines(@"../../../SeedData/MovieGenre.csv");
                var movies = new List<Movie>();
                var genres = new Dictionary<string, Genre>();
                for(int i = 1; i< 100; i++)
                {
                    var item = fileData[i].Split(',');

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

                    movies.Add(new Movie { Title = item[2].Split('(')[0], Year = year, ImageUrl = url, Price = 0, Genres = movieGenres});
                }
                ctx.Movies.AddRange(movies);

                ctx.SaveChanges();
            }
        }
    }
}
