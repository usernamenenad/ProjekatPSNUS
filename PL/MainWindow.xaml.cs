using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PL.src;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PLDBContext context;
        public MainWindow()
        {
            InitializeComponent();
            context = PLDBContext.Instance;
            TeamsDataGrid.ItemsSource = context.Teams.ToList();
        }

        private void TeamsDataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Team? team = (sender as DataGridRow)?.DataContext as Team;

            EditTeam editTeam = new()
            {
                Owner = this
            };
            editTeam.ShowTeam(team);
        }

        private void PlayersDataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Player? player= (sender as DataGridRow)?.DataContext as Player;

            EditPlayer editPlayer = new()
            {
                Owner = this
            };
            editPlayer.ShowPlayer(player);
        }

        private void TeamsRowSelected(object sender, RoutedEventArgs e)
        {
            Team? team = (sender as DataGridRow)?.DataContext as Team;
            var teamname = team.Name;
            var teamPlayers = context.Players.Where(p => p.Team == team.Name).ToList();
            PlayersDataGrid.ItemsSource = teamPlayers;
        }
    }
}