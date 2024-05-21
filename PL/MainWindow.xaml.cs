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
        public MainWindow()
        {
            InitializeComponent();
            PLDBContext context = PLDBContext.Instance;
            TeamsDataGrid.ItemsSource = context.Teams.ToList();
            PlayersDataGrid.ItemsSource = context.Players.ToList();
        }

        private void TeamsDataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Team? team = (sender as DataGridRow)?.DataContext as Team;

            var editTeams = new EditTeam();
            editTeams.Owner = this;
            editTeams.ShowTeam(team);
        }

        private void PlayersDataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Player? player= (sender as DataGridRow)?.DataContext as Player;

            var editPlayers = new EditPlayer();
            editPlayers.Owner = this;
            editPlayers.ShowPlayer(player);
        }
    }
}