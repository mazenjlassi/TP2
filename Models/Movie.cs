﻿namespace TP2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Movie() { }

        public Guid IdGenre { get; set; }
        public Genre?  Genre { get; set; }
    }
}
