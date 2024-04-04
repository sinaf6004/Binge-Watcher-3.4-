using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
namespace Binge_Watcher
{
    public class Options
    {
        [Option("add-movie", Required = false, HelpText = "Adds a movie")]
        public bool AddMovie { get; set; }
        [Option("add-series", Required = false, HelpText = "Adds a series")]
        public bool AddSeries { get; set; }
        [Option("list-movies", Required = false, HelpText = "list movies")]
        public bool ListMovies { get; set; }
        [Option("list-series", Required = false, HelpText = "list series")]
        public bool ListSeries { get; set; }

        [Option("info-movies", Required = false, HelpText = "Shows an info of a movie")]
        public bool InfoMovies { get; set; }

        [Option("info-series", Required = false, HelpText = "Shows an info of a series")]
        public bool InfoSeries { get; set; }

        [Option("watch-movie", Required = false, HelpText = "increases the watched time of movie")]
        public bool watchMovie { get; set; }

        [Option("watch-series", Required = false, HelpText = "increases the watched time of series")]
        public bool watchSeries { get; set; }


        [Option("add-episode-series", Required = false, HelpText = "Add Episode to a series")]
        public bool AddEpisode { get; set; }


        //values
        [Value(0, MetaName = "1", Required = false, HelpText = "Id of the movie or the serie")]
        public int one { get; set; }

        [Value(1, MetaName = "2", Required = false, HelpText = "Adds the minutes to the watched time or the season for the watch-movie")]
        public int two { get; set; }

        [Value(1, MetaName = "3", Required = false, HelpText = "sepecifies the season of the series")]
        public int three { get; set; }

        [Value(2, MetaName = "4", Required = false, HelpText = "sepecifies the episode of the season")]
        public int four { get; set; }

        //[Value(3, MetaName = "5", Required = false, HelpText = "Adds the minutes to the watched time")]
        //public int Minutes { get; set; }
    }
    class Program
    {
        public static DateTime datetimeValueGiving()
        {
            DateTime date;
            Console.Write("Year: ");
            int Year = int.Parse(Console.ReadLine());
            Console.Write("Month: ");
            int Month = int.Parse(Console.ReadLine());
            Console.Write("Day: ");
            int Day = int.Parse(Console.ReadLine());
            date = new DateTime(Year, Month, Day);
            return date;
        }
        static void Main(string[] args)
        {
            try
            {
                DataSerializer.DeserializeMovies();
            }
            catch
            {

            }
            try
            {
                DataSerializer.DeserializeSeries();
            }
            catch
            {

            }
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    if (o.AddMovie)
                    {
                        new Movie();
                    }
                    else if (o.AddSeries)
                    {
                        Series.AddSeries();

                    }
                    else if (o.ListMovies)
                    {
                        Movie.ShowInfo();
                    }
                    else if (o.ListSeries)
                    {
                        Series.ShowInfo();
                    }
                    else if (o.InfoMovies)
                    {
                        if (o.one != 0)
                        {
                            Movie.ShowInfo(o.one);

                        }
                    }
                    else if (o.InfoSeries)
                    {
                        if (o.one != 0)
                        {
                            Series.ShowInfo();
                        }
                    }
                    else if (o.watchMovie)
                    {
                        if (o.one != 0)
                        {
                            if (o.two != 0)
                            {
                                Movie.GetMovie(o.two).Watch(o.two);
                            }
                        }
                    }
                    else if (o.AddEpisode)
                    {
                        if (o.one != 0)
                        {
                            if (o.two != 0)
                            {
                                if (o.three != 0)
                                {
                                    if (o.three != 0)
                                    {
                                        Console.WriteLine("xxx");
                                        Series.GetSeries(o.one).GetEpisode(o.two, o.three).Watch(o.four);
                                    }
                                }
                            }
                        }
                    }
                    else if (o.AddEpisode)
                    {
                        Console.Write("Id: ");
                        Series.GetSeries(int.Parse(Console.ReadLine())).AddEpisode(new Episode());

                    }
                    else
                    {
                        Console.WriteLine("Nothing");
                    }
                });

            //new Movie();
            //Series.AddSeries();
            DataSerializer.SerializeMovies();
            DataSerializer.SerializeSeries();
        }
    }
}
