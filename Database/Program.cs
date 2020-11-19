using System;
using System.Collections.Generic;

namespace Database
{
    class Seeding
    {
        static void Main()
        {
            using (var ctx = new Context())
            {
                ctx.RemoveRange(ctx.Sales);
                ctx.RemoveRange(ctx.Movies);
                ctx.RemoveRange(ctx.Customers);

                ctx.AddRange(new List<Customer>
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


                });
            }
        }
    }
}
