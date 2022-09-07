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
        private static List<string> strings = new List<string>() { "KR", "Q", "Carro", "Totale+", "Totale-", "Wist", "Levate", "Rent", "Clubs10" };
        public string name { get; set; }
        public int score { get; set; }
        public Dictionary<string, int> gamesPlayed;

        public Player(string name)
        {
            this.name = name;
            PopulateGames();
        }

        private void PopulateGames()
        {
            gamesPlayed = new Dictionary<string, int>();
            strings.ForEach(game => gamesPlayed.Add(game, 0));
            gamesPlayed["Levate"] = -1;
            gamesPlayed["Totale+"] = -1;
            gamesPlayed["Clubs10"] = -1;

        }

        public string ReadGames()
        {
            string games;
            List<string> buffer= new List<string>();
            foreach (var game in strings)
                buffer.Add(gamesPlayed[game].ToString());
            games = String.Join(",",buffer);

            return games;

        }

        public void Show()
        {
            string result = "\n" + name + " " + score;
            //            Console.WriteLine("\n" + name);
            //           Console.WriteLine(score);
            foreach (var g in gamesPlayed)
            {
                if (g.Value > -1)
                    result += " " + g.Key;
                //                 Console.WriteLine(g.Key);
            }

            MessageBox.Show(result);

        }
    }
}
