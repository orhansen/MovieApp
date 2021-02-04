using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//This is a class that creates a list of the movie objects. It continues to append the objects on it and stores for as long as the
//program is running. Temporary storage to display the list of films.
namespace MovieApp.Models
{
    public static class TempStorage
    {
        private static List<MovieResponse> movies = new List<MovieResponse>();

        public static IEnumerable<MovieResponse> Movies => movies;

        public static void AddMovie(MovieResponse movie)
        {
            movies.Add(movie);
        }
    }
}
