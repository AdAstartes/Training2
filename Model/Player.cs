using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PointsFGames.Model
{
    public class Player
    {
        private static List<string> listGames = new List<string>() { "KR", "Q", "Carro", "TotalePlus", "TotaleMinus", "Wist", "Levate", "Rent", "Clubs10" };
        public string name { get; set; }
        public int score { get; set; } = 0;

        private GamesTable gamesPlayed;

        public Player(string name)
        {
            this.name = name;
            PopulateGames();
        }

        public Player(string name, int score, string gamesPlayed)
        {   
            this.name =name;
            this.score = score;
            this.gamesPlayed = new GamesTable(gamesPlayed);
        }

        public int GetGame(string game)
        {
            try
            {
                return this.gamesPlayed.GetGame(game);
            }
            catch (ArgumentException e) {
                throw e;
            }
         }


        public void SetGamePlayed(string game, int value)
        {
            try
            {
                this.gamesPlayed.SetGame(game, value);
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }

        public object GamesForDataGrid()
        {
            return this.gamesPlayed.ItemForDataGrid(name);
        }

        public string ReadGames()
        {
            string games;
            List<string> buffer = new List<string>();
            foreach (var game in listGames)
                buffer.Add(gamesPlayed.GetGame(game).ToString());
            games = String.Join(",", buffer);

            return games;

        }

        private void PopulateGames()
        {
            gamesPlayed = new GamesTable(0,0,0,-1,0,0,-1,0,-1);
        }
        
    }
}
