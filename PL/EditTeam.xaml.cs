#pragma warning disable CS8600, CS8602, CS8604
using MahApps.Metro.Controls;
using PL.src;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PL
{
    public partial class EditTeam : Window
    {
        private readonly PLDBContext context;
        private Team? Team { get; set; }
        public EditTeam(Team? team)
        {
            InitializeComponent();
            context = PLDBContext.Instance;
            Team = team;
        }
        public void ShowTeam()
        {
            TeamName.Text = Team?.Name;
            
            TeamLocation.Text = Team?.Location;
            TeamStadiumName.Text = Team?.StadiumName;
            TeamStadiumCapacity.Text = Team?.StadiumCapacity.ToString();

            TeamNumberOfPLTitles.Text = Team?.NumberOfPLTitles.ToString();
            TeamNumberOfWins.Text = Team?.NumberOfWins.ToString();
            TeamNumberOfLosses.Text = Team?.NumberOfLosses.ToString();
            TeamNumberOfGoalsScored.Text = Team?.NumberOfGoalsScored.ToString();

            Show();
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

        private void EditTeamSaveChanges(object sender, RoutedEventArgs e)
        {
            if(ValidateInputs(out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Greška");
                return;
            }
            try
            {
                Team? tDB = context.Teams.Single(t => t.Id == Team.Id);

                string oldTeamName = tDB.Name;
                tDB.Name = TeamName.Text;

                tDB.Location = TeamLocation.Text;
                tDB.StadiumName = TeamStadiumName.Text;
                tDB.StadiumCapacity = int.Parse(TeamStadiumCapacity.Text);

                tDB.NumberOfPLTitles = int.Parse(TeamNumberOfPLTitles.Text);
                tDB.NumberOfWins = int.Parse(TeamNumberOfWins.Text);
                tDB.NumberOfLosses = int.Parse(TeamNumberOfLosses.Text);
                tDB.NumberOfGoalsScored = int.Parse(TeamNumberOfGoalsScored.Text);

                if (!string.Equals(oldTeamName, tDB.Name)) 
                {
                    List<Player> playersOnTeam = context.Players.Where(p => p.TeamId == Team.Id).ToList();
                    foreach (Player p in playersOnTeam)
                    {
                        p.Team = TeamName.Text;
                    }
                }

                context.SaveChanges();
                Owner.FindChild<DataGrid>("TeamsDataGrid").Items.Refresh();

                MessageBox.Show("Tim uspješno izmjenjen!");
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Niste uspjeli izmijeniti tim! Greška: {ex.Message}", "Greška");
            }
        }
        private void RemoveTeam(object sender, RoutedEventArgs e)
        {
            string YesNoMessage = "Da li ste sigurni da želite ukloniti tim? Svi igrači tog tima će takođe biti izgubljeni!";
            MessageBoxResult result = MessageBox.Show(YesNoMessage, "Potvrda", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    List<Player> PlayersToRemove = context.Players.Where(p => p.TeamId == Team.Id).ToList();
                    context.Players.RemoveRange(PlayersToRemove);
                    context.Teams.Remove(Team);
                    context.SaveChanges();
                    Owner.FindChild<DataGrid>("TeamsDataGrid").ItemsSource = context.Teams.ToList();
                    Owner.FindChild<DataGrid>("PlayersDataGrid").ItemsSource = null;
                    MessageBox.Show("Tim uspješno uklonjen!");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Neuspješno uklanjanje tima! Razlog: {ex.Message}", "Greška");
                    return;
                }
            }
        }
        private bool ValidateInputs(out string errorMessage)
        {
            errorMessage = "";

            foreach (StackPanel panel in Properties.Children.OfType<StackPanel>())
            {
                if (panel.Children.OfType<TextBox>().Any(tbox => string.IsNullOrEmpty(tbox.Text)))
                {
                    errorMessage = "Greška! Nijedno polje ne smije ostati prazno!";
                    return true;
                }
            }
            return false;
        }
    }
}
