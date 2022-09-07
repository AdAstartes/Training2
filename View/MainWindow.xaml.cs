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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PointsFGames.Controller;


namespace PointsFGames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerRegForm registry = new PlayerRegForm();
            registry.Show();
            this.Close();
        }

        private void ScoreModesButton_Click(object sender, RoutedEventArgs e)
        {
            ScoringRules scoringRules = new ScoringRules();
            scoringRules.Show();
        }

        private void DebugButton_Click(object sender, RoutedEventArgs e)
        {
            ControllerPointGames controllerPointGames = new ControllerPointGames();
            controllerPointGames.Start();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            TextSaver file = new TextSaver("E:\\.coding Tutorial\\PointsFGames\\Save.txt");
            file.Save(new List<Player>() { new Player("Emil"), new Player ("Bobo") });

        }
    }
}

//E:\.coding Tutorial\PointsFGames\Controller\Save.txt
