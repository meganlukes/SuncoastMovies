using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SuncoastMovies
{
    class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PrimaryDirector { get; set; }
        public int YearReleased { get; set; }
        public string Genre { get; set; }
    }
    class SuncoastMoviesContext : DbContext  //Colon means is a kind of, so SuncoastMoviesContext is a kind of Database Context

    {
        public DbSet<Movie> Movies { get; set; } //Movies is table
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=SuncoastMovies");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SuncoastMoviesContext();
            var moviesCount = context.Movies.Count();
            Console.WriteLine($"There are {moviesCount} movies!");
        }
    }
}
