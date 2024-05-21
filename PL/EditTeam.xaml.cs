using PL.src;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for EditTeam.xaml
    /// </summary>
    public partial class EditTeam : Window
    {
        public EditTeam()
        {
            InitializeComponent();
        }
        public Team? Team { get; set; }

        public void ShowTeam(Team? t)
        {
            Team = t;
            TeamImage.Source = new BitmapImage(new Uri($"./Pictures/teams/{Team?.Name?.Replace(" ", "_").ToLower()}.png", UriKind.RelativeOrAbsolute));
            Show();
        }
    }
}
