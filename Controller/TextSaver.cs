using PointsFGames.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.ComponentModel;
//using System.Windows;

namespace PointsFGames.Controller
{
    internal class TextSaver
    {
        string path;
        public TextSaver(string path)
        {
            this.path = path;
        }
        public void Save(List<Player> playerList)
        { 
            using StreamWriter file = new (path);
            //file.Write("asd");
            List<string> lines = new List<string>();      
            
            foreach (Player player in playerList)
                lines.Add(player.name + "," + player.ReadGames() + "," + player.score);

            foreach (string line in lines)
                file.WriteLine(line.ToArray());
            // file.WriteLine("String line ");
            file.Flush();
            
            file.Close();
            
        }
        public List<Player> Load()
        {
            try
            {
                using (var dummy = File.OpenWrite(this.path))
                {
                    dummy.Close();
                }
            }
            catch (Exception) { }
            List<Player> players = new List<Player>();

            var lines = System.IO.File.ReadAllLines(this.path);
            foreach (string line in lines)
            {
              
                List<string> player = line.Split(',').ToList();
                string name = player[0];
                int score = Int32.Parse(player[^1]);
                player = player.GetRange(1, player.Count()-2);
//                string str = String.Join(",", player);
//                MessageBox.Show(str);

                players.Add(new Player(name, score, String.Join(',',player)));
            }

            
            
            return players; 
        } 
    }

}
