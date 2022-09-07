using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsFGames.Model
{
    internal class ControllerPointGames
    {
        public void Start()
        {
            List<Player> playerList = new List<Player>();
            int tPlus = -1, Levate = -1, Clubs10 = -1;
            GameInitialization(ref tPlus, ref Levate, ref Clubs10);

            Console.WriteLine("\nHow many Players?");
            int noPlayers = int.Parse("2");
            for (int i = 0; i < noPlayers; i += 1)
            {
                Console.WriteLine($"Player {i + 1}: ");
                playerList.Add(new Player("Player Default" + i));
                playerList[i].gamesPlayed["Totale+"] = tPlus;
                playerList[i].gamesPlayed["Levate"] = Levate;
                playerList[i].gamesPlayed["Clubs10"] = Clubs10;
            }

            foreach (var p in playerList)
                p.Show();
        }
        public static void GameInitialization(ref int tMinus, ref int Levate, ref int Clubs10)
        {
            // Console.WriteLine("0 - No, 1 - Yes");
            // Console.WriteLine("Choose extra games");

            //  Console.Write("\nTotale+: ");
            int keyPress;
            keyPress = int.Parse("1");
            if (keyPress != 0)
                tMinus = 0;

            //   Console.Write("Levate: ");
            keyPress = int.Parse("1");
            if (keyPress != 0)
                Levate = 0;

            //   Console.Write("10 of Clubs: ");
            keyPress = int.Parse("1");
            if (keyPress != 0)
                Clubs10 = 0;
        }

    }

}
