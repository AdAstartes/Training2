using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace PointsFGames.Model
{
    internal class GamesTable
    {
        private int KR;
        private int Q;
        private int Carro;
        private int TotalePlus;
        private int TotaleMinus;
        private int Wist;
        private int Levate;
        private int Rent;
        private int Clubs10; 
         
        public GamesTable(int KR, int Q, int Carro, int TotalePlus, int TotaleMinus, int Wist, int Levate, int Rent, int Clubs10)
        {
            this.KR = KR;
            this.Q = Q;
            this.Carro = Carro;
            this.TotalePlus = TotalePlus;
            this.TotaleMinus = TotaleMinus;
            this.Wist = Wist;
            this.Levate = Levate;
            this.Rent = Rent;
            this.Clubs10 = Clubs10;


        }
        public GamesTable(string games)
        {
            var gameList = games.Split(",");
            this.KR = Int32.Parse(gameList[0]);
            this.Q = Int32.Parse(gameList[1]);
            this.Carro = Int32.Parse(gameList[2]);
            this.TotalePlus = Int32.Parse(gameList[3]);
            this.TotaleMinus = Int32.Parse(gameList[4]);
            this.Wist = Int32.Parse(gameList[5]);
            this.Levate = Int32.Parse(gameList[6]);
            this.Rent = Int32.Parse(gameList[7]);
            this.Clubs10 = Int32.Parse(gameList[8]);
        }
        public int GetGame(string game)
        {
            switch (game)
            {
                case "KR":
                    return this.KR;
                    break;
                case "Q":
                    return this.Q;
                    break;
                case "Carro":
                    return this.Carro;
                    break;
                case "TotalePlus":
                    return this.TotalePlus;
                    break;
                case "TotaleMinus":
                    return this.TotaleMinus;
                    break;
                case "Wist":
                    return this.Wist;
                    break;
                case "Levate":
                    return this.Levate;
                    break;
                case "Rent":
                    return this.Rent;
                    break;
                case "Clubs10":
                    return this.Clubs10;
                    break;
                default: throw new ArgumentException("Invalid Game name provided: "+game);
            }
        }
        public void SetGame(string game, int value) 
        {
            if (value != -1 && value != 1 && value != 0) throw new ArgumentException("Invalid game value provided: "+value);
            switch (game)
            {
                case "KR":
                    this.KR=value;
                    break;
                case "Q":
                    this.Q = value;
                    break;
                case "Carro":
                    this.Carro = value;
                    break;
                case "TotalePlus":
                    this.TotalePlus = value;
                    break;
                case "TotaleMinus":
                    this.TotaleMinus = value;
                    break;
                case "Wist":
                    this.Wist = value;
                    break;
                case "Levate":
                    this.Levate = value;
                    break;
                case "Rent":
                    this.Rent = value;
                    break;
                case "Clubs10":
                    this.Clubs10 = value;
                    break;
                default: throw new ArgumentException("Invalid Game name provided: " +game+" "+ (game=="Clubs10").ToString());
            }
        }
        public object ItemForDataGrid(string name)
        {
            return new { name=name, KR=this.KR, Q=this.Q, Carro=this.Carro, TotalePlus=this.TotalePlus, TotaleMinus=this.TotaleMinus,
                        Wist=this.Wist, Levate=this.Levate, Rent=this.Rent, Clubs10=this.Clubs10};
        }
    
    }

}
