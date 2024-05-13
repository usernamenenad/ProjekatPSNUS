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
            using var context = new MyDbContext();
            Team brighton = new()
            {
                Id = 1,
                Name = "Brighton",
                StadiumName = "Brighton Stadium",
                StadiumCapacity = 69420
            };
            context.Teams.Add(brighton);

            context.SaveChanges();
        }
    }
}