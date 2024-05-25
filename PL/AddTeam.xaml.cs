using MahApps.Metro.Controls;
using PL.src;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PL
{
    public partial class AddTeam : Window
    {
        private readonly PLDBContext context;
        public AddTeam()
        {
            InitializeComponent();
            context = PLDBContext.Instance;
        }
        private void AddTeamSaveChanges(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs(out string errorMessage, out int TeamId))
            {
                MessageBox.Show(errorMessage, "Greška");
                return;
            }
            try
            {
                Team team = new()
                {
                    Name = TeamName.Text,
                    Location = TeamLocation.Text,
                    StadiumName = TeamStadiumName.Text,
                    StadiumCapacity = int.Parse(TeamStadiumCapacity.Text),
                    NumberOfPLTitles = int.Parse(TeamNumberOfPLTitles.Text),
                    NumberOfWins = int.Parse(TeamNumberOfWins.Text),
                    NumberOfLosses = int.Parse(TeamNumberOfLosses.Text),
                    NumberOfGoalsScored = int.Parse(TeamNumberOfGoalsScored.Text)
                };

                context.Teams.Add(team);
                context.SaveChanges();
                Owner.FindChild<DataGrid>("TeamsDataGrid").ItemsSource = context.Teams.ToList();

                MessageBox.Show("Tim uspješno dodat!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Niste uspjeli dodati igrača! Greška: {ex.Message}", "Greška!");
            }
        }
        private bool ValidateInputs(out string errorMessage, out int TeamId)
        {
            errorMessage = "";
            TeamId = -1;

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
