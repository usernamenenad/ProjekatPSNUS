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
            List<Team> teams = new();
            teams.Add(new Team()
            {
                Id = 1,
                Name = "Brighton",
                Location = "Brighton",
                StadiumName = "Lokl",
                StadiumCapacity = 0,
            });
            teams.Add(new Team()
            {
                Id = 1,
                Name = "Neso",
                Location = "Trnova",
                StadiumName = "Lokl",
                StadiumCapacity = 0,
            });
            TeamsDataGrid.ItemsSource = teams;
        }
    }
}