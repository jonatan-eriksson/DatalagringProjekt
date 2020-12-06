using System;
using System.Collections.Generic;
using System.Text;
using Database;

namespace Store
{
    public static class State
    {
        public static Customer User { get; set; }
        public static List<Movie> Movies { get; set; }
        public static List<Movie> UserMovies { get; set; }
        public static Movie MoviePick { get; set; }
    }
}
