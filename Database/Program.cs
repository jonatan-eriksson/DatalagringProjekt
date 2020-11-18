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


                });
            }
        }
    }
}
