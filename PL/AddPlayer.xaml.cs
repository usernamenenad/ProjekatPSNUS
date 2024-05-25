using MahApps.Metro.Controls;
using PL.src;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PL
{
    public partial class AddPlayer : Window
    {
        private readonly PLDBContext context;
        public AddPlayer()
        {
            InitializeComponent();
            context = PLDBContext.Instance;
            PlayerTeam.ItemsSource = context.Teams.Select(t => t.Name).ToList();
        }
        private void AddPlayerSaveChanges(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs(out string errorMessage, out int TeamId))
            {
                MessageBox.Show(errorMessage, "Greška");
                return;
            }
            try
            {
                Player newPlayer = new()
                {
                    FirstName = PlayerFirstName.Text,
                    LastName = PlayerLastName.Text,
                    DateOfBirth = DateOnly.Parse(PlayerDateOfBirth.Text),
                    Age = int.Parse(PlayerAge.Text),
                    Nationality = PlayerNationality.Text,
                    Team = PlayerTeam.Text,
                    TeamId = TeamId,
                    Apperiances = int.Parse(PlayerApperiances.Text),
                    Goals = int.Parse(PlayerGoals.Text),
                    Assists = int.Parse(PlayerAssists.Text),
                    JerseyNumber = int.Parse(PlayerJerseyNumber.Text)
                };

                context.Players.Add(newPlayer);
                context.SaveChanges();
                Owner.FindChild<DataGrid>("PlayersDataGrid").ItemsSource = context.Players.Where(p => p.TeamId == TeamId).ToList();

                MessageBox.Show("Igrač uspješno dodat!");
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
            var DateOfBirthPlusAge = DateOnly.Parse(PlayerDateOfBirth.Text).AddYears(int.Parse(PlayerAge.Text));
            if (DateOfBirthPlusAge == DateOnly.FromDateTime(DateTime.Now))
            {
                errorMessage = "Greška! Broj godina plus datum rođenja ne može biti veći od sadašnjeg datuma!";
                return true;
            }
            try
            {
                TeamId = context.Teams.Single(t => string.Equals(t.Name, PlayerTeam.Text)).Id;
            }
            catch (Exception ex) 
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
