using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myNumbers = new List<int>() { 0, 1, 1, 2, 3, 5, 6, 12, 13, 20 };

            /*var myNumbersOver5 = new List<int>();

            foreach (var number in myNumbers)
            {
                if (number > 5) myNumbersOver5.Add(number);
            }*/

            var myNumbersOver5 = myNumbers.Where(n => n > 5);

            ///////////////////////////////////////////

            var gameList = new List<Game>()
            {
                new Game(Name: "Death Stranding", ReleaseDate: new DateTime(2019, 11, 8), SteamScore: 9),
                new Game(Name: "Dark Souls 3", ReleaseDate: new DateTime(2015, 3, 24), SteamScore: 9),
                new Game(Name: "Cyberpunk 2077", ReleaseDate: new DateTime(2020, 9, 17), SteamScore: 7),
                new Game(Name: "Valheim", ReleaseDate: new DateTime(2021, 2, 2), SteamScore: 10),
            };

            bool allHave9ScoreOrBetter = gameList.All(g => g.SteamScore > 9);

            List<string> gameNames = gameList.Select(g => g.Name).ToList();

            Game gameWithScoreOf2 = gameList.FirstOrDefault(g => g.SteamScore == 2);
        }
    }
    public static class Helpers
    {
        // пишем собственный лямбда метод
        public static IEnumerable<Game> AddRatingToNames(this IEnumerable<Game> games)
        {
            foreach (var game in games)
            {
                game.Name = $"{game.Name} - {game.SteamScore}";
            }
            return games;
        }
    }
    public class Game
    {
        public string Name;
        public DateTime ReleaseDate;
        public float SteamScore;

        public Game(string Name, DateTime ReleaseDate, float SteamScore) 
        { 
            this.Name = Name;
            this.ReleaseDate = ReleaseDate;
            this.SteamScore = SteamScore;
        }
    }
}
