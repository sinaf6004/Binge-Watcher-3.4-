using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Binge_Watcher
{
    class DataSerializer
    {
        //public static void SerializeMovies(string fileName)
        //{
        //    string jsonString = JsonSerializer.Serialize(Movie.Movies, new JsonSerializerOptions { WriteIndented = true });
        //    File.WriteAllText(fileName + ".json", jsonString);
        //}
        //public static void SerializeSeries(string fileName)
        //{
        //    string jsonString = JsonSerializer.Serialize(Series.series);
        //    File.WriteAllText("Data.json", jsonString);
        //}
        //public static void DeserializeMovies(string filename)
        //{
        //    string jsonString = File.ReadAllText(filename + ".json");
        //    Movie.Movies = JsonSerializer.Deserialize<List<Movie>>(jsonString);
        //}
        //public static void DeserializeSeries(string filename)
        //{
        //    string jsonString = File.ReadAllText("Data.json");
        //    Series.series = JsonSerializer.Deserialize<List<Series>>(jsonString);
        //}
        public static void SerializeSeries()
        {
            FileStream stream = new FileStream(@"D:\elmos\AP\homeworks\tamrin 3\Binge Watcher\Binge Watcher\bin\Debug\SaveFile\Series.txt", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, Series.series);
            stream.Close();
        }
        public static void SerializeMovies()
        {
            FileStream stream = new FileStream(@"D:\elmos\AP\homeworks\tamrin 3\Binge Watcher\Binge Watcher\bin\Debug\SaveFile\Movies.txt", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, Movie.Movies);
            stream.Close();
        }
        public static void DeserializeSeries()
        {
            FileStream fs = File.Open(@"D:\elmos\AP\homeworks\tamrin 3\Binge Watcher\Binge Watcher\bin\Debug\SaveFile\Series.txt", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            Series.series = (List<Series>)formatter.Deserialize(fs);
            fs.Close();

        }
        public static void DeserializeMovies()
        {
            FileStream fs = File.Open(@"D:\elmos\AP\homeworks\tamrin 3\Binge Watcher\Binge Watcher\bin\Debug\SaveFile\Movies.txt", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            Movie.Movies = (List<Movie>)formatter.Deserialize(fs);
            fs.Close();

        }





    }
}
