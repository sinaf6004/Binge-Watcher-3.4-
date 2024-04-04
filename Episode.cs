using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binge_Watcher
{
    [Serializable]
    class Episode
    {
        int EpisodeNo;
        public int episodeNo { get => EpisodeNo; }
        int SeasonNo;
        public int seasonNo { get => SeasonNo; }

        int Duration;
        int MinutesWatched = 0;
        public Episode()
        {
            Console.Write("Episode number: ");
            EpisodeNo = int.Parse(Console.ReadLine());

            Console.Write("Season number: ");
            SeasonNo = int.Parse(Console.ReadLine());


            Console.Write("Episodes duration: ");
            Duration = int.Parse(Console.ReadLine());
        }
        public void Watch(int minutes)
        {
            MinutesWatched += minutes;
        }
        public void SetWatched(int minutes)
        {
            try
            {
                MinutesWatched = minutes;
            }
            catch
            {

            }
            }
        public void PrintProgressBar()
        {
            double per = MinutesWatched / (double)Duration;
            per *= 100;
            Console.WriteLine(per);
        }
    
    
    
    
    }
}
