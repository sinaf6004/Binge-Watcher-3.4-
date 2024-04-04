using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Binge_Watcher
{
    [Serializable]
    class Series
    {
        //episodes was not in the document

        int ID;
        List<Episode> WatchedEpisodes = new List<Episode>();
        public static List<Series> series = new List<Series>();
        string Title;
        string Director;
        DateTime ReleaseData;
        int Duration;
        string Genre;
        double Rating;
        int Season;
        int Episodes;


        //constructor
        public static void AddSeries()
        {
            Series series = new Series();
            Console.Write("Title: ");
            series.Title = Console.ReadLine();
            Console.Write("Director: ");
            series.Director = Console.ReadLine();
            Console.Write("ReleaseDate: ");
            series.ReleaseData = Program.datetimeValueGiving();
            Console.Write("Duration: ");
            series.Duration = int.Parse(Console.ReadLine());
            Console.Write("Genre: ");
            series.Genre = Console.ReadLine();
            Console.Write("Rating: ");
            series.Rating = double.Parse(Console.ReadLine());
            Console.Write("Season: ");
            series.Season = int.Parse(Console.ReadLine());
            Console.Write("Episodes number: ");
            series.Episodes = int.Parse(Console.ReadLine());
            series.ID = GetNewId();
            Series.series.Add(series);
        }



        //Methods
        public Episode GetEpisode(int season, int episodeNo)
        {
            foreach(Episode episode in WatchedEpisodes)
            {
                if((episode.seasonNo == season) && (episode.episodeNo == episodeNo))
                {
                    return episode;
                }
            }
            return null;
        }


        public static void ShowInfo(int ID)
        {
            foreach (var serie in series)
            {
                if (serie.ID == ID)
                {//fill this
                    Console.WriteLine($"ID: {serie.ID}, Title: {serie.Title}, Director: {serie.Director}");
                    break;
                }
            }
        }
        public static void ShowInfo()
        {
            foreach (var serie in series)
            {
                Console.WriteLine($"ID: {serie.ID}, Title: {serie.Title}, Director: {serie.Director}");
            }
        }
        public static void Add(Series series)
        {
            Series.series.Add(series);
        }
        public void Rmove(int ID)
        {

            foreach (var movie in series)
            {
                if (movie.ID == ID)
                {
                    series.Remove(movie);
                    break;
                }
            }
        }

        static int Id = 0;
        static int GetNewId()
        {
            int Id = Series.Id;
            Series.Id++;
            return Id;
        }

        public void AddEpisode(Episode episode)
        {
            WatchedEpisodes.Add(episode);
        }

        public static Series GetSeries(int ID)
        {
            foreach (var series in series)
            {
                if (series.ID == ID)
                {
                    return series;
                }
            }
            return null;
        }



        public void PrintProgressBar()
        {
            foreach (var episode in WatchedEpisodes)
            {
                episode.PrintProgressBar();
            }
        }



        public static void ChangePrimary()
        {
            for (int i = 0; i < series.Count; i++)
            {
                series[i].ID = i + 1;
            }
        }



    }
}
