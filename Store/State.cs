﻿using System;
using System.Collections.Generic;
using System.Text;
using Database;

namespace Store
{
    class State
    {
        public static Customer User { get; set; }
        public static List<Movie> Movies { get; set; }
        public static Movie MoviePick { get; set; }
    }
}