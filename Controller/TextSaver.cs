using PointsFGames.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            file.Close();
        }
        public List<Player> Load(string path2)
        {   
            List<Player> lines = new List<Player>();
            
            TextSaver test = new TextSaver(path2);

            foreach (string line in System.IO.File.ReadLines(this.path))
            {
              
                List<string> player = line.Split(',').ToList();
                string name = player[0];
                int score = Int32.Parse(player[^1]);
                player = player.GetRange(1, player.Count()-2);

                Dictionary<string, int> games = Player.gameReader(String.Join(',', player));

                lines.Add(new Player(name, score, games));
            }

            
          
            return lines; 
        } 
    }

}
