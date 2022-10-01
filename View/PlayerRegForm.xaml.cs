using PointsFGames.Model;
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

namespace PointsFGames
{
    /// <summary>
    /// Interaction logic for PlayerRegForm.xaml
    /// </summary>
    public partial class PlayerRegForm : Window
    {
        int playerNo = 0;
        List<Player> playerList = new List<Player>();
        public class Item { public string NoPlayer { get; set;} 
                            public string PlayerList { get; set; }
        }
        List<Item> itemList = new List<Item>();
        public PlayerRegForm()
        {
            InitializeComponent();
        }

        private void ComboBox_Selecteditem(object sender, SelectionChangedEventArgs e)
        {
            playerNo = Int32.Parse((PlayerCountComboBox.SelectedItem.ToString().Split(" ")[1]));
        }

        private void Selection(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && playerList.Count() >= playerNo)
                MessageBox.Show("TBA");

            if (e.Key == Key.Enter && playerList.Count()<playerNo)
            {
                playerList.Add(new Player (AddPlayerBox.Text));
                AddPlayerBox.Clear();
                itemList.Add(new Item() { NoPlayer = playerList.Count().ToString(), PlayerList = playerList[playerList.Count() - 1].name });
                PlayerListDataGrid.ItemsSource = itemList.ToArray();
               
            }
            
            if (e.Key == Key.Enter && playerList.Count() >= playerNo)
                MessageBox.Show("All players have been added");

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            TextSaver file = new TextSaver("E:\\.coding Tutorial\\PointsFGames\\Save.csv");
            TextSaver loader = new TextSaver("E:\\.coding Tutorial\\PointsFGames\\Save.csv");
            
            file.Save(playerList);
            ScoreBoard gameStart = new ScoreBoard();
            
            if ((bool)LevateCheckBox.IsChecked)
                OptionalGame("Levate");
            if ((bool)TotalePlusCheckBox.IsChecked)
                OptionalGame("Totale+");
            if ((bool)Clubs10CheckBox.IsChecked)
                OptionalGame("Clubs10");

            file.Save(playerList);
       //     loader.Load("E:\\.coding Tutorial\\PointsFGames\\Load.csv");

            gameStart.Show();
            this.Close();
        }
        private void OptionalGame(string game)
        {
            foreach (Player player in playerList)
                player.gamesPlayed[game] = 0;

        }
    }
}
//    PlayerListDataGrid.Items.Add(new Item() { NoPlayer = playerList.Count().ToString(), PlayerList = playerList[playerList.Count()-1].name });
//    playerList.ToString();