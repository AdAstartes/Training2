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
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;



namespace PointsFGames.View
{
    /// <summary>
    /// Interaction logic for ScoreBoard.xaml
    /// </summary>
    /// 
    public partial class ScoreBoard : Window
    {
        List<Player> globalPlayerList = new List<Player>();
        public ScoreBoard()
        {
            InitializeComponent();
            Start();

            List<Player> players = new List<Player>();
            TextSaver loader = new TextSaver("C:\\Users\\emila\\source\\repos\\AdAstartes\\Training2\\Save.csv");

            players = loader.Load();
            foreach (Player player in players)
                Games_DataGrid.Items.Add(player.GamesForDataGrid());

            globalPlayerList = players;
            ScoreBoard_Score(players);
        }
        public ScoreBoard(List<Player>? playerList)
        {
            InitializeComponent();
            Start();
            List<Player> players = new List<Player>();

            if (playerList == null || playerList.Count() == 0)
            {
                TextSaver loader = new TextSaver("C:\\Users\\emila\\source\\repos\\AdAstartes\\Training2\\Save.csv");
                players = loader.Load();
            }
            else
                players = playerList;

            foreach (Player player in players)
                Games_DataGrid.Items.Add(player.GamesForDataGrid());

            globalPlayerList = players;

            ScoreBoard_Score(players);
        }

        public void Start()
        {
            Thread autosave = new Thread(AutoSaveThread);
            autosave.IsBackground = true;
            autosave.Start();
        }

        public void ScoreBoard_Score(List<Player> playerList)
        {
            foreach (Player player in playerList)
                Score_DataGrid.Items.Add(player);

            //           foreach (Player player in globalPlayerList)
            //               MessageBox.Show(player.name+" "+player.score);

        }

        private void ComboBox_ActivePlayer_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            List<string> comboBoxList = new List<string>();

            foreach (Player player in globalPlayerList)
                comboBoxList.Add(player.name);
            combo.ItemsSource = comboBoxList;

            combo.SelectedIndex = 0;

        }

        private void ComboBox_ActivePlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedComboBoxItem = sender as ComboBox;
            string playerName = selectedComboBoxItem.SelectedItem as string;
            ComboBox_ActiveGame_Populate();
        }

        private void ComboBox_ActiveGame_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            //    ComboBox_ActiveGame_Populate();

        }

        private void ComboBox_ActiveGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedComboBoxItem = sender as ComboBox;
            string gameName = selectedComboBoxItem.SelectedItem as string;
        }

        private void ComboBox_ActiveGame_Populate()
        {
            List<string> comboBoxList = new List<string>();
            List<string> listGames = new List<string>() { "KR", "Q", "Carro", "TotalePlus", "TotaleMinus", "Wist", "Levate", "Rent", "Clubs10" };


            foreach (Player player in globalPlayerList)
                if (player.name == ComboBox_ActivePlayer.SelectedItem.ToString())
                    foreach (string game in listGames)
                        if (player.GetGame(game) == 0)
                            comboBoxList.Add(game);

            ComboBox_ActiveGame.ItemsSource = comboBoxList;
            //MessageBox.Show(globalPlayerList[0].name);
            ComboBox_ActiveGame.SelectedIndex = 0;

        }

        private void Button_GameSet_Click(object sender, RoutedEventArgs e)
        {
            int contor = 0;
            string game = ComboBox_ActiveGame.SelectedItem.ToString();
            string name = ComboBox_ActivePlayer.SelectedItem.ToString();
            foreach (Player player in globalPlayerList)
                if (player.name == name)
                {
                    player.SetGamePlayed(game, 1);
                    break;
                    //MessageBox.Show(name + " " + game);
                  //  MessageBox.Show(globalPlayerList[contor].name + " " + globalPlayerList[contor].GetGame(game));

                }
                else
                    contor += 1;

            Games_DataGrid.Items.Clear();
            foreach (Player player in globalPlayerList)
                Games_DataGrid.Items.Add(player.GamesForDataGrid());

        }

        private void ComboBox_ActivePlayer_Score_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            List<string> comboBoxList = new List<string>();

            foreach (Player player in globalPlayerList)
                comboBoxList.Add(player.name);
            
            combo.ItemsSource = comboBoxList;
            
            combo.SelectedIndex = 0;
        }

        private void TextBox_Score_KeyPress(object sender, KeyEventArgs e)
        {
            int addScore = 0;
            int contor = 0;
            string name = null;
            if (e.Key == Key.Enter)
                addScore = Int32.Parse(TextBox_Score.Text);

            name = ComboBox_ActivePlayer_Score.SelectedItem.ToString();
            foreach (Player player in globalPlayerList)
                if (player.name == name)
                {
                    player.score += addScore;                 

                }
                else
                    contor += 1;

            Score_DataGrid.Items.Clear();
            foreach (Player player in globalPlayerList)
                Score_DataGrid.Items.Add(player);

        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveGame();
        }

        private void SaveGame()
        {
            TextSaver file = new TextSaver("C:\\Users\\emila\\source\\repos\\AdAstartes\\Training2\\Save.csv");
            file.Save(globalPlayerList);
        }

        private void Score_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void AutoSaveThread()
        { 
            while(true)
            {
                Thread.Sleep(10000);
                SaveGame();

            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            Environment.Exit(Environment.ExitCode);
        }
    }
}

/*    */