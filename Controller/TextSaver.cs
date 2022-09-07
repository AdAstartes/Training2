using PointsFGames.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            file.Close();
        }
        public List<Player> Load()
        { 
            return new List<Player>(); 
        } 
    }

}
