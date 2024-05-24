using MahApps.Metro.Controls;
using PL.src;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class EditPlayer : Window
    {
        private readonly PLDBContext context;
        public Player? Player { get; set; }
        public EditPlayer(Player player)
        {
            InitializeComponent();
            context = PLDBContext.Instance;
            Player = player;
        }

        public void ShowPlayer()
        {
            PlayerFirstName.Text = Player?.FirstName;
            PlayerLastName.Text = Player?.LastName;

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
            if(ValidateInputs(out string errorMessage, out Team? newTeam))
            {
                MessageBox.Show(errorMessage, "Greška");
                return;
            }
            try
            {
                Player? pDB = context.Players.Single(p => p.Id == Player.Id);

                pDB.FirstName = PlayerFirstName.Text;
                pDB.LastName = PlayerLastName.Text;

                pDB.DateOfBirth = DateOnly.Parse(PlayerDateOfBirth.Text);
                pDB.Age = int.Parse(PlayerAge.Text);

                pDB.Nationality = PlayerNationality.Text;

                int oldTeamId = Player.TeamId;
                pDB.Team = PlayerTeam.Text;
                pDB.TeamId = newTeam.Id;

                pDB.Apperiances = int.Parse(PlayerApperiances.Text);
                pDB.Goals = int.Parse(PlayerGoals.Text);
                pDB.Assists = int.Parse(PlayerAssists.Text);
                pDB.JerseyNumber = int.Parse(PlayerJerseyNumber.Text);

                context.SaveChanges();
                Owner.FindChild<DataGrid>("PlayersDataGrid").ItemsSource = context.Players.Where(p => p.TeamId == oldTeamId).ToList();

                MessageBox.Show("Igrač uspješno izmjenjen!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Niste uspjeli izmijeniti igrača! Greška: {ex.Message}", "Greška!");
            }
        }
        private void RemovePlayer(object sender, RoutedEventArgs e)
        {
            string YesNoMessage = "Da li ste sigurni da želite ukloniti igrača?";
            var buttons = MessageBoxButton.YesNoCancel;
            MessageBoxResult result = MessageBox.Show(YesNoMessage, "Potvrda", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    context.Players.Remove(Player);
                    context.SaveChanges();
                    Owner.FindChild<DataGrid>("PlayersDataGrid").ItemsSource = context.Players.Where(p => p.TeamId == Player.TeamId).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Neuspješno uklanjanje igrača! Razlog: {ex.Message}", "Greška");
                    return;
                }
            }
            Close();
        }

        private bool ValidateInputs(out string errorMessage, out Team? newTeam)
        {
            errorMessage = "";
            newTeam = null;

            foreach(StackPanel panel in Properties.Children.OfType<StackPanel>())
            {
                if (panel.Children.OfType<TextBox>().Any(tbox => string.IsNullOrEmpty(tbox.Text)))
                {
                    errorMessage = "Greška! Nijedno polje ne smije ostati prazno!";
                    return true;
                }
            }
            try
            {
                Team TeamInDatabase = context.Teams.Single(t => string.Equals(t.Name, PlayerTeam.Text));
                newTeam = TeamInDatabase;
            }
            catch(Exception ex)
            {
                errorMessage = "Greška! Takav tim ne postoji u bazi podataka!";
                return true;
            }

            return false;
        }
        private void NumericalInputValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextualInputValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
