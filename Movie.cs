using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binge_Watcher
{
    [Serializable]
    class Movie
    {
        int ID;
        public static List<Movie> Movies = new List<Movie>();
        string Title;
        string Director;
        DateTime ReleaseTime;
        int Duration;
        string Genre;
        double Rating;
        int MinutesWatched = 0;
 
        public Movie()
        {
            Console.Write("Title: ");
            Title = Console.ReadLine();
            Console.Write("Director: ");
            Director = Console.ReadLine();
            Console.Write("ReleaseDate: ");
            ReleaseTime = Program.datetimeValueGiving();
            Console.Write("Duration: ");
            Duration = int.Parse(Console.ReadLine());
            Console.Write("Genre: ");
            Genre = Console.ReadLine();
            Console.Write("Rating: ");
            Rating = double.Parse(Console.ReadLine());
            ID = GetNewId();
            Movies.Add(this);
        }
        public void Watch(int minutes)
        {
            MinutesWatched += minutes;
        }
        public void SetWatched(int minutes)
        {
            MinutesWatched = minutes;
        }
        public static void ShowInfo(int ID)
        {
            foreach (var movie in Movies)
            {
                if (movie.ID == ID)
                {
                    Console.WriteLine($"ID: { movie.ID}, Title: { movie.Title}, Director: { movie.Director}, Watched time: {movie.MinutesWatched}");
                    break;
                }
            }
        }
        public static void ShowInfo()
        {
            foreach (var movie in Movies)
            {
                    Console.WriteLine($"ID: { movie.ID}, Title: { movie.Title}, Director: { movie.Director}, Watched time: {movie.MinutesWatched}");
            }
        }
        public static void Add(Movie movie)
        {
            Movies.Add(movie);
        }
    
        public static void Remove(int ID)
        {
            foreach (var movie in Movies)
            {
                if (movie.ID == ID)
                {
                    Movies.Remove(movie);
                    break;
                }
            }
        }
        static int GetNewId()
        {
            int max = 1;
            foreach(var movie in Movies)
            {
                if(movie.ID > max)
                {
                    max = movie.ID;
                }
            }
            return max;
        }
        public static Movie GetMovie(int ID)
        {
            foreach (var movie in Movies)
            {
                if (movie.ID == ID)
                {
                    return movie;
                }
            }
            return null;
        }
        public void PrintProgressBar()
        {
            double per = MinutesWatched / (double)Duration;
            per *= 100;
            Console.WriteLine(per);
        }
        public static void ChangePrimary()
        {
            for(int i = 0; i< Movies.Count; i++)
            {
                Movies[i].ID = i + 1;
            }
        }
    }
}
