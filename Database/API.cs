using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database
{
    public class API
    {
        public static Customer GetCustomerByName(string name)
        {
            using var ctx = new Context();
            return ctx.Customers.FirstOrDefault(c => c.Username.ToLower() == name.ToLower());
        }
    }
}
