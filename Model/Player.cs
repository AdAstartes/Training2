using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PointsFGames.Model
{
    internal class Player
    {
        private static List<string> listGames = new List<string>() { "KR", "Q", "Carro", "Totale+", "Totale-", "Wist", "Levate", "Rent", "Clubs10" };
        public string name { get; set; }
        public int score { get; set; } = 100;
        public Dictionary<string, int> gamesPlayed;
        public static Dictionary<string, int> gameReader(string games)
        {
            Dictionary<string, int> gamesPlayed = new Dictionary<string, int>();    
            var scores = games.Split(",");
            foreach (var game in listGames.Select((x, i) => new { Value = x, Index = i }))
            {
                gamesPlayed[game.Value] = Int32.Parse(scores[game.Index]);
            }
            return gamesPlayed;
        }

        public Player(string name)
        {
            this.name = name;
            PopulateGames();
        }
        public Player(string name, int score, Dictionary<string, int> gamesPlayed)
        {   
            this.name =name;
            this.score = score;
            this.gamesPlayed = gamesPlayed;
        }

        private void PopulateGames()
        {
            gamesPlayed = new Dictionary<string, int>();
            listGames.ForEach(game => gamesPlayed.Add(game, 0));
            gamesPlayed["Levate"] = -1;
            gamesPlayed["Totale+"] = -1;
            gamesPlayed["Clubs10"] = -1;

        }

        public string ReadGames()
        {
            string games;
            List<string> buffer= new List<string>();
            foreach (var game in listGames)
                buffer.Add(gamesPlayed[game].ToString());
            games = String.Join(",",buffer);

            return games;

        }

        public void Show()
        {
            string result = "\n" + name + " " + score;
            foreach (var g in gamesPlayed)
            {
                if (g.Value > -1)
                    result += " " + g.Key;
                
            }

            MessageBox.Show(result);

        }
    }
}
