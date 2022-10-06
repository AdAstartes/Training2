using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PointsFGames.Controller;
using PointsFGames.View;
using PointsFGames.Model;

namespace PointsFGames.View
{
    /// <summary>
    /// Interaction logic for ScoreBoard.xaml
    /// </summary>
    public partial class ScoreBoard : Window
    {
        public ScoreBoard()
        {
            InitializeComponent();

            List<Player> players = new List<Player>();
            TextSaver loader = new TextSaver("C:\\Users\\emila\\source\\repos\\AdAstartes\\Training2\\Save.csv");

            players = loader.Load("C:\\Users\\emila\\source\\repos\\AdAstartes\\Training2\\Save.csv");
            TextSaver loader = new TextSaver("C:\\Users\\emila\\source\\repos\\AdAstartes\\Training2\\Save.csv");
            
            players = loader.Load();
            foreach (Player player in players)
                Games_DataGrid.Items.Add(player.GamesForDataGrid());
        }
        public ScoreBoard(List<Player>? playerList)
        {
            InitializeComponent();
            List<Player> players = new List<Player>();

            if (playerList == null || playerList.Count()==0)
            {
                TextSaver loader = new TextSaver("C:\\Users\\emila\\source\\repos\\AdAstartes\\Training2\\Save.csv");
                players = loader.Load();
            }
            else
                players = playerList;
            
            foreach(Player player in players)
                Games_DataGrid.Items.Add(player);


            
             
                Games_DataGrid.Items.Add(player.GamesForDataGrid());
            
        }
    }
}
