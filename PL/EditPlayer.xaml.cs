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
    /// Interaction logic for EditPlayer.xaml
    /// </summary>
    public partial class EditPlayer : Window
    {
        public EditPlayer()
        {
            InitializeComponent();
        }
        public Player? Player { get; set; }

        public void ShowPlayer(Player? p)
        {
            Player = p;
            var uri = new Uri($"./Pictures/players/{Player?.FirstName?.ToLower()}_{Player?.LastName?.ToLower()}.png", UriKind.RelativeOrAbsolute);
            PlayerImage.Source = new BitmapImage(uri);
            Show();
        }
    }

}
