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
            string location = $"./Pictures/players/{Player?.FirstName?.ToLower()}_{Player?.LastName?.ToLower()}.png";
            Uri uri = new(location, UriKind.RelativeOrAbsolute);
            PlayerImage.Source = new BitmapImage(uri);
            PlayerLastName.Text = Player?.LastName;
            PlayerFirstName.Text = Player?.FirstName;
            PlayerDateOfBirth.Text = Player?.DateOfBirth.ToShortDateString();
            PlayerAge.Text = Player?.Age.ToString();
            PlayerNationality.Text = Player?.Nationality;
            PlayerTeam.Text = Player?.Team;
            PlayerApperiances.Text = Player?.Apperiances.ToString();
            PlayerGoals.Text = Player?.Goals.ToString();
            PlayerAssists.Text = Player?.Assists.ToString();
            PlayerJerseyNumber.Text = Player?.JerseyNumber.ToString();
            Show();
        }

        private void EditPlayerSaveChanges(object sender, RoutedEventArgs e)
        {
            if(ValidateInputs(out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Error");
            }
        }

        private bool ValidateInputs(out string errorMessage)
        {
            bool isError = false;
            errorMessage = "";

            foreach(StackPanel panel in Properties.Children.OfType<StackPanel>())
            {
                if (panel.Children.OfType<TextBox>().Any(tbox => string.IsNullOrEmpty(tbox.Text)))
                {
                    isError = true;
                    errorMessage = "No field should be empty!";
                    break;
                }
            }
            return isError;
        }
    }

}
