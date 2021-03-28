using System;
using System.Collections.Generic;

#nullable disable

namespace RestWebApplication.Models.Entities
{
    public partial class Joke
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
    }
}
